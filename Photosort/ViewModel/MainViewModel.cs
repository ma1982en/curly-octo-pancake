using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using System;
using Windows.UI.Xaml.Controls;
using Photosort.View;

namespace Photosort.ViewModel
{
    public class MainViewModel : BindableBase
    {

        public ICommand AddTargetFolderCommand { get; set; }
        public ICommand GoToNextPage { get; set; }


        public string Sourcepath
        {
            get { return _sourcepath; }
            set { _sourcepath = value; SetProperty(ref _sourcepath, Sourcepath); }
        }

        public MainViewModel()
        {
            AddTargetFolderCommand = new DelegateCommand(ExecuteMethode);
            GoToNextPage = new DelegateCommand(OnGoToNextPage);
        }

        private async void ExecuteMethode()
        {
            var folderPicker = new FolderPicker();
            folderPicker.FileTypeFilter.Add(".jpg");
            folderPicker.ViewMode = PickerViewMode.Thumbnail;
            folderPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            folderPicker.SettingsIdentifier = "FolderPicker";

            var folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
            }

        }

        private void OnGoToNextPage()
        {
            //Implement Navigationservice
            ((Frame)Window.Current.Content).Navigate(typeof(ChoosingPage));
        }

        string _sourcepath;

    }
}
