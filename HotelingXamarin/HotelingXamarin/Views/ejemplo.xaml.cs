﻿using HotelingXamarin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelingXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ejemplo : ContentPage
    {
        public ejemplo()
        {
            InitializeComponent();
            this.usuario.Text = App.Locator.SessionService.Sesion.usuario.APELLIDOS;
            Console.WriteLine("eee");
        }
    }
}