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
    public partial class F_FilhoCheckBox : Form
    {
        public F_CheckBox f_CheckBox;
        public F_FilhoCheckBox()
        {
            InitializeComponent();
            if (Application.OpenForms["F_CheckBox"].Created)
            {
                f_CheckBox = Application.OpenForms["F_CheckBox"] as F_CheckBox;
                cb_carro.Checked = f_CheckBox.cb_carro.Checked;
                cb_aviao.Checked = f_CheckBox.cb_aviao.Checked;
                cb_navio.Checked = f_CheckBox.cb_navio.Checked;
                cb_onibus.Checked = f_CheckBox.cb_onibus.Checked;
            }

            
        }

        private void cb_carro_CheckedChanged(object sender, EventArgs e)
        {
            f_CheckBox.cb_carro.Checked = cb_carro.Checked;
        }

        private void cb_aviao_CheckedChanged(object sender, EventArgs e)
        {
            f_CheckBox.cb_aviao.Checked = cb_aviao.Checked;
        }

        private void cb_navio_CheckedChanged(object sender, EventArgs e)
        {
            f_CheckBox.cb_navio.Checked = cb_navio.Checked;
        }

        private void cb_onibus_CheckedChanged(object sender, EventArgs e)
        {
            f_CheckBox.cb_onibus.Checked = cb_onibus.Checked;
        }
    }
}
