using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatBot.Modelos;

namespace ChatBot.Funciones
{
    internal class Datos
    {
        public List<materia> obtenerMaterias(int estudianteId)
        {
            using (ChatBotEntities cb = new ChatBotEntities())
            {
                var materiasNoVistas = from materia in cb.materia
                                       where !(from inscripcion in cb.inscripcion
                                               where inscripcion.estudiante_id == estudianteId
                                               select inscripcion.materia_id).Contains(materia.materia_id)
                                       &&
                                       // Verificar si la materia tiene un prerrequisito y si el estudiante lo ha visto
                                       (materia.prerrequisito == null ||
                                        (from inscripcion in cb.inscripcion
                                         where inscripcion.estudiante_id == estudianteId
                                         select inscripcion.materia_id)
                                         .Contains(
                                             (from m in cb.materia
                                              where m.nombre == materia.prerrequisito
                                              select m.materia_id).FirstOrDefault()
                                         )
                                       )
                                       select materia;

                return materiasNoVistas.ToList();
            }
        }

        public estudiante registrarMaterias( List<materia> materias , int id_estudiante)
        {
            using(ChatBotEntities cb = new ChatBotEntities())
            {
                int credAMatricular = 0;
                
                var estudiante = cb.estudiante.SingleOrDefault(e => e.estudiante_id == id_estudiante);
                int totalCreditos = materias.Sum(m => m.creditos);

                if(estudiante.creditos >= credAMatricular)
                {
                    foreach(var materia in materias)
                    {
                        inscripcion i = new inscripcion();
                        i.materia_id = materia.materia_id;
                        i.estudiante_id = id_estudiante;
                        i.estado = "inscrito";
                        cb.inscripcion.Add(i);
                    }
                    estudiante.creditos = estudiante.creditos - totalCreditos;
                    cb.SaveChanges();
                }
                return estudiante;
            }
        }

        public List<materia> verInscripciones(int id)
        {
            using (ChatBotEntities cb = new ChatBotEntities())
            {
                // Consultar las materias inscritas por el estudiante
                var materiasInscritas = from inscripcion in cb.inscripcion
                                        join materia in cb.materia on inscripcion.materia_id equals materia.materia_id
                                        where inscripcion.estudiante_id == id && inscripcion.estado == "inscrito"
                                        select materia;

                return materiasInscritas.ToList();
            }
            
        }

        



    }
}
