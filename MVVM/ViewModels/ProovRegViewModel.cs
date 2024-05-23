using PetGPS.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PetGPS.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProovRegViewModel
    {
        public ObservableCollection<Pet> Pets { get; set; }
        public ObservableCollection<string> Services { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ServiceType { get; set; }

        public ProovRegViewModel()
        {
            updateData();
        }

        public void updateData()
        {
            Pets = new ObservableCollection<Pet>(App.PetRepo.GetItems());
            Services = new ObservableCollection<string>()
            {
                "Paseador",
                "Ciudador",
                "Entrenador"
            };
        }
        public string AllChecked(string name, string pass, string email, string phone, List<string> services)
        {
            if (!CheckName(name))
                return "Debes poner un nombre y un apellido, este no debe contenr caracteres especiales ni numeros" +
                        " ademas debe estar escrito asi: Fulano Lopez";
            if (!CheckPassword(pass))
                return "Debes poner una contraseña y esta debe ser minimo de 8 caracteres y tener simbolos y letras mayusculas";

            if (!CheckEmail(email))
                return "Debes poner un email valido";

            if (!CheckPhone(phone))
                return "Debes poner un telefono valido con el prefijo de tu pais Ejem: +57";

            if (services.Count() <= 0)
                return "Debes seleccionar al menos un tipo de servicio";

            Password = pass;
            Email = email;
            Phone = phone;
            ServiceType = String.Join(",", services);

            return "Valid";
        }

        private bool CheckPhone(string phone)
        {
            // Expresión regular para validar el número de teléfono
            string telefonoPattern = @"^\+(?:[0-9] ?){6,14}[0-9]$";

            // Verifica si el número de teléfono coincide con el patrón de la expresión regular
            if (string.IsNullOrEmpty(phone) ||
                !Regex.IsMatch(phone, telefonoPattern))
                return false;

            return true;
        }

        private bool CheckEmail(string email)
        {
            // Expresión regular para validar la dirección de correo electrónico
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Verifica si el email coincide con el patrón de la expresión regular
            if (string.IsNullOrEmpty(email) ||
                !Regex.IsMatch(email, emailPattern))
                return false;

            return true;
        }
        private bool CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password) ||
                password.Length < 8 ||
                !Regex.IsMatch(password, "(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}"))
                return false;
            return true;
        }

        private bool CheckName(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;

            if (!Regex.IsMatch(name, "^[a-zA-Z ]+$")) return false;

            // Divide el nombre completo en nombre y apellido
            string[] splitedName = name.Split(' ');

            //Verifica que el nombre ni el apellido esten vacios
            if (splitedName.Length < 2)
                return false;

            string nombre = splitedName[0];
            string apellido = splitedName.Length > 1 ? splitedName[1] : "";

            // Corrige la primera letra del nombre a mayúscula
            nombre = char.ToUpper(nombre[0]) + nombre.Substring(1).ToLower();

            // Corrige la primera letra del apellido a mayúscula
            apellido = char.ToUpper(apellido[0]) + apellido.Substring(1).ToLower();

            Name = nombre + " " + apellido;
            return true;
        }

        public void SaveData()
        {
            Provider provider = new Provider()
            {
                Name = Name,
                Password = Password,
                Email = Email,
                Phone = Phone,
                ServiceType = ServiceType,
                Calification = 0,
                NumbOfCalifications = 0,
            };
            

            App.ProvRepo.SaveItem(provider);

            foreach (var pet in Pets)
            {
                pet.OwnerId = provider.Id;
                App.PetRepo.SaveItem(pet);
            }

            Debug.WriteLine("==========" + App.ProvRepo.StatusMessage);
            Debug.WriteLine("==========" + App.ProvRepo.GetItems().FirstOrDefault().Id);
        }
    }
}
