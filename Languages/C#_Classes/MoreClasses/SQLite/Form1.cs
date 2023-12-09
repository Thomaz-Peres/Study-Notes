using SQLite.BancoDados;
using SQLite.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            F_Login f_Login = new F_Login(this);
            f_Login.ShowDialog();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            lb_acesso.Text = "0";
            lb_nomeUsuario.Text = "---";
            pb_ledLogado.Image = Properties.Resources.led_vermelho;
            Globais.nivel = 0;
            Globais.logado = false;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            F_Login f_Login = new F_Login(this);
            f_Login.ShowDialog();
        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Globais.logado == true)
            {
                if(Globais.nivel >= 2)
                {
                    //Procedimentos da janela
                }
                else
                {
                    MessageBox.Show("Nivel de acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessario ter um usuario logado.");
            }
        }

        private void novoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado == true)
            {
                if (Globais.nivel >= 1)
                {
                    F_NovoUsuario f_NovoUsuario = new F_NovoUsuario();
                    f_NovoUsuario.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nivel de acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessario ter um usuario logado.");
            }
        }

        private void gestãoDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado == true)
            {
                if (Globais.nivel >= 2)
                {
                    F_GestaoUsuarios f_GestaoUsuarios = new F_GestaoUsuarios();
                    f_GestaoUsuarios.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nivel de acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessario ter um usuario logado.");
            }
        }

        private void novoAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado == true)
            {
                    //procedimentos
            }
            else
            {
                MessageBox.Show("É necessario ter um usuario logado.");
            }
        }
    }
}
