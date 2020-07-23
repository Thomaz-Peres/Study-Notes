using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor_de_Texto
{
    public partial class Form1 : Form
    {

        StringReader leitura = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Novo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void Salvar()
        {
            try
            {
                if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter cfb_streamWriter = new StreamWriter(arquivo);
                    cfb_streamWriter.Flush();
                    cfb_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    cfb_streamWriter.Write(this.richTextBox1.Text);
                    cfb_streamWriter.Flush();   //  atualiza o buffer.
                    cfb_streamWriter.Close();   //  nunca esquecer de fechar
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Erro na gravação: " + ex.Message, "Erro ao gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Abrir()
        {
            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\AlphaPaiN\Documents\dev\Notes\Visual Studio\Editor de Texto";
            openFileDialog1.Filter = "(*.md) | *.md";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if(dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader cfb_streamReader = new StreamReader(arquivo);
                    cfb_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = cfb_streamReader.ReadLine();
                    
                    while(linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = cfb_streamReader.ReadLine();
                    }
                    cfb_streamReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro na leitura: " + ex.Message, "Erro ao ler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void Copiar()
        {
            if(richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void Colar()
        {
            richTextBox1.Paste();
        }

        private void Recortar()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void Imprimir()
        {
            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto);
            
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }

        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void colasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void Negrito()
        {
            string nomeDaFonte = null;
            bool negrito, italico, sublinhado = false;

            float tamanhoDaFonte = 0;
            nomeDaFonte = richTextBox1.Font.Name;
            tamanhoDaFonte = richTextBox1.Font.Size;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Regular);

            if (negrito == false)
            {
                if(italico == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (italico == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (italico == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (italico == false & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold);
                }
            }
            else
            {
                if (italico == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (italico == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Underline);
                }
                else if (italico == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic);
                }
            }
            
        }

        private void Italico()
        {
            string nomeDaFonte = null;
            bool negrito, italico, sublinhado = false;

            float tamanhoDaFonte = 0;
            nomeDaFonte = richTextBox1.Font.Name;
            tamanhoDaFonte = richTextBox1.Font.Size;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Regular);

            if (italico == false)
            {
                if (negrito == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic | FontStyle.Bold);
                }
                else if (negrito == false & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic);
                }
            }
            else
            {
                if (negrito == true & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (negrito == false & sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Underline);
                }
                else if (negrito == true & sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold);
                }
            }
        }

        private void Subinhado()
        {
            string nomeDaFonte = null;
            bool negrito, italico, sublinhado = false;

            float tamanhoDaFonte = 0;
            nomeDaFonte = richTextBox1.Font.Name;
            tamanhoDaFonte = richTextBox1.Font.Size;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Regular);

            if (sublinhado == false)
            {
                if (negrito == true & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == false & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == true & italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Underline | FontStyle.Bold);
                }
                else if (negrito == false & italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Underline);
                }
            }
            else
            {
                if (negrito == true & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (negrito == false & italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic);
                }
                else if (negrito == true & italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold);
                }
            }
        }

        private void btn_negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            Subinhado();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void italicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void subinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subinhado();
        }

        private void AlinhasEsquerda()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void AlinhasDireita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void AlinhasCentro()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            AlinhasEsquerda();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlinhasEsquerda();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlinhasDireita();
        }

        private void btn_direta_Click(object sender, EventArgs e)
        {
            AlinhasDireita();
        }

        private void btn_centro_Click(object sender, EventArgs e)
        {
            AlinhasCentro();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlinhasCentro();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPagina = 0;
            float PosY = 0;
            int contador = 0;
            float marginEsquerda = e.MarginBounds.Left - 50;
            float marginSuperior = e.MarginBounds.Top - 50;

            if(marginEsquerda < 5)
            {
                marginEsquerda = 20;
            }

            if (marginSuperior < 5)
            {
                marginSuperior = 20;
            }

            string linha = null;
            Font fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);
            linhasPagina = e.MarginBounds.Height / fonte.GetHeight(e.Graphics); //  verificando o numero de linhas por pagina
            linha = leitura.ReadLine();

            while(contador < linhasPagina)
            {
                PosY = (marginSuperior + (contador * fonte.GetHeight(e.Graphics)));
                e.Graphics.DrawString(linha, fonte, pincel, marginEsquerda, PosY, new StringFormat());
                contador += 1;
                linha = leitura.ReadLine();
            }

            if(linha != null)
            {
                e.HasMorePages = true;  //  imprimir em outra pagina
            }
            else
            {
                e.HasMorePages = false;
            }
            pincel.Dispose();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
    }
}
