using BaseDeDatosLocales.iOS.DependencyServiceIOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ObtenerRuta))]
namespace BaseDeDatosLocales.iOS.DependencyServiceIOS
{
   public class ObtenerRuta
    {
        public string GetRutaDB(string NameBD)
        {
            string docFolder =
                    Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder,NameBD);
        }
    }
}