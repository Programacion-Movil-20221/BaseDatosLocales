using BaseDeDatosLocales.Data;
using BaseDeDatosLocales.Dependency;
using BaseDeDatosLocales.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BaseDeDatosLocales
{
    public partial class App : Application
    {
        private static PersonasDatabase database;

        public static PersonasDatabase DataBase
        {
            get
            {
                if (database == null)
                {
                    return database = new PersonasDatabase(DependencyService.Get<IGetRuta>()
                                                           .GetRutaDB("BaseDato20222.db3"));
                }
                else
                {
                    return database;
                }
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new FormularioPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
