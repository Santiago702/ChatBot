using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatBot.Funciones
{
    internal class Funcion
    {
        public List<string> Tokenizado(string texto)
        {
            // Divide el texto por espacios y elimina signos de puntuación
            string[] tokens = Regex.Split(texto.ToLower(), "[^a-záéíóúñ.@]+", RegexOptions.CultureInvariant);
            List<string> resultado = new List<string>(tokens);
            resultado.RemoveAll(token => string.IsNullOrEmpty(token)); // Remueve elementos vacíos
            return resultado;
        }

        public List<string> Lematizado(List<string> tokens)
        {
            // Diccionario simulado de lemas
            Dictionary<string, string> lemas = new Dictionary<string, string>
        {

            { "registro", "registrar" },
            { "matriculacion", "matricular" },
            { "inscripcion", "inscribir" },
            { "meter", "inscribir" },
            {"añadir","matricular" },
            {"agregar","matricular" },
            {"agregando","matricular" },
            // Eliminacion:
            { "retiro", "retirar" },
            { "eliminacion", "eliminar" },
            { "borre", "borrar" },
            { "sacar", "desmatricular" },
            {"quite","quitar" },
            { "elimine", "eliminar" },
            { "eliminando", "eliminar" },
            //Confirmación:
            { "afirmativo", "si" },
            { "correcto", "si" },
            { "cierto", "si" },
            { "si", "si" },
            {"exacto","si" },
            { "bien", "si" },
            //Negación:
            { "Negativo", "no" },
            { "incorrecto", "no" },
            { "erroneo", "no" },
            { "no", "no" },
            {"mal","no" },
            { "nada", "no" },
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

        public List<string> Stematizado(List<string> tokens)
        {
            List<string> resultado = new List<string>();
            foreach (string token in tokens)
            {
                // Simulación simple de stemming
                string stem = token;
                if (token.EndsWith("ando"))
                {
                    stem = token.Substring(0, token.Length - 4) + "ar"; 
                }
                else if (token.EndsWith("iendo"))
                {
                    stem = token.Substring(0, token.Length - 4) + "ir"; 
                }
                else if (token.EndsWith("ción") || token.EndsWith("sión"))
                {
                    stem = token.Substring(0, token.Length - 3) + "r"; // Convierte "-ción"/"-sión" a "-r"
                }
                else if (token.EndsWith("es"))
                {
                    stem = token.Substring(0, token.Length - 2); // Elimina "-es"
                }
                else if (token.EndsWith("aras"))
                {
                    stem = token.Substring(0, token.Length - 4) + "ar";
                }
                else if (token.EndsWith("eras"))
                {
                    stem = token.Substring(0, token.Length - 4) + "r";
                }
                resultado.Add(stem);
                
            }
            return resultado;
        }
    }
}
