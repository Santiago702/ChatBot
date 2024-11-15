using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using com.sun.tools.javac.parser;

namespace ChatBot
{
    public partial class ChatPrincipal : Form
    {
        public ChatPrincipal()
        {
            InitializeComponent();
            Chat('c', "Hola, soy tu asistente de registro de Nucleos Temáticos 😊.");
            Chat('c', "Dime, ¿Cómo puedo ayudarte hoy?");
        }

        private void enviar_Click(object sender, EventArgs e)
        {
            string entrada = usuario.Text;
            List<string> Tokens = Tokenizar(entrada);
            List<string> Lemas = Lematizar(Tokens);
            bool RegistrosTokens = (Tokens.Contains("registrar") || 
                Tokens.Contains("matricular") || 
                Tokens.Contains("inscribir") || 
                Tokens.Contains("añadir"));
            bool RegistrosLemas = (Lemas.Contains("registrar") || 
                Lemas.Contains("matricular") || 
                Lemas.Contains("inscribir") || 
                Lemas.Contains("añadir"));

            bool EliminacionTokens = (Tokens.Contains("retirar") || Tokens.Contains("eliminar") || Tokens.Contains("borrar") || Tokens.Contains("desmatricular") || Tokens.Contains("quitar"));
            bool EliminacionLemas = (Lemas.Contains("retirar") || Lemas.Contains("eliminar") || Lemas.Contains("borrar") || Lemas.Contains("desmatricular") || Lemas.Contains("quitar"));

            bool Errores = (RegistrosTokens && EliminacionTokens) || (RegistrosTokens && EliminacionTokens) || (RegistrosLemas && EliminacionTokens) || (RegistrosLemas && EliminacionTokens);


            Chat('u', entrada);

            if (Errores)
            {
                Chat('c', "Vale, vamos en orden, ¿Quieres primero inscribir o retirar?");
            }
            else if (RegistrosTokens || RegistrosLemas)
            {
                Chat('c', "Bien, ¡Vamos a registrar!");
            }
            else if (EliminacionTokens || EliminacionLemas) 
            {
                Chat('c', "Bien, ¡Vamos a retirar!");
            }
            else
            {
                Chat('c', "No entendí lo que dijiste, pero si tenes dudas te puedo ayudar con registrar o retirar materias");

            }
            
            usuario.Clear();
        }

        public void Chat(char sujeto,string text)
        {
            if(sujeto == 'u')
            {
                chatbot.AppendText("Tu: " + text + Environment.NewLine);
            }
            else if(sujeto == 'c')
            {
                chatbot.AppendText("chatbot: " + text + Environment.NewLine);
            }
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
        public static List<string> Lematizar(List<string> tokens)
        {
            // Diccionario simulado de lemas
            Dictionary<string, string> lemas = new Dictionary<string, string>
        {
            
            { "registro", "registrar" },
            { "matriculacion", "matricular" },
            { "inscripcion", "inscribir" },
            { "meter", "inscribir" },
            {"añadir","matricular" },// Eliminacion:
            { "retiro", "retirar" },
            { "eliminacion", "eliminar" },
            { "borre", "borrar" },
            { "sacar", "desmatricular" },
            {"quite","quitar" },
            { "elimine", "eliminar" }
            
            
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
