using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseDeDatosLocales.Models
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }

    }
}
