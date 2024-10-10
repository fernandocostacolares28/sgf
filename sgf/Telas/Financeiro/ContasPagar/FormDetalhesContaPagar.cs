using sgf.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgf.Telas.Financeiro.ContasPagar
{
    public partial class FormDetalhesContaPagar : Form
    {
        public FormDetalhesContaPagar(int id)
        {
            InitializeComponent();
            DetalhesContaPagar.CarregarPagamentosContasPagar(id, DGV_pagamentos);
        }

        private void FormDetalhesContaPagar_Load(object sender, EventArgs e)
        {

        }
    }
}
