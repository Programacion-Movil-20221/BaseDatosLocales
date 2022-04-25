using BaseDeDatosLocales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BaseDeDatosLocales.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioPage : ContentPage
    {
        public FormularioPage()
        {
            InitializeComponent();
        }

        private async void Insertar(object sender, EventArgs e)
        {
            string nombre = txtnombre.Text;
            string apellido = txtapellido.Text;
            string edad = txtedad.Text;

            Persona persona = new Persona()
            {
                //Id = 0,
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad
            };
            try
            {
                int resul = await App.DataBase.Agregar(persona);

                if (resul != 0)
                {
                    await DisplayAlert("Insertar", "Exitoo", "Cerrar");
                    LimpiarEntrys();
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }



        }

        private async void Actualizar(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                Persona persona = new Persona()
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Nombre = txtnombre.Text,
                    Apellido = txtapellido.Text,
                    Edad = txtedad.Text,
                };
                await App.DataBase.Actualizar(persona);
                await DisplayAlert("Notificacion", "El usuario ha sido actualizado", "OK");
                LimpiarEntrys();
            }
        }

        private async void Eliminar(object sender, EventArgs e)
        {
            var person = await App.DataBase.GetPersonaByIdAsync((int)Convert.ToInt32(txtId.Text));

            if (person != null)
            {
                await App.DataBase.Eliminar(person);
                await DisplayAlert("Proceso de eliminación", "El usuario ha sido eliminado...", "OK");
                LimpiarEntrys();
            }
            else
            {
                await DisplayAlert("Aviso","Usuario no existe en la base de datos","OK");
                LimpiarEntrys();
            }


        }

        private async void BuscarUno(object sender, EventArgs e)
        {
            Persona persona = new Persona
            {
                Id = Convert.ToInt32(txtId.Text)
            };
            Persona personaEncontrada =  await App.DataBase.BuscarUno(persona);

            if (personaEncontrada != null)
            {
                txtnombre.Text = personaEncontrada.Nombre;
                txtapellido.Text = personaEncontrada.Apellido;
                txtedad.Text = personaEncontrada.Edad;
            }
            else
            {
                await DisplayAlert("Aviso", "Usuario no existe en la base de datos", "OK");
                LimpiarEntrys();
            }
            

        }
        
        private async void BuscarTodo(object sender, EventArgs e)
        {
            var _ListUsers = await App.DataBase.BuscarTodo();
            if (_ListUsers != null)
            {
                ListUsers.ItemsSource = _ListUsers;
            }
        }

        public void LimpiarEntrys()
        {
            txtId.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtedad.Text = "";
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = "";
            if (MainSearchBar.Text.Length == 1)
            {
                keyword = MainSearchBar.Text.ToUpperInvariant();
            }
            keyword = MainSearchBar.Text;
            ListUsers.ItemsSource = ListUsers.Where(name => name.Nombre.Contains(keyword));


        }
    }
    
}