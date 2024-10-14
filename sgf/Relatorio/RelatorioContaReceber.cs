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
    internal class RelatorioContaReceber
    {
        public static DataTable FiltrarVendasPorData(DateTime dataInicio, DateTime dataFim)
        {
            DataTable dt = new DataTable();

            // Ajustar a data de fim para considerar até o final do dia (23:59:59)
            DateTime dataFimAjustada = dataFim.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
            SELECT cr.id_contareceber, cr.id_venda, v.id_cliente, c.name_cliente, cr.parcela_contareceber, cr.total_contareceber, cr.restante_contareceber, cr.status_contareceber
                FROM contareceber cr
                JOIN venda v ON v.id_venda = cr.id_venda
                JOIN cliente c ON c.id_cliente = v.id_cliente
            WHERE v.data_venda >= @dataInicio AND v.data_venda < @dataFim ORDER BY v.data_venda";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dataInicio", dataInicio.Date);
                    command.Parameters.AddWithValue("@dataFim", dataFimAjustada);

                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao filtrar contas receber: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dt;
        }
        public static void GerarRelatorioContasReceberPDF(DateTime dataInicio, DateTime dataFim)
        {
            DataTable contas = FiltrarVendasPorData(dataInicio, dataFim);

            string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nomeArquivo = $"RelatorioContasReceber_{dataInicio.ToString("yyyyMMdd")}_a_{dataFim.ToString("yyyyMMdd")}.pdf";
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
                var fonteTabelaCabecalhoItem = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7, BaseColor.BLACK);
                var fonteTabelaConteudo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                var fonteTabelaItem = FontFactory.GetFont(FontFactory.HELVETICA, 6, BaseColor.BLACK);
                var fonteTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);

                // Título do relatório
                Paragraph titulo = new Paragraph($"Relatório de Contas Receber\n\n", fonteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(titulo);

                // Período
                Paragraph periodo = new Paragraph($"Período: {dataInicio.ToShortDateString()} a {dataFim.ToShortDateString()}\n\n", fonteSubTitulo);
                periodo.Alignment = Element.ALIGN_CENTER;
                documento.Add(periodo);

                // Tabela com estilo
                PdfPTable tabela = new PdfPTable(6); // 7 colunas
                tabela.WidthPercentage = 100; // Largura completa da página
                tabela.SetWidths(new float[] { 2, 2, 2, 2, 2, 2 }); // Definir proporções das colunas

                // Definir cabeçalhos com cor de fundo
                PdfPCell celulaCabecalho = new PdfPCell();
                celulaCabecalho.BackgroundColor = BaseColor.DARK_GRAY;
                celulaCabecalho.HorizontalAlignment = Element.ALIGN_CENTER;
                celulaCabecalho.Padding = 5;

                // Cabeçalhos
                string[] colunas = { "ID Conta Receber", "Nome Cliente", "Parcela", "Total", "Restante", "Status" };
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

                foreach (DataRow conta in contas.Rows)
                {
                    celulaConteudo.Phrase = new Phrase(conta["id_contareceber"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(conta["name_cliente"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(conta["parcela_contareceber"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    float totalconta = Convert.ToSingle(conta["total_contareceber"]);
                    celulaConteudo.Phrase = new Phrase(totalconta.ToString("C", new System.Globalization.CultureInfo("pt-BR")), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);

                    float restante = Convert.ToSingle(conta["restante_contareceber"]);
                    celulaConteudo.Phrase = new Phrase(restante.ToString("C", new System.Globalization.CultureInfo("pt-BR")), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);


                    celulaConteudo.Phrase = new Phrase(conta["status_contareceber"].ToString(), fonteTabelaConteudo);
                    tabela.AddCell(celulaConteudo);


                    // Aqui, você precisa obter os itens da venda
                    int idContaReceber = Convert.ToInt32(conta["id_contareceber"]);
                    DataTable dtConta = ObterPagamentoContaReceber(idContaReceber); // Método que você precisará criar

                    string[] colunasitens = { "ID Pagamento", "Data Pagamento", "Valor Parcela", "Status" };
                    foreach (string coluna in colunasitens)
                    {
                        celulaCabecalho.Phrase = new Phrase(coluna, fonteTabelaCabecalhoItem);
                        tabela.AddCell(celulaCabecalho);
                    }

                    // Adiciona os itens abaixo da venda
                    foreach (DataRow itemRow in dtConta.Rows)
                    {
                        tabela.AddCell("");
                        tabela.AddCell("");
                        //tabela.AddCell("");

                        celulaConteudo.Phrase = new Phrase(itemRow["id_pagamento"].ToString(), fonteTabelaItem);
                        tabela.AddCell(celulaConteudo);

                        celulaConteudo.Phrase = new Phrase(Convert.ToDateTime(itemRow["data_pagamento"]).ToShortDateString(), fonteTabelaItem);
                        tabela.AddCell(celulaConteudo);

                        celulaConteudo.Phrase = new Phrase(Convert.ToDecimal(itemRow["valorparcela_pagamento"]).ToString("C2"), fonteTabelaItem);
                        tabela.AddCell(celulaConteudo);

                        celulaConteudo.Phrase = new Phrase(itemRow["status_pagamento"].ToString(), fonteTabelaItem);
                        tabela.AddCell(celulaConteudo);



                    }
                    tabela.AddCell("");
                    tabela.AddCell("");
                    //tabela.AddCell("");
                }

                // Adicionar a tabela ao documento
                documento.Add(tabela);

                // Adicionar a soma total no final
               // Paragraph total = new Paragraph($"\nTotal Geral: {totalGeral.ToString("C", new System.Globalization.CultureInfo("pt-BR"))}\n", fonteTotal);
                //total.Alignment = Element.ALIGN_RIGHT;
                //documento.Add(total);

                // Fechar o documento
                documento.Close();
                MessageBox.Show($"Relatório gerado com sucesso! Salvo em: {caminhoRelatorio}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static DataTable ObterPagamentoContaReceber(int idContaReceber)
        {
            DataTable dtPagamentos = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
            {
                string query = @"
            SELECT id_pagamento, data_pagamento, valorparcela_pagamento, status_pagamento
                From pagamentos_contareceber
            WHERE id_contareceber = @id_contareceber";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_contareceber", idContaReceber);

                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dtPagamentos);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao obter pagamentos contas receber: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dtPagamentos;
        }
    }
}
