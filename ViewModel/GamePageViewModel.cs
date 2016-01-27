using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraMemory.ViewModel
{
    public class GamePageViewModel : ViewModelBase
    {
        public int Level { get { return _level; } set { _level = value; RaisePropertyChanged("Level"); } }
        public int Points { get { return _points; } set { _points = value; RaisePropertyChanged("Points"); } }

        private int _level=1;
        private int _points=0;
    }
}
