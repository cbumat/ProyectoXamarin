using Autofac;
using HotelingXamarin.Services;
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
    }
}
