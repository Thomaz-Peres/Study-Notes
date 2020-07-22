namespace Aula62___Componentes
{
    partial class F_LinkedLabel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ll_github = new System.Windows.Forms.LinkLabel();
            this.ll_arquivoWindows = new System.Windows.Forms.LinkLabel();
            this.ll_Diversos = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ll_github
            // 
            this.ll_github.AutoSize = true;
            this.ll_github.Location = new System.Drawing.Point(61, 238);
            this.ll_github.Name = "ll_github";
            this.ll_github.Size = new System.Drawing.Size(36, 13);
            this.ll_github.TabIndex = 0;
            this.ll_github.TabStop = true;
            this.ll_github.Text = "github";
            this.ll_github.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_github_LinkClicked);
            // 
            // ll_arquivoWindows
            // 
            this.ll_arquivoWindows.AutoSize = true;
            this.ll_arquivoWindows.Location = new System.Drawing.Point(159, 238);
            this.ll_arquivoWindows.Name = "ll_arquivoWindows";
            this.ll_arquivoWindows.Size = new System.Drawing.Size(91, 13);
            this.ll_arquivoWindows.TabIndex = 1;
            this.ll_arquivoWindows.TabStop = true;
            this.ll_arquivoWindows.Text = "Programas Locais";
            this.ll_arquivoWindows.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_arquivoWindows_LinkClicked);
            // 
            // ll_Diversos
            // 
            this.ll_Diversos.AutoSize = true;
            this.ll_Diversos.Location = new System.Drawing.Point(311, 238);
            this.ll_Diversos.Name = "ll_Diversos";
            this.ll_Diversos.Size = new System.Drawing.Size(126, 13);
            this.ll_Diversos.TabIndex = 2;
            this.ll_Diversos.TabStop = true;
            this.ll_Diversos.Text = "Google - Canal - Youtube";
            this.ll_Diversos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_Diversos_LinkClicked);
            // 
            // F_LinkedLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ll_Diversos);
            this.Controls.Add(this.ll_arquivoWindows);
            this.Controls.Add(this.ll_github);
            this.Name = "F_LinkedLabel";
            this.Text = "LinkedLabel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel ll_github;
        private System.Windows.Forms.LinkLabel ll_arquivoWindows;
        private System.Windows.Forms.LinkLabel ll_Diversos;
    }
}