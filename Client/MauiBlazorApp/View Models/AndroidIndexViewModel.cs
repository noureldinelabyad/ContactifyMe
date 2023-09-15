using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MauiBlazorApp.Models;
using MauiBlazorApp.Services;

namespace MauiBlazorApp.ViewModels
{
    public class AndroidIndexViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<PersonModel> personList;
        public ObservableCollection<PersonModel> PersonList
        {
            get => personList;
            set
            {
                if (personList != value)
                {
                    personList = value;
                    OnPropertyChanged(nameof(PersonList));
                }
            }
        }

        public AndroidIndexViewModel()
        {
            LoadPersonList();
        }

        private void LoadPersonList()
        {
            // Call your PersonService to get the list of persons and assign it to PersonList
            var personService = new PersonService(); // Create an instance of your service
            PersonList = new ObservableCollection<PersonModel>(personService.GetAllPersonsList().Result);
        }

        public void DisplayOption(PersonModel personDetail)
        {
            // Implement the logic to display options for a selected person
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
