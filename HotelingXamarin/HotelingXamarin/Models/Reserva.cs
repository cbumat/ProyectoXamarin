using System;
using System.Collections.Generic;
using System.Text;

namespace HotelingXamarin.Models
{
    public class Reserva
    {
        public int ID_RESERVA { get; set; }
        public int ID_HABITACION { get; set; }
        public int ID_USUARIO { get; set; }
        public DateTime FECHA_LLEGADA { get; set; }
        public DateTime FECHA_SALIDA { get; set; }
        public String TIPO_ALOJAMIENTO { get; set; }
        public int ADULTOS { get; set; }
        public int NIÑOS { get; set; }
        public int PRECIO_TOTAL { get; set; }
        public String NOMBRE_HOTEL { get; set; }
        public int PRECIO_NOCHE { get; set; }
        public int DIAS { get; set; }
        public String FECHA { get; set; }
        public String NOMBRE { get; set; }
        public String APELLIDOS { get; set; }
        public String EMAIL { get; set; }
        public String TELEFONO { get; set; }
        public bool DESAYUNO { get; set; }
        public int HABITACIONES { get; set; }
        public String IMAGEN_HOTEL { get; set; }
    }
}
