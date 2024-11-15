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



    }
}
