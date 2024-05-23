using PetGPS.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PetGPS.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProovidersViewModel
    {
        public ObservableCollection<string> Filtros { get; set; }
        public ObservableCollection<Provider> Prooviders { get; set; }

        public ProovidersViewModel()
        {
            updateData();
        }

        public void updateData()
        {
            Filtros = new ObservableCollection<string>
            {
                "Paseador",
                "Cuidador",
                "Entrenador",
            };


            Prooviders = new ObservableCollection<Provider>
            {
                new Provider 
                {
                    Name = "Juan Montoya",
                    Password = "ValidPass23*",
                    Email = "juanMon45@gmail.com",
                    Phone = "+573056787543",
                    NumbOfCalifications = 2,
                    Calification = 6,
                    ServiceType = "Paseador"
                },

                new Provider
                {
                    Name = "Francisco Mesa",
                    Password = "ValidPass23*",
                    Email = "FranelniñoMesa67@gmail.com",
                    Phone = "+573006745657",
                    NumbOfCalifications = 10,
                    Calification = 50,
                    ServiceType = "Cuidador,Entrenador"
                }
            };

            var providers = App.ProvRepo.GetItems();
            foreach (var prov in providers)
            {
                Prooviders.Add(prov);
            }
        }
    }
}
