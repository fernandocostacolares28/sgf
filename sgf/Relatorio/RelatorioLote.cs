using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using sgf.Controle;
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
    internal class RelatorioLote
    {

        public static DataTable FiltrarLote(string lote)
        {
            DataTable dt = new DataTable();


            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
            SELECT id_lote, code_lote, dt_validade_lote, status_lote,farmaceutica_lote
            FROM lote
            WHERE code_lote = @lote";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@lote", lote);

                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao filtrar lote: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dt;
        }
        public static void GerarRelatorioLotePDF(string lote)
        {
            DataTable lotes = FiltrarLote(lote);

            string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nomeArquivo = $"RelatorioLote_{lote.ToString()}.pdf";
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
                var fonteTabelaCabecalhoItem = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7, BaseColor.WHITE);
                var fonteTabelaConteudo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                var fonteTabelaItem = FontFactory.GetFont(FontFactory.HELVETICA, 6, BaseColor.BLACK);
                var fonteTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);

                // Título do relatório
                Paragraph titulo = new Paragraph($"Relatório de Lote\n\n", fonteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(titulo);

                // Período
                Paragraph periodo = new Paragraph($"Lote: {lote}\n\n", fonteSubTitulo);
                periodo.Alignment = Element.ALIGN_CENTER;
                documento.Add(periodo);

                // Tabela com estilo
                PdfPTable tabela = new PdfPTable(5); // 7 colunas
                tabela.WidthPercentage = 100; // Largura completa da página
                tabela.SetWidths(new float[] { 1, 3, 3, 3, 3 }); // Definir proporções das colunas

                // Definir cabeçalhos com cor de fundo
                PdfPCell celulaCabecalho = new PdfPCell();
                celulaCabecalho.BackgroundColor = BaseColor.DARK_GRAY;
                celulaCabecalho.HorizontalAlignment = Element.ALIGN_CENTER;
                celulaCabecalho.Padding = 5;

                // Cabeçalhos
                string[] colunas = { "ID Lote", "Code", "Validade", "Status", "Farmaceutica" };
                foreach (string coluna in colunas)
                {
                    celulaCabecalho.Phrase = new Phrase(coluna, fonteTabelaCabecalho);
                    tabela.AddCell(celulaCabecalho);
                }


                // Preencher os dados
                PdfPCell celulaConteudo = new PdfPCell();
                celulaConteudo.Padding = 5;
                celulaConteudo.HorizontalAlignment = Element.ALIGN_CENTER;

                foreach (DataRow row in lotes.Rows)
                {
                    celulaConteudo.Phrase = new Phrase(row["id_lote"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(row["code_lote"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(Convert.ToDateTime(row["dt_validade_lote"]).ToShortDateString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(row["status_lote"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(row["farmaceutica_lote"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);


                    // Aqui, você precisa obter os itens da venda
                    int idLote = Convert.ToInt32(row["id_lote"]);
                    DataTable dtItens = ObterItensLote(idLote); // Método que você precisará criar

                    string[] colunasitens = { "Produto", "Valor", "Quantidade" };
                    foreach (string coluna in colunasitens)
                    {
                        celulaCabecalho.Phrase = new Phrase(coluna, fonteTabelaCabecalhoItem);
                        tabela.AddCell(celulaCabecalho);
                    }

                    // Adiciona os itens abaixo da venda
                    foreach (DataRow itemRow in dtItens.Rows)
                    {
                        tabela.AddCell("");
                        tabela.AddCell("");

                        celulaConteudo.Phrase = new Phrase(itemRow["name_produto"].ToString(), fonteTabelaItem);
                        tabela.AddCell(celulaConteudo);

                        celulaConteudo.Phrase = new Phrase(Convert.ToDecimal(itemRow["valor_produto"]).ToString("C2"), fonteTabelaItem);
                        tabela.AddCell(celulaConteudo);

                        celulaConteudo.Phrase = new Phrase(itemRow["qtd_produto"].ToString(), fonteTabelaItem);
                        tabela.AddCell(celulaConteudo);


                    }
                    tabela.AddCell("");

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

        private static DataTable ObterItensLote(int idLote)
        {
            DataTable dtItens = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
            SELECT name_produto, valor_produto, qtd_produto
                From produto_lote
            WHERE id_lote = @id_lote";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_lote", idLote);

                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dtItens);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao obter itens do lote: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dtItens;
        }

    }
}
