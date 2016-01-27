using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace Photosort.ViewModel
{
    public class ChoosingViewModel : BindableBase
    {
        GestureRecognizer _gestureRecognizer = new GestureRecognizer();

        public ChoosingViewModel()
        {
            _gestureRecognizer.CrossSliding += OnCrossSlidingToAxe;
        }

        private void OnCrossSlidingToAxe(GestureRecognizer sender, CrossSlidingEventArgs args)
        {
            //args.CrossSlidingState == CrossSlidingState.Started;
        }
    }
}
