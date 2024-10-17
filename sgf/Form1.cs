using sgf.AutenticacaoUser;
using sgf.Telas.Cadastros;
using sgf.Telas.Cadastros.Lote;
using sgf.Telas.Financeiro;
using sgf.Telas.Financeiro.ContasPagar;
using sgf.Telas.Gerenciamento;
using sgf.Telas.Login;
using sgf.Telas.Movimentos;
using sgf.Telas.Movimentos.Compra;
using sgf.Telas.Relatorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf
{
    public partial class Form1 : Form
    {
        public Form1(string NivelAcesso)
        {
            //ConfigurarPermissoes(NivelAcesso);
            InitializeComponent();
            ConfigurarPermissoes(NivelAcesso);
            
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadProduto produto = new FormCadProduto();
            produto.ShowDialog();
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadFuncionario funcionario = new FormCadFuncionario();
            funcionario.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadCliente cliente = new FormCadCliente();
            cliente.ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadFornecedor fornecedor = new FormCadFornecedor();
            fornecedor.ShowDialog();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadUsuario usuario = new FormCadUsuario();
            usuario.ShowDialog();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEstoque estoque = new FormEstoque();
            estoque.ShowDialog();
        }

        private void loteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadLote lote = new FormCadLote();
            lote.ShowDialog();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVenda venda = new FormVenda();
            venda.ShowDialog();
        }

        private void contasAReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormContasReceber formContasReceber = new FormContasReceber();
            formContasReceber.ShowDialog();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCompra formCompra = new FormCompra();
            formCompra.ShowDialog();
        }

        private void contasAPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormContasPagar formContasPagar = new FormContasPagar();
            formContasPagar.ShowDialog();
        }

        private void vendaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormRelatorioVenda formRelatorioVenda = new FormRelatorioVenda();
            formRelatorioVenda.ShowDialog();
        }

        private void compraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormRelatorioCompra formRelatorio = new FormRelatorioCompra();
            formRelatorio.ShowDialog();
        }

        private void contasAReceberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormRelatorioContasReceber formRelatorioContasReceber = new FormRelatorioContasReceber();
            formRelatorioContasReceber.ShowDialog();
        }

        private void contasAPagarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormRelatorioContasPagar formRelatorioContasPagar = new FormRelatorioContasPagar();
            formRelatorioContasPagar.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ConfigurarPermissoes(string NivelAcesso)
        {
            // Exemplo de controle de acesso
            if (NivelAcesso == "sysadmin") // Nível 1: acesso total
            {
                // Habilite todas as opções
            }
            else if (NivelAcesso == "vendedor") // Nível 2: acesso limitado
            {
                // Desabilite opções de administração, por exemplo
                financeiroToolStripMenuItem.Visible = false;
                compraToolStripMenuItem.Visible = false;
                usuárioToolStripMenuItem.Visible = false;
                clienteToolStripMenuItem.Visible = false;
                funcionarioToolStripMenuItem.Visible = false;
            }
            else if (NivelAcesso == "CEO") // Nível 3: acesso ainda mais restrito
            {
            }
            else if(NivelAcesso == "auxiliar")
            {
                financeiroToolStripMenuItem.Visible = false;
                compraToolStripMenuItem.Visible = false;
                usuárioToolStripMenuItem.Visible = false;
                clienteToolStripMenuItem.Visible = false;
                funcionarioToolStripMenuItem.Visible = false;
                loteToolStripMenuItem.Visible = false;
                fornecedorToolStripMenuItem.Visible = false;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();


            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            
            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maisVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRelatorioMaisVendidos formRelatorioMaisVendidos = new FormRelatorioMaisVendidos();
            formRelatorioMaisVendidos.ShowDialog();
        }

        private void loteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormRelatorioLote lote = new FormRelatorioLote();
            lote.ShowDialog();
        }

        private void vencimentoLoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRelatorioFinanceiro formRelatorioFinanceiro = new FormRelatorioFinanceiro();
            formRelatorioFinanceiro.ShowDialog();
        }
    }
}
