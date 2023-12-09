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
    public partial class F_LinkedLabel : Form
    {
        public F_LinkedLabel()
        {
            InitializeComponent();
            ll_Diversos.Links.Add(0, 6, "www.google.com.br");
            ll_Diversos.Links.Add(9, 5, "www.github.com.br");
            ll_Diversos.Links.Add(17, 7, "www.youtube.com.br");
        }

        private void ll_github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Thomaz-Peres");
            ll_github.LinkVisited = true;
        }

        private void ll_arquivoWindows_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void ll_Diversos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
