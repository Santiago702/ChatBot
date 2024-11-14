using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChatBot
{
    public partial class ChatPrincipal : Form
    {
        public ChatPrincipal()
        {
            InitializeComponent();
        }

        private void enviar_Click(object sender, EventArgs e)
        {

            // Obtener la entrada del usuario desde el TextBox 'usuario'
            string entradaUsuario = usuario.Text;

            // Realizar la tokenización y stemming
            List<string> tokens = TokenizarTexto(entradaUsuario);
            List<string> stemmedTokens = StemTokens(tokens);

            // Mostrar los resultados en el TextBox 'chatbot'
            chatbot.AppendText($"Entrada del usuario: {entradaUsuario}\n");
            chatbot.AppendText("Tokens generados: " + string.Join(", ", tokens) + "\n");
            chatbot.AppendText("Tokens procesados (Stemming): " + string.Join(", ", stemmedTokens) + "\n\n");
        }

        // Método para tokenizar el texto
        private List<string> TokenizarTexto(string texto)
        {
            // Convertir a minúsculas y dividir el texto en palabras
            return Regex.Split(texto.ToLower(), "\\W+").Where(t => !string.IsNullOrEmpty(t)).ToList();
        }

        // Método para realizar stemming en los tokens
        private List<string> StemTokens(List<string> tokens)
        {
            // Simular un proceso de stemming básico (usar librerías como SnowballStemmer en proyectos más avanzados)
            List<string> stemmed = new List<string>();
            foreach (var token in tokens)
            {
                // Simulación de un stemming simple eliminando sufijos comunes
                if (token.EndsWith("ing"))
                {
                    stemmed.Add(token.Substring(0, token.Length - 3));
                }
                else if (token.EndsWith("ed"))
                {
                    stemmed.Add(token.Substring(0, token.Length - 2));
                }
                else
                {
                    stemmed.Add(token);
                }
            }
            return stemmed;
        }
    }
}
