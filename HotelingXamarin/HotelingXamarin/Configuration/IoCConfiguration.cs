using Autofac;
using HotelingXamarin.Services;
using HotelingXamarin.ViewModels;
using HotelingXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelingXamarin.Configuration
{
    public class IoCConfiguration
    {
        private IContainer container;

        public IoCConfiguration() {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<SessionService>().SingleInstance();
            builder.RegisterType<PrincipalMaster>();
            builder.RegisterType<Login>();
            builder.RegisterType<Registro>();
            builder.RegisterType<MiPerfil>();
            builder.RegisterType<MisReservas>();
            builder.RegisterType<ReservasViewModel>();
            builder.RegisterType<UsuarioViewModel>();
            this.container = builder.Build();
        }
        public Registro Registro
        {
            get
            {
                return this.container.Resolve<Registro>();
            }
        }

        public Login Login
        {
            get {
                return this.container.Resolve<Login>();
            }
        }

        public SessionService SessionService {
            get {
                return this.container.Resolve<SessionService>();
            }
        }

        public PrincipalMaster PrincipalMaster
        {
            get
            {
                return this.container.Resolve<PrincipalMaster>();
            }
        }

        public MiPerfil MiPerfil
        {
            get
            {
                return this.container.Resolve<MiPerfil>();
            }
        }

        public ReservasViewModel ReservasViewModel
        {
            get
            {
                return this.container.Resolve<ReservasViewModel>();
            }
        }

        public MisReservas MisReservas
        {
            get
            {
                return this.container.Resolve<MisReservas>();
            }
        }

        public UsuarioViewModel UsuarioViewModel
        {
            get
            {
                return this.container.Resolve<UsuarioViewModel>();
            }
        }
    }
}
