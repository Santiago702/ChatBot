namespace ChatBot
{
    partial class ChatPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatPrincipal));
            this.usuario = new System.Windows.Forms.TextBox();
            this.chatbot = new System.Windows.Forms.TextBox();
            this.enviar = new System.Windows.Forms.Button();
            this.textoCreditos = new System.Windows.Forms.Label();
            this.creditosRestantes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(84, 361);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(495, 26);
            this.usuario.TabIndex = 0;
            // 
            // chatbot
            // 
            this.chatbot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatbot.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatbot.Location = new System.Drawing.Point(43, 60);
            this.chatbot.Multiline = true;
            this.chatbot.Name = "chatbot";
            this.chatbot.ReadOnly = true;
            this.chatbot.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatbot.Size = new System.Drawing.Size(688, 280);
            this.chatbot.TabIndex = 1;
            // 
            // enviar
            // 
            this.enviar.FlatAppearance.BorderSize = 2;
            this.enviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enviar.Font = new System.Drawing.Font("Century Gothic", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar.Location = new System.Drawing.Point(603, 356);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(128, 37);
            this.enviar.TabIndex = 2;
            this.enviar.Text = "Enviar";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // textoCreditos
            // 
            this.textoCreditos.AutoSize = true;
            this.textoCreditos.Font = new System.Drawing.Font("Century Gothic", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoCreditos.Location = new System.Drawing.Point(39, 25);
            this.textoCreditos.Name = "textoCreditos";
            this.textoCreditos.Size = new System.Drawing.Size(78, 21);
            this.textoCreditos.TabIndex = 3;
            this.textoCreditos.Text = "Creditos:";
            // 
            // creditosRestantes
            // 
            this.creditosRestantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.creditosRestantes.Location = new System.Drawing.Point(135, 26);
            this.creditosRestantes.Name = "creditosRestantes";
            this.creditosRestantes.ReadOnly = true;
            this.creditosRestantes.Size = new System.Drawing.Size(59, 19);
            this.creditosRestantes.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tú:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ChatPrincipal
            // 
            this.AcceptButton = this.enviar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(756, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.creditosRestantes);
            this.Controls.Add(this.textoCreditos);
            this.Controls.Add(this.enviar);
            this.Controls.Add(this.chatbot);
            this.Controls.Add(this.usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChatPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistente de Registro de Horario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox usuario;
        public System.Windows.Forms.TextBox chatbot;
        private System.Windows.Forms.Button enviar;
        public System.Windows.Forms.Label textoCreditos;
        public System.Windows.Forms.TextBox creditosRestantes;
        private System.Windows.Forms.Label label1;
    }
}

