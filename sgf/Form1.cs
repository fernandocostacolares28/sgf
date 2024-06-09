﻿using sgf.Telas.Cadastros;
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
    }
}
