using Microsoft.Practices.Prism.Mvvm;
using System.Collections.ObjectModel;
using System;
using Windows.Storage;
using Windows.UI.Input;
using Windows.UI.Xaml.Media.Imaging;
using Photosort.Model;
using Windows.Storage.Streams;
using System.Threading.Tasks;

namespace Photosort.ViewModel
{
    public class ChoosingViewModel : BindableBase
    {
        public ObservableCollection<PhotoDto> Images
        {
            get { return _images; }
            set { _images = value; SetProperty(ref _images, Images); }
        }

        public ChoosingViewModel(object folder)
        {
            _gestureRecognizer.CrossSliding += OnCrossSlidingToAxe;
            var storagefolder = folder as StorageFolder;
            if (storagefolder == null)
                return;
            LoadImagesFromDirectory(storagefolder);
        }

        private void OnCrossSlidingToAxe(GestureRecognizer sender, CrossSlidingEventArgs args)
        {
            //args.CrossSlidingState == CrossSlidingState.Started;
        }

        private async Task<BitmapImage> LoadImage(StorageFile file)
        {
            var image  = new BitmapImage();
            FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.Read);
            image.SetSource(stream);
            return image;
        }

        private async void LoadImagesFromDirectory(StorageFolder imagesdirectory)
        {
            Images.Clear();
            var files = await imagesdirectory.GetFilesAsync();
            foreach (var file in files)
            {
                Images.Add(new PhotoDto
                {
                    ID = Guid.NewGuid(),
                    Image = await LoadImage(file)
                });
                    
            }
        }

        private GestureRecognizer _gestureRecognizer = new GestureRecognizer();
        private ObservableCollection<PhotoDto> _images = new ObservableCollection<PhotoDto>();
    }
}
