using Android.App;
using Android.Content;

using Android.Runtime;
using Android.Views;
using Android.Widget;
using BaseDeDatosLocales.Dependency;
using BaseDeDatosLocales.Droid.DependencyServiceAndroid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Xamarin.Forms;

[assembly:Dependency(typeof(ObtenerRuta))]
namespace BaseDeDatosLocales.Droid.DependencyServiceAndroid
{
   
    public class ObtenerRuta : IGetRuta
    {
        public string GetRutaDB(string NameBD)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
           
            return Path.Combine(ruta, NameBD);

            //return ruta;
        }
    }
}