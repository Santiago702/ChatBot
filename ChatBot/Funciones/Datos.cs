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

        public estudiante eliminarMaterias(List<materia> materias, int id_estudiante)
        {
            using (ChatBotEntities cb = new ChatBotEntities())
            {
                // Obtener los IDs de las materias de la lista proporcionada
                var materiaIds = materias.Select(m => m.materia_id).ToList();
                int totalCreditos = materias.Sum(m => m.creditos);
                // Buscar el estudiante
                var estudiante = cb.estudiante.SingleOrDefault(e => e.estudiante_id == id_estudiante);

                if (estudiante != null)
                {
                    // Filtrar las inscripciones que coinciden con los materia_id y tienen estado "inscrito"
                    var materiasInscritas = cb.inscripcion
                                              .Where(inscripcion => inscripcion.estudiante_id == id_estudiante
                                                                    && inscripcion.estado == "inscrito"
                                                                    && materiaIds.Contains(inscripcion.materia_id))
                                              .ToList();

                    // Eliminar las inscripciones correspondientes
                    foreach (var inscripcion in materiasInscritas)
                    {
                        cb.inscripcion.Remove(inscripcion);
                    }
                    estudiante.creditos = estudiante.creditos + totalCreditos;
                    // Guardar los cambios en la base de datos
                    cb.SaveChanges();

                    return estudiante; // Devolver el objeto estudiante actualizado (si lo necesitas)
                }
                else
                {
                    Console.WriteLine("Estudiante no encontrado.");
                    return null;
                }
            }
        }








    }
}
