using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using sgf.Entidades;

public class RelatorioFinanceiro
{
    public static void GerarRelatorioFinanceiroPDF(DateTime dataInicio, DateTime dataFim)
    {
        // Consulta SQL para pegar os totais de vendas e compras
        var totais = ObterTotaisVendasECompras(dataInicio, dataFim);

        // Caminho para salvar o relatório
        string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string nomeArquivo = $"RelatorioFinanceiro_{dataInicio.ToString("yyyyMMdd")}_a_{dataFim.ToString("yyyyMMdd")}.pdf";
        string caminhoRelatorio = Path.Combine(pastaDocumentos, nomeArquivo);

        // Cria o documento PDF
        Document documento = new Document(PageSize.A4, 25, 25, 30, 30);

        try
        {
            PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(caminhoRelatorio, FileMode.Create));
            documento.Open();

            // Fontes
            var fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.RED);
            var fonteSubTitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.DARK_GRAY);
            var fonteConteudo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);

            // Título
            Paragraph titulo = new Paragraph("Relatório Financeiro - Ganhos e Perdas\n\n", fonteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            documento.Add(titulo);

            // Período
            Paragraph periodo = new Paragraph($"Período: {dataInicio.ToShortDateString()} a {dataFim.ToShortDateString()}\n\n", fonteSubTitulo);
            periodo.Alignment = Element.ALIGN_CENTER;
            documento.Add(periodo);

            // Adicionando os totais
            Paragraph vendas = new Paragraph($"Total de Vendas: {totais.TotalVendas.ToString("C", new System.Globalization.CultureInfo("pt-BR"))}\n", fonteConteudo);
            documento.Add(vendas);

            Paragraph compras = new Paragraph($"Total de Compras: {totais.TotalCompras.ToString("C", new System.Globalization.CultureInfo("pt-BR"))}\n", fonteConteudo);
            documento.Add(compras);

            // Calcular o saldo final (ganhos - perdas)
            float saldoFinal = totais.TotalVendas - totais.TotalCompras;
            string saldoFinalTexto = saldoFinal >= 0 ? "Lucro" : "Prejuízo";

            // Adicionando saldo final
            Paragraph saldo = new Paragraph($"\nSaldo Final ({saldoFinalTexto}): {saldoFinal.ToString("C", new System.Globalization.CultureInfo("pt-BR"))}\n", fonteConteudo);
            saldo.Alignment = Element.ALIGN_RIGHT;
            documento.Add(saldo);

            // Fechar o documento
            documento.Close();

            // Mensagem de sucesso
            MessageBox.Show($"Relatório gerado com sucesso! Salvo em: {caminhoRelatorio}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static (float TotalVendas, float TotalCompras) ObterTotaisVendasECompras(DateTime dataInicio, DateTime dataFim)
    {
        float totalVendas = 0;
        float totalCompras = 0;

        using (MySqlConnection connection = new MySqlConnection(DBConnection.GetConnectionString()))
        {
            string query = @"
            SELECT 
                (SELECT COALESCE(SUM(total_venda), 0) FROM venda WHERE data_venda BETWEEN @dataInicio AND @dataFim) AS total_vendas,
                (SELECT COALESCE(SUM(total_compra), 0) FROM compra WHERE data_compra BETWEEN @dataInicio AND @dataFim) AS total_compras";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@dataInicio", dataInicio);
                command.Parameters.AddWithValue("@dataFim", dataFim);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalVendas = reader.GetFloat("total_vendas");
                            totalCompras = reader.GetFloat("total_compras");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter totais: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        return (totalVendas, totalCompras);
    }

}
