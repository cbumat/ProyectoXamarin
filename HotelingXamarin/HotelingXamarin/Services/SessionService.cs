using HotelingXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelingXamarin.Services {
    public class SessionService {
        public Sesion Sesion { get; set; }
        //public Usuario Usuario { get; set; }
        //public String token { get; set; }

        public SessionService() {
            this.Sesion = new Sesion();
            //this.Usuario = new Usuario();
            //this.token = new string();
        }
    }
}
