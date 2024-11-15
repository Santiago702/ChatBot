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
            this.SuspendLayout();
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(43, 361);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(536, 26);
            this.usuario.TabIndex = 0;
            // 
            // chatbot
            // 
            this.chatbot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatbot.Location = new System.Drawing.Point(43, 50);
            this.chatbot.Multiline = true;
            this.chatbot.Name = "chatbot";
            this.chatbot.Size = new System.Drawing.Size(688, 290);
            this.chatbot.TabIndex = 1;
            // 
            // enviar
            // 
            this.enviar.Location = new System.Drawing.Point(603, 356);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(128, 37);
            this.enviar.TabIndex = 2;
            this.enviar.Text = "Enviar";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // ChatPrincipal
            // 
            this.AcceptButton = this.enviar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 415);
            this.Controls.Add(this.enviar);
            this.Controls.Add(this.chatbot);
            this.Controls.Add(this.usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}

