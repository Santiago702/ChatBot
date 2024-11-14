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
            chatbot.AppendText("chatbot: Hola, soy tu asistente de registro de Nucleos Temáticos 😊." + Environment.NewLine);

            chatbot.AppendText("chatbot: Dime, ¿Cómo puedo ayudarte hoy?" + Environment.NewLine);
        }

        private void enviar_Click(object sender, EventArgs e)
        {
            /*
            // Obtén la entrada del usuario
            string entrada = usuario.Text;

            // Procesa la entrada (tokenización, etc.)
            List<string> Tokens = Tokenizar(entrada);

            // Agrega los resultados al final del TextBox de manera similar a un chat
            chatbot.AppendText("Usuario: " + entrada + Environment.NewLine);
            chatbot.AppendText("Chatbot: Palabras encontradas: ");

            for (int i = 0; i < Tokens.Count(); i++)
            {
                chatbot.AppendText(Tokens[i]);
                if (i < Tokens.Count - 1)
                {
                    chatbot.AppendText(", ");
                }
            }

            chatbot.AppendText(Environment.NewLine); // Añade un salto de línea extra para separar mensajes

            // Limpia el TextBox de entrada
            usuario.Clear();
            */
        }

        // Función de tokenización
        public static List<string> Tokenizar(string texto)
        {
            // Divide el texto por espacios y elimina signos de puntuación
            string[] tokens = Regex.Split(texto.ToLower(), "[^a-záéíóúñ]+", RegexOptions.CultureInvariant);
            List<string> resultado = new List<string>(tokens);
            resultado.RemoveAll(token => string.IsNullOrEmpty(token)); // Remueve elementos vacíos
            return resultado;
        }

        // Función de lematización (simplificada)
        public static List<string> Lemmatizar(List<string> tokens)
        {
            // Diccionario simulado de lemas
            Dictionary<string, string> lemas = new Dictionary<string, string>
        {
            { "corriendo", "correr" },
            { "comiendo", "comer" },
            { "estudiando", "estudiar" },
            { "niños", "niño" },
            { "ratones", "ratón" },
            // Agrega más lemas según sea necesario
        };

            List<string> resultado = new List<string>();
            foreach (string token in tokens)
            {
                if (lemas.ContainsKey(token))
                {
                    resultado.Add(lemas[token]); // Reemplaza por el lema
                }
                else
                {
                    resultado.Add(token); // Deja el token original si no hay lema
                }
            }
            return resultado;
        }

        // Función de stemming (simulada)
        public static List<string> Stemmatizar(List<string> tokens)
        {
            List<string> resultado = new List<string>();
            foreach (string token in tokens)
            {
                // Simulación simple de stemming
                string stem = token;
                if (token.EndsWith("ando") || token.EndsWith("iendo"))
                {
                    stem = token.Substring(0, token.Length - 4); // Elimina terminaciones de gerundios
                }
                else if (token.EndsWith("ción") || token.EndsWith("sión"))
                {
                    stem = token.Substring(0, token.Length - 3) + "r"; // Convierte "-ción"/"-sión" a "-r"
                }
                else if (token.EndsWith("es"))
                {
                    stem = token.Substring(0, token.Length - 2); // Elimina "-es"
                }
                resultado.Add(stem);
            }
            return resultado;
        }

    }
}
