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

namespace sgf.Telas.Financeiro.ContasReceber
{
    public partial class FormDetalhesContasReceber : Form
    {
        public FormDetalhesContasReceber(int id)
        {
            InitializeComponent();
            DetalhesContaReceber.CarregarPagamentosContasReceber(id, DGV_pagamentos);
        }

        private void FormDetalhesContasReceber_Load(object sender, EventArgs e)
        {

        }
    }
}
