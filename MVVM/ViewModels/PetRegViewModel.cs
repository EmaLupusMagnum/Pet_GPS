using PetGPS.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace PetGPS.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PetRegViewModel
    {
        public List<string> PetSex { get; set;} = new List<string>() {"Macho", "Hembra" };
        public Pet pet {  get; set; } = new Pet();
        public string PetName { get; set;}
        public string PetRace { get; set;}
        public string PetColors { get; set;}
        public string PetSexSelected { get; set;}
        public string PetDescription { get; set;}
        public string CheckPet(string name, string race, string colors, string description, string sex)
        {
            if (!CheckPetName(name))
                return "Debes poner un nombre y no puede contener numeros ni caracteres especiales";

            else if (!CheckPetRace(race))
                return "Debes poner una raza y no puede contener numeros ni caracteres especiales";

            else if (!CheckPetColors(colors))
                return "Los colores deben estar separados por comas y sin espacios Ejm: negro,cafe";

            else if (string.IsNullOrEmpty(sex))
                return "Debes seleccionar el sexo de tu mascota";

            else if (!CheckPetDescription(description))
                return "Debes agregar una descripcion y no puede contener numeros ni caracteres especiales";

            PetSexSelected = sex;
            return "Valid";
        }

        private bool CheckPetName(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;

            if (!Regex.IsMatch(name, "^[a-zA-Z ]+$")) return false;

            // Divide el nombre completo en nombre y apellido
            string[] splitedName = name.Split(' ');

            //Verifica que el nombre ni el apellido esten vacios
            string nombre = splitedName[0];

            // Corrige la primera letra del nombre a mayúscula
            nombre = char.ToUpper(nombre[0]) + nombre.Substring(1).ToLower();

            PetName = nombre;
            return true;
        }

        private bool CheckPetRace(string race)
        {
            if (string.IsNullOrEmpty(race)) return false;

            if (!Regex.IsMatch(race, "^[a-zA-Z ]+$")) return false;

            // Divide el nombre completo en nombre y apellido
            string[] splitedName = race.Split(' ');

            //Verifica que el nombre ni el apellido esten vacios
            string apellido = string.Empty;
            if (splitedName.Length > 1)
            {
                apellido = splitedName.Length > 1 ? splitedName[1] : "";
                // Corrige la primera letra del apellido a mayúscula
                apellido = char.ToUpper(apellido[0]) + apellido.Substring(1).ToLower();
            }

            string nombre = splitedName[0];

            // Corrige la primera letra del nombre a mayúscula
            nombre = char.ToUpper(nombre[0]) + nombre.Substring(1).ToLower();

            PetRace = nombre + " " + apellido;
            return true;
        }

        private bool CheckPetColors(string colors)
        {
            // Expresión regular para validar que la cadena contiene solo letras y comas
            string pattern = @"^[a-zA-Z,]*$";

            if (string.IsNullOrEmpty(colors)) return false;

            if (!Regex.IsMatch(colors, pattern)) return false;

            PetColors = colors;
            return true;
        }

        private bool CheckPetDescription(string description)
        {
            // Expresión regular para validar que la cadena contiene solo letras, comas, puntos, punto y comas, y espacios
            string pattern = @"^[a-zA-Z,.;\s]*$";

            if (string.IsNullOrEmpty(description)) return false;

            if (!Regex.IsMatch(description, pattern)) return false;

            PetDescription = description;
            return true;
        }

        public void SavePet()
        {
            pet.Name = PetName;
            pet.Description = PetDescription;
            pet.Colors = PetColors;
            pet.Sex = PetSexSelected;
            pet.Race = PetRace;

            App.PetRepo.SaveItem(pet);
            Debug.WriteLine("========" + App.PetRepo.StatusMessage);
        }

        public ICommand BackCommand =>
            new Command(() =>
            {
                Shell.Current.GoToAsync("..");
            });
    }
}
