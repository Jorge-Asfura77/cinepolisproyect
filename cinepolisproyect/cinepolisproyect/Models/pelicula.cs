using System;
using System.Collections.Generic;
using System.Text;

namespace cinepolisproyect.Models
{
    /// <summary>
    /// Esta clase sirve para enviar datos entre ContentPage
    /// </summary>
    public class pelicula
    {
        public string IdCine { get; set; }
        public string IdPelicula { get; set; }
        public string Pelicula { get; set; }
        public string Imagepeli { get; set; }
        public string Fechapeli { get; set; }
        public string IdHorario { get; set; }
        public string Horario { get; set; }
        public string IdButaca { get; set; }
        public string ContButaca { get; set; }
        public string IdCombo { get; set; }
        public string RefrescoExtra { get; set; }
        public string asientosSelected { get; set; }
        public string totalpagar { get; set; }
        public string JsonButaca { get; set; }
    }
}
