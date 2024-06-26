﻿using sgf.Telas.Cadastros;
using sgf.Telas.Gerenciamento;
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
        public Form1()
        {
            InitializeComponent();
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
    }
}
