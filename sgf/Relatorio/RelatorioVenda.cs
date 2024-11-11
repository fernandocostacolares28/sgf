using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using sgf.Controle;
using sgf.Entidades;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Mysqlx.Resultset;

public class RelatorioVenda
{
    public static DataTable FiltrarVendasPorData(DateTime dataInicio, DateTime dataFim)
    {
        DataTable dt = new DataTable();

        // Ajustar a data de fim para considerar até o final do dia seguinte (exclusivo)
        DateTime dataFimAjustada = dataFim.Date.AddDays(1); // Adiciona um dia e usa '<' no filtro SQL

        using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
        {
            string query = @"
            SELECT v.id_venda, v.id_cliente, c.name_cliente, v.receita_venda, v.data_venda, v.metodopagamento_venda, v.parcelas_venda, v.total_venda, v.desconto_venda
            FROM venda v
            JOIN cliente c ON v.id_cliente = c.id_cliente
            WHERE data_venda >= @dataInicio AND data_venda <= @dataFimAjustada
            ORDER BY data_venda";

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
                    MessageBox.Show($"Erro ao filtrar vendas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        return dt;
    }
    public static void GerarRelatorioVendasPDF(DateTime dataInicio, DateTime dataFim)
    {
        DataTable vendas = FiltrarVendasPorData(dataInicio, dataFim);

        string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string nomeArquivo = $"RelatorioVendas_{dataInicio.ToString("yyyyMMdd")}_a_{dataFim.ToString("yyyyMMdd")}.pdf";
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
            Paragraph titulo = new Paragraph($"Relatório de Vendas\n\n", fonteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            documento.Add(titulo);

            // Período
            Paragraph periodo = new Paragraph($"Período: {dataInicio.ToShortDateString()} a {dataFim.ToShortDateString()}\n\n", fonteSubTitulo);
            periodo.Alignment = Element.ALIGN_CENTER;
            documento.Add(periodo);

            // Tabela com estilo
            PdfPTable tabela = new PdfPTable(7); // 7 colunas
            tabela.WidthPercentage = 100; // Largura completa da página
            tabela.SetWidths(new float[] { 1, 3, 3, 2, 1, 2, 1 }); // Definir proporções das colunas

            // Definir cabeçalhos com cor de fundo
            PdfPCell celulaCabecalho = new PdfPCell();
            celulaCabecalho.BackgroundColor = BaseColor.DARK_GRAY;
            celulaCabecalho.HorizontalAlignment = Element.ALIGN_CENTER;
            celulaCabecalho.Padding = 5;

            // Cabeçalhos
            string[] colunas = { "ID Venda", "Nome Cliente", "Data Venda", "Método Pagamento", "Parcelas", "Total Venda", "Desconto" };
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

            foreach (DataRow venda in vendas.Rows)
            {
                celulaConteudo.Phrase = new Phrase(venda["id_venda"].ToString(), fonteTabelaConteudo);
                tabela.AddCell(celulaConteudo);

                celulaConteudo.Phrase = new Phrase(venda["name_cliente"].ToString(), fonteTabelaConteudo);
                tabela.AddCell(celulaConteudo);

                celulaConteudo.Phrase = new Phrase(Convert.ToDateTime(venda["data_venda"]).ToShortDateString(), fonteTabelaConteudo);
                tabela.AddCell(celulaConteudo);

                celulaConteudo.Phrase = new Phrase(venda["metodopagamento_venda"].ToString(), fonteTabelaConteudo);
                tabela.AddCell(celulaConteudo);

                celulaConteudo.Phrase = new Phrase(venda["parcelas_venda"].ToString(), fonteTabelaConteudo);
                tabela.AddCell(celulaConteudo);

                // Formatar total_venda com R$
                float totalVenda = Convert.ToSingle(venda["total_venda"]);
                celulaConteudo.Phrase = new Phrase(totalVenda.ToString("C", new System.Globalization.CultureInfo("pt-BR")), fonteTabelaConteudo);
                tabela.AddCell(celulaConteudo);

                celulaConteudo.Phrase = new Phrase(venda["desconto_venda"].ToString(), fonteTabelaConteudo);
                tabela.AddCell(celulaConteudo);

                // Somar ao total geral
                totalGeral += totalVenda;

                // Aqui, você precisa obter os itens da venda
                int idVenda = Convert.ToInt32(venda["id_venda"]);
                DataTable dtItens = ObterItensVenda(idVenda); // Método que você precisará criar

                string[] colunasitens = { "Produto", "Quantidade", "Valor Unidade", "Total" };
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
                    tabela.AddCell("");

                    celulaConteudo.Phrase = new Phrase(itemRow["name_produto"].ToString(), fonteTabelaItem);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(itemRow["quantidade_produto"].ToString(), fonteTabelaItem);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(Convert.ToDecimal(itemRow["valor_unitario"]).ToString("C2"), fonteTabelaItem);
                    tabela.AddCell(celulaConteudo);

                    celulaConteudo.Phrase = new Phrase(Convert.ToDecimal(itemRow["total"]).ToString("C2"), fonteTabelaItem);
                    tabela.AddCell(celulaConteudo);



                }
                tabela.AddCell("");
                tabela.AddCell("");
                tabela.AddCell("");
            }

            // Adicionar a tabela ao documento
            documento.Add(tabela);

            // Adicionar a soma total no final
            Paragraph total = new Paragraph($"\nTotal Geral: {totalGeral.ToString("C", new System.Globalization.CultureInfo("pt-BR"))}\n", fonteTotal);
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
    }

    private static DataTable ObterItensVenda(int idVenda)
    {
        DataTable dtItens = new DataTable();

        using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
        {
            string query = @"
            SELECT name_produto, quantidade_produto, valor_unitario, (quantidade_produto * valor_unitario) as total
                From item_venda
            WHERE id_venda = @id_venda";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id_venda", idVenda);

                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dtItens);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter itens da venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        return dtItens;
    }

    // Método para obter dados da tabela "Venda" e preencher a lista
    private static List<Venda> ObterDadosVendas()
    {
        List<Venda> listaVendas = new List<Venda>();

        using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
        {
            string query = @"
                SELECT v.id_venda, v.id_cliente, c.name_cliente, v.receita_venda, v.data_venda, v.metodopagamento_venda, v.parcelas_venda, v.total_venda, v.desconto_venda
                FROM venda v
                JOIN cliente c ON v.id_cliente = c.id_cliente";

            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Venda venda = new Venda
                        {
                            IdVenda = reader.GetInt32("id_venda"),
                            Cliente = reader.GetString("name_cliente"),
                            Receita_venda = reader.GetString("receita_venda"),
                            Data_venda = reader.GetDateTime("data_venda"),
                            Metodopagamento_venda = reader.GetString("metodopagamento_venda"),
                            Parcelas_venda = reader.GetInt32("parcelas_venda"),
                            Total_venda = reader.GetFloat("total_venda"),
                            Desconto_venda = reader.GetFloat("desconto_venda")
                        };

                        listaVendas.Add(venda);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter dados de vendas: {ex.Message}");
            }
        }

        return listaVendas;
    }
}

