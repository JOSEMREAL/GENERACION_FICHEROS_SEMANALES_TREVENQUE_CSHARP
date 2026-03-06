namespace TREVENQUE
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            cboSemanas = new ComboBox();
            cboEmpresa = new ComboBox();
            btngenerar = new Button();
            btnsalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(32, 19);
            label1.Name = "label1";
            label1.Size = new Size(267, 20);
            label1.TabIndex = 0;
            label1.Text = "SELECCION DE SEMANA A GENERAR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(394, 19);
            label2.Name = "label2";
            label2.Size = new Size(278, 20);
            label2.TabIndex = 0;
            label2.Text = "SELECCION DE EMPRESA A EXPORTAR";
            // 
            // cboSemanas
            // 
            cboSemanas.FormattingEnabled = true;
            cboSemanas.Location = new Point(32, 73);
            cboSemanas.Name = "cboSemanas";
            cboSemanas.Size = new Size(212, 23);
            cboSemanas.TabIndex = 1;
            // 
            // cboEmpresa
            // 
            cboEmpresa.FormattingEnabled = true;
            cboEmpresa.Location = new Point(394, 73);
            cboEmpresa.Name = "cboEmpresa";
            cboEmpresa.Size = new Size(212, 23);
            cboEmpresa.TabIndex = 1;
            // 
            // btngenerar
            // 
            btngenerar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btngenerar.Location = new Point(89, 252);
            btngenerar.Name = "btngenerar";
            btngenerar.Size = new Size(216, 50);
            btngenerar.TabIndex = 2;
            btngenerar.Text = "GENERAR";
            btngenerar.UseVisualStyleBackColor = true;
            btngenerar.Click += btngenerar_Click;
            // 
            // btnsalir
            // 
            btnsalir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnsalir.Location = new Point(394, 252);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(216, 50);
            btnsalir.TabIndex = 2;
            btnsalir.Text = "SALIR";
            btnsalir.UseVisualStyleBackColor = true;
            btnsalir.Click += btnsalir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnsalir);
            Controls.Add(btngenerar);
            Controls.Add(cboEmpresa);
            Controls.Add(cboSemanas);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cboSemanas;
        private ComboBox cboEmpresa;
        private Button btngenerar;
        private Button btnsalir;
    }
}
