﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using com.sun.tools.javac.parser;
using ChatBot.Funciones;
using com.sun.org.apache.xml.@internal.resolver.helpers;
using ChatBot.Modelos;
using System.Resources;

namespace ChatBot
{
    public partial class ChatPrincipal : Form
    {
        Funcion f = new Funcion();
        estudiante est = new estudiante();
        List<materia> mat = new List<materia>();
        Datos dt = new Datos(); 
        string posicionActual = "inicio";
        string posicionAnterior = "";
        string accion = "";

        List<materia> aInscribir = new List<materia>();
        public ChatPrincipal()
        {
            InitializeComponent();
            creditosRestantes.Visible = false;
            textoCreditos.Visible = false;  
            Chat('c', "Hola, soy tu asistente de registro de Nucleos Temáticos 😊.");
            Chat('c', "Dime, ¿Cómo puedo ayudarte hoy?");
        }

        private void enviar_Click(object sender, EventArgs e)
        {
            
            string entrada = usuario.Text;
            List<string> Tokens = f.Tokenizado(entrada);
            List<string> Lemas = f.Lematizado(Tokens);
            bool RegistrosTokens = (Tokens.Contains("registrar") || Tokens.Contains("matricular") || Tokens.Contains("inscribir") || Tokens.Contains("añadir"));
            bool RegistrosLemas = (Lemas.Contains("registrar") || Lemas.Contains("matricular") || Lemas.Contains("inscribir") || Lemas.Contains("añadir"));

            bool EliminacionTokens = (Tokens.Contains("retirar") || Tokens.Contains("eliminar") || Tokens.Contains("borrar") || Tokens.Contains("desmatricular") || Tokens.Contains("quitar"));
            bool EliminacionLemas = (Lemas.Contains("retirar") || Lemas.Contains("eliminar") || Lemas.Contains("borrar") || Lemas.Contains("desmatricular") || Lemas.Contains("quitar"));

            bool Errores = (RegistrosTokens && EliminacionTokens) || (RegistrosTokens && EliminacionTokens) || (RegistrosLemas && EliminacionTokens) || (RegistrosLemas && EliminacionTokens);


            
            string[] lineas = usuario.Lines;
            string ultimaLinea = lineas[lineas.Length - 1];
            if (posicionActual == "inicio")
            {
                if (Errores)
                {
                    Chat('u', entrada);
                    Chat('c', "Vale, vamos en orden, ¿Quieres primero inscribir o retirar?");
                }
                else if (RegistrosTokens || RegistrosLemas)
                {
                    Chat('u', entrada);
                    Chat('c', "Bien, ¡Vamos a registrar!");
                    accion = "registro";
                    posicionAnterior = posicionActual;
                    posicionActual = "inicioSesion";
                    Chat('c', "dime, ¿Cuál es tu correo electronico?");

                }
                else if (EliminacionTokens || EliminacionLemas)
                {
                    Chat('u', entrada);
                    Chat('c', "Bien, ¡Vamos a retirar!");
                    accion = "eliminar";
                    posicionAnterior = posicionActual;
                    posicionActual = "inicioSesion";
                    Chat('c', "dime, ¿Cuál es tu correo electronico?");
                }
                else
                {
                    Chat('u', entrada);
                    Chat('c', "No entendí, pero si tenes dudas te puedo ayudar con registrar o retirar materias");
                    posicionAnterior = posicionActual;
                    posicionActual = "inicio";
                }
            }
            else if (posicionActual == "inicioSesion")
            {

                using (ChatBotEntities cb = new ChatBotEntities())
                {
                    List<string> Correos = cb.estudiante.Select(c => c.correo).ToList();
                    string correoEntrada = Tokens.Where(token => token.Contains('@')).ToList().First();

                    if (Correos.Contains(correoEntrada))
                    {
                        Chat('u', entrada);
                        var estudiante = cb.estudiante.Where(c => c.correo.Equals(correoEntrada)).First();
                        est = estudiante;
                        
                        Chat('c', "Hola " + est.nombre.ToUpper() + ", Por favor ingresa tu contraseña");
                        usuario.PasswordChar = '*';
                        posicionAnterior = posicionActual;
                        posicionActual = "contraseña";
                    }
                    else
                    {
                        Chat('u', entrada);
                        Chat('c', "No encontré ese correo, ¿puedes volver a ingresarlo?");
                    }

                }
            }
            else if(posicionActual == "contraseña")
            {
                Chat('u', "*****");
                
                if(entrada.Equals(est.contraseña.ToString()))
                {
                    creditosRestantes.Visible = true;
                    textoCreditos.Visible = true;

                    creditosRestantes.Text = est.creditos.ToString();  

                    Chat('c', "Todo listo");
                    
                    usuario.PasswordChar = '\0';
                    if (accion == "registro")
                    {
                        if(est.creditos == 0)
                        {
                            Chat('c', "Al parecer ya tienes registrado todos tus creditos");
                            Chat('c', "¿Deseas salir o quieres eliminar alguna materia?");
                            posicionAnterior = posicionActual;
                            posicionActual = "inicio";
                        }
                        else
                        {
                            Chat('c', "Las materias que puedes registrar son: ");
                            List<materia> Materias = dt.obtenerMaterias(est.estudiante_id);
                            mat = Materias;
                            foreach (var materia in Materias)
                            {
                                Chat('c', " - " + materia.nombre.ToString());
                            }
                            Chat('c', "¿Cuál deseas inscribir?");
                            posicionAnterior = posicionActual;
                            posicionActual = "inscripcion";
                        }
                    }
                    else if (accion == "eliminar")
                    {

                    }

                }
                else
                {
                    Chat('c', "Contraseña incorrecta, vuelve a ingresarla porfavor:");
                    
                }
            }
            else if (posicionActual == "inscripcion")
            {
                Chat('u', entrada);
                foreach (var materia in mat)
                {
                    List<string> Tokenizadas = f.Tokenizado(materia.nombre.ToString());

                    bool todosContenidos = Tokenizadas.All(token => Tokens.Contains(token));

                    if (todosContenidos)
                    {
                        aInscribir.Add(materia);
                    }
                }
                if(aInscribir.Count > 0)
                {
                    Chat('c', "Entiendo que quieres inscribir la(s) siguiente(s) materia(s), ¿es correcto?: ");

                    foreach(var materia in aInscribir)
                    {
                        Chat('c', " - " + materia.nombre.ToString() +" : " + materia.creditos + " creditos.");
                    }
                    posicionAnterior = posicionActual;
                    posicionActual = "confirmarInscripcion";
                }
                else
                {
                    Chat('c', "No entendí cuál materia te interesa registrar, escribelo nuevamente: ");

                }
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

       





    }
}
