using CommonCode.Models;
using MauiBlazorApp.ViewModels;
using MauiBlazorApp.Models;
using MauiBlazorApp.Services;

namespace MauiBlazorApp.Pages
{
    public partial class AndroidIndex : ContentPage
    {
        AndroidIndexViewModel viewModel;
        public AndroidIndex()
        {
            InitializeComponent();
            BindingContext = new AndroidIndexViewModel();
            BindingContext = viewModel;

        }

        private void HandleSearch(object sender, EventArgs e)
        {
            var viewModel = (AndroidIndexViewModel)BindingContext;
            //viewModel.PerformSearch();
        }

        private void HandleSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedperson = (Models.PersonModel)e.CurrentSelection.FirstOrDefault();
            if (selectedperson != null)
            {
                var viewmodel = (AndroidIndexViewModel)BindingContext;
                viewmodel.DisplayOption(selectedperson);
            }
        }
    }
}
