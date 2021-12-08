using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Correios;

namespace ConsultaAPI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCEP.Text))
                MessageBox.Show("O campo de CEP está vazio", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    CorreiosApi correiosApi = new CorreiosApi();
                    var retorno = correiosApi.consultaCEP(txtCEP.Text);

                    if (retorno is null)
                    {
                        MessageBox.Show("CEP NÃO ENCONTRADO", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    txtUF.Text = retorno.uf;
                    txtCidade.Text = retorno.cidade;
                    txtEndereco.Text = retorno.end;
                    txtComp1.Text = retorno.complemento;
                    txtComp2.Text = retorno.complemento2;
                    txtBairro.Text = retorno.bairro;
                    //txtUndPostagem.Text = retorno.unidadesPostagem;
                }
                catch(Exception erro)
                {
                    MessageBox.Show("ERRO AO CONSULTAR O CEP: " + erro.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair da Aplicação?", "Saindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
