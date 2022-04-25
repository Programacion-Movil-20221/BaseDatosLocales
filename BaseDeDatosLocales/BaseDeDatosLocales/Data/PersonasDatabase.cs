using BaseDeDatosLocales.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatosLocales.Data
{
    public class PersonasDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public PersonasDatabase(string rutaBD)
        {
            database = new SQLiteAsyncConnection(rutaBD);
            database.CreateTableAsync<Persona>().Wait();
        }

        public Task<int> Agregar(Persona persona)
        {
            return database.InsertAsync(persona);
        }

        public Task<int> Actualizar(Persona persona)
        {
            return database.UpdateAsync(persona);
        }

        public Task<int> Eliminar(Persona persona)
        {
            return database.DeleteAsync(persona);
        }

        public Task<Persona> BuscarUno(Persona persona)
        {
            return database .Table<Persona>()
                            .Where(x => x.Id == persona.Id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Persona>> BuscarTodo()
        {
            return database.Table<Persona>().ToListAsync();
        }
        

        public Task<Persona> GetPersonaByIdAsync(int _id)
        {
            return database.Table<Persona>().Where(x => x.Id == _id).FirstOrDefaultAsync(); 
        }
    }
}
