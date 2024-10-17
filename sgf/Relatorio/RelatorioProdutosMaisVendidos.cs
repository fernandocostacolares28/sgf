using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sgf.Entidades;

namespace sgf.Relatorio
{
    internal class RelatorioProdutosMaisVendidos
    {

        public static DataTable FiltrarMaisVendidosPorData(DateTime dataInicio, DateTime dataFim)
        {
            DataTable dt = new DataTable();

            // Ajustar a data de fim para considerar até o final do dia seguinte (exclusivo)
            DateTime dataFimAjustada = dataFim.Date.AddDays(1); // Adiciona um dia e usa '<' no filtro SQL

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
                    SELECT 
                        iv.name_produto, 
                        SUM(iv.quantidade_produto) AS quantidade_total_vendida, 
                        SUM(iv.quantidade_produto * iv.valor_unitario) AS valor_total_obtido
                    FROM 
                        item_venda iv
                    JOIN 
                        venda v ON iv.id_venda = v.id_venda
                    WHERE 
                        v.data_venda BETWEEN @dataInicio AND @dataFimAjustada
                    GROUP BY 
                        iv.name_produto
                    ORDER BY 
                        quantidade_total_vendida DESC;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dataInicio", dataInicio.Date);
                    command.Parameters.AddWithValue("@dataFimAjustada", dataFimAjustada);  // Data fim ajustada

                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao filtrar : {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dt;
        }
        public static void GerarRelatorioMaisVendidosPDF(DateTime dataInicio, DateTime dataFim)
        {
            DataTable MaisVendidos = FiltrarMaisVendidosPorData(dataInicio, dataFim);

            string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nomeArquivo = $"RelatorioMaisVendidos_{dataInicio.ToString("yyyyMMdd")}_a_{dataFim.ToString("yyyyMMdd")}.pdf";
            string caminhoRelatorio = Path.Combine(pastaDocumentos, nomeArquivo);

            Document documento = new Document(PageSize.A4, 25, 25, 30, 30);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(caminhoRelatorio, FileMode.Create));
                documento.Open();

                // Fontes personalizadas
                var fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.RED);
                var fonteSubTitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.DARK_GRAY);
                var fonteTabelaCabecalho = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
                var fonteTabelaCabecalhoItem = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7, BaseColor.WHITE);
                var fonteTabelaConteudo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                var fonteTabelaItem = FontFactory.GetFont(FontFactory.HELVETICA, 6, BaseColor.BLACK);
                var fonteTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);

                // Título do relatório
                Paragraph titulo = new Paragraph($"Relatório dos Produtos Mais Vendidos\n\n", fonteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(titulo);

                // Período
                Paragraph periodo = new Paragraph($"Período: {dataInicio.ToShortDateString()} a {dataFim.ToShortDateString()}\n\n", fonteSubTitulo);
                periodo.Alignment = Element.ALIGN_CENTER;
                documento.Add(periodo);

                // Tabela com estilo
                PdfPTable tabela = new PdfPTable(3); // 7 colunas
                tabela.WidthPercentage = 100; // Largura completa da página
                tabela.SetWidths(new float[] { 3, 3, 3 }); // Definir proporções das colunas

                // Definir cabeçalhos com cor de fundo
                PdfPCell celulaCabecalho = new PdfPCell();
                celulaCabecalho.BackgroundColor = BaseColor.DARK_GRAY;
                celulaCabecalho.HorizontalAlignment = Element.ALIGN_CENTER;
                celulaCabecalho.Padding = 5;

                // Cabeçalhos
                string[] colunas = { "Produto", "Quantidade", "Valor Arrecadado" };
                foreach (string coluna in colunas)
                {
                    celulaCabecalho.Phrase = new Phrase(coluna, fonteTabelaCabecalho);
                    tabela.AddCell(celulaCabecalho);
                }


                // Preencher os dados
                PdfPCell celulaConteudo = new PdfPCell();
                celulaConteudo.Padding = 5;
                celulaConteudo.HorizontalAlignment = Element.ALIGN_CENTER;

                foreach (DataRow row in MaisVendidos.Rows)
                {
                    celulaConteudo.Phrase = new Phrase(row["name_produto"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(row["quantidade_total_vendida"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    float total = Convert.ToSingle(row["valor_total_obtido"]);
                    celulaConteudo.Phrase = new Phrase(total.ToString("C", new System.Globalization.CultureInfo("pt-BR")), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                }

                // Adicionar a tabela ao documento
                documento.Add(tabela);


                // Fechar o documento
                documento.Close();
                MessageBox.Show($"Relatório gerado com sucesso! Salvo em: {caminhoRelatorio}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
