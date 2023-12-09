using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula62___Componentes
{
    public partial class F_WebBrowser : Form
    {
        string home = null;
        public F_WebBrowser()
        {
            InitializeComponent();
        }

        private void Navegar()
        {
            if (tb_url.Text != "")
            {
                webBrowser1.Navigate(tb_url.Text);
            }
            else
            {
                MessageBox.Show("Digite uma URL");
                tb_url.Focus();
            }
        }

        private void btn_Navegar_Click(object sender, EventArgs e)
        {
            Navegar();
        }

        private void tb_url_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Navegar();
            }
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            if(home == null)
            {
                webBrowser1.GoHome();
            }
            else
            {
                webBrowser1.Navigate(home);
            }
            webBrowser1.GoHome();
        }

        private void btn_Proximo_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void webBrowser1_CanGoForwardChanged(object sender, EventArgs e)
        {
            btn_Proximo.Enabled = webBrowser1.CanGoForward;
        }

        private void webBrowser1_CanGoBackChanged(object sender, EventArgs e)
        {
            btn_voltar.Enabled = webBrowser1.CanGoBack;
        }

        private void btn_parar_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void btn_Pesquisa_Click(object sender, EventArgs e)
        {
            webBrowser1.GoSearch();
        }

        private void btn_definirHome_Click(object sender, EventArgs e)
        {
            home = tb_url.Text;
        }
    }
}
