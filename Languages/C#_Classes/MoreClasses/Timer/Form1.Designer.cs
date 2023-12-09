namespace Timer
{
    partial class F_Timer
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_Iniciar = new System.Windows.Forms.Button();
            this.btn_Parar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Recomeçar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_Iniciar
            // 
            this.btn_Iniciar.Location = new System.Drawing.Point(12, 337);
            this.btn_Iniciar.Name = "btn_Iniciar";
            this.btn_Iniciar.Size = new System.Drawing.Size(167, 34);
            this.btn_Iniciar.TabIndex = 0;
            this.btn_Iniciar.Text = "Iniciar";
            this.btn_Iniciar.UseVisualStyleBackColor = true;
            this.btn_Iniciar.Click += new System.EventHandler(this.btn_Iniciar_Click);
            // 
            // btn_Parar
            // 
            this.btn_Parar.Location = new System.Drawing.Point(621, 337);
            this.btn_Parar.Name = "btn_Parar";
            this.btn_Parar.Size = new System.Drawing.Size(167, 33);
            this.btn_Parar.TabIndex = 1;
            this.btn_Parar.Text = "Parar";
            this.btn_Parar.UseVisualStyleBackColor = true;
            this.btn_Parar.Click += new System.EventHandler(this.btn_Parar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.Location = new System.Drawing.Point(329, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "00:00";
            // 
            // btn_Recomeçar
            // 
            this.btn_Recomeçar.Location = new System.Drawing.Point(335, 337);
            this.btn_Recomeçar.Name = "btn_Recomeçar";
            this.btn_Recomeçar.Size = new System.Drawing.Size(114, 33);
            this.btn_Recomeçar.TabIndex = 3;
            this.btn_Recomeçar.Text = "Recomeçar";
            this.btn_Recomeçar.UseVisualStyleBackColor = true;
            this.btn_Recomeçar.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // F_Timer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Recomeçar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Parar);
            this.Controls.Add(this.btn_Iniciar);
            this.Name = "F_Timer";
            this.Text = "Timer";
            this.Load += new System.EventHandler(this.F_Timer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_Iniciar;
        private System.Windows.Forms.Button btn_Parar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Recomeçar;
    }
}

