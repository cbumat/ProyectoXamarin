using System;
using System.Collections.Generic;
using System.Text;

namespace HotelingXamarin.Models
{
    public class Usuario
    {
        public int ID_USUARIO { get; set; }
        public String NOMBRE { get; set; }
        public String APELLIDOS { get; set; }
        public String EMAIL { get; set; }
        public String CONTRASEÑA { get; set; }
        public DateTime FECHA_NACIMIENTO { get; set; }
        public String IMAGEN { get; set; }
        public String TELEFONO { get; set; }
        public String ROL { get; set; }
    }
}
