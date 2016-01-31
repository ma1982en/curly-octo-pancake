using System;
using Windows.UI.Xaml.Media;

namespace Photosort.Model
{
    public class PhotoDto
    {
        public Guid ID { get; set; }
        public ImageSource Image { get; set; }
    }
}
