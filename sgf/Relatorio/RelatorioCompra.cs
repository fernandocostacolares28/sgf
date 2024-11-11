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
    internal class RelatorioCompra
    {
        public static DataTable FiltrarComprasPorData(DateTime dataInicio, DateTime dataFim)
        {
            DataTable dt = new DataTable();

            // Ajustar a data de fim para considerar até o final do dia (23:59:59)
            DateTime dataFimAjustada = dataFim.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
            SELECT c.id_compra, c.id_fornecedor, f.razaosocial_fornecedor,c.data_compra, c.metodopagamento_compra, c.parcela_compra, c.total_compra, c.status_compra
                FROM compra c
                JOIN fornecedor f ON c.id_fornecedor = f.id_fornecedor
            WHERE data_compra BETWEEN @dataInicio AND @dataFim ORDER BY data_compra";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dataInicio", dataInicio);
                    command.Parameters.AddWithValue("@dataFim", dataFimAjustada);

                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao filtrar compras: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dt;
        }
        public static void GerarRelatorioComprasPDF(DateTime dataInicio, DateTime dataFim)
        {
            DataTable compras = FiltrarComprasPorData(dataInicio, dataFim);

            string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nomeArquivo = $"RelatorioCompras_{dataInicio.ToString("yyyyMMdd")}_a_{dataFim.ToString("yyyyMMdd")}.pdf";
            string caminhoRelatorio = Path.Combine(pastaDocumentos, nomeArquivo);

            Document documento = new Document(PageSize.A4, 25, 25, 30, 30);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(caminhoRelatorio, FileMode.Create));
                documento.Open();

                string caminhoImagem = @"C:\Git\sgf\sgf\img\teste.png"; // Defina o caminho da imagem
                Image logo = Image.GetInstance(caminhoImagem);
                logo.ScaleToFit(140f, 120f); // Redimensiona a imagem se necessário
                logo.Alignment = Element.ALIGN_CENTER; // Alinhar ao centro

                // Adicionar a imagem no documento
                documento.Add(logo);

                // Fontes personalizadas
                var fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.RED);
                var fonteSubTitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.DARK_GRAY);
                var fonteTabelaCabecalho = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
                var fonteTabelaCabecalhoItem = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7, BaseColor.BLACK);
                var fonteTabelaConteudo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                var fonteTabelaItem = FontFactory.GetFont(FontFactory.HELVETICA, 6, BaseColor.GRAY);
                var fonteTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);

                // Título do relatório
                Paragraph titulo = new Paragraph($"Relatório de Compras\n\n", fonteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(titulo);

                // Período
                Paragraph periodo = new Paragraph($"Período: {dataInicio.ToShortDateString()} a {dataFim.ToShortDateString()}\n\n", fonteSubTitulo);
                periodo.Alignment = Element.ALIGN_CENTER;
                documento.Add(periodo);

                // Tabela com estilo
                PdfPTable tabela = new PdfPTable(7); // 7 colunas
                tabela.WidthPercentage = 100; // Largura completa da página
                tabela.SetWidths(new float[] { 1, 3, 2, 2, 1, 2, 2 }); // Definir proporções das colunas

                // Definir cabeçalhos com cor de fundo
                PdfPCell celulaCabecalho = new PdfPCell();
                celulaCabecalho.BackgroundColor = BaseColor.DARK_GRAY;
                celulaCabecalho.HorizontalAlignment = Element.ALIGN_CENTER;
                celulaCabecalho.Padding = 5;

                // Cabeçalhos
                string[] colunas = { "ID Compra", "Razão Social", "Data Compra", "Método Pagamento", "Parcelas", "Total Venda", "Status" };
                foreach (string coluna in colunas)
                {
                    celulaCabecalho.Phrase = new Phrase(coluna, fonteTabelaCabecalho);
                    tabela.AddCell(celulaCabecalho);
                }

                // Variável para armazenar o total geral
                float totalGeral = 0;

                // Preencher os dados
                PdfPCell celulaConteudo = new PdfPCell();
                celulaConteudo.Padding = 5;
                celulaConteudo.HorizontalAlignment = Element.ALIGN_CENTER;

                foreach (DataRow compra in compras.Rows)
                {
                    celulaConteudo.Phrase = new Phrase(compra["id_compra"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(compra["razaosocial_fornecedor"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(Convert.ToDateTime(compra["data_compra"]).ToShortDateString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(compra["metodopagamento_compra"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(compra["parcela_compra"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    // Formatar total_venda com R$
                    float totalVenda = Convert.ToSingle(compra["total_compra"]);
                    celulaConteudo.Phrase = new Phrase(totalVenda.ToString("C", new System.Globalization.CultureInfo("pt-BR")), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(compra["status_compra"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    // Somar ao total geral
                    totalGeral += totalVenda;

                }

                // Adicionar a tabela ao documento
                documento.Add(tabela);

                // Adicionar a soma total no final
                Paragraph total = new Paragraph($"\nTotal Geral Gasto: {totalGeral.ToString("C", new System.Globalization.CultureInfo("pt-BR"))}\n", fonteTotal);
                total.Alignment = Element.ALIGN_RIGHT;
                documento.Add(total);

                // Fechar o documento
                documento.Close();
                MessageBox.Show($"Relatório gerado com sucesso! Salvo em: {caminhoRelatorio}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
/*            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = caminhoRelatorio;
                process.StartInfo.Verb = "Print"; // Usa a opção 'Print' para abrir diretamente a página de impressão
                process.StartInfo.CreateNoWindow = true; // Executa o processo sem janela
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o relatório para impressão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
    }
}
