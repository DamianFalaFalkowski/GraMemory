using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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

        private int _level;
        private int _points;

        public RelayCommand MemoryStartCommand { get; private set; }
        public RelayCommand SpostrzegawczyStartCommand { get; private set; }
        public RelayCommand CyfryStartCommand { get; private set; }

        public GamePageViewModel()
        {
            MemoryStartCommand = new RelayCommand(MemoryStart);
            SpostrzegawczyStartCommand = new RelayCommand(SpostrzegawczyStart);
            CyfryStartCommand = new RelayCommand(CyfryStart);

            _level = 1;
            _points = 0;
        }

        private async void MemoryStart()
        {
            GameHandler.ResetHandler();
            GameHandler.GameType = GameType.memory;
            await GameHandler.StartMemoryGame(1);
        }

        private async void SpostrzegawczyStart() 
        {
            GameHandler.ResetHandler();
            GameHandler.GameType = GameType.colors;
            await GameHandler.StartColorGame(1);
            
        }
        private void CyfryStart() 
        {
            GameHandler.ResetHandler();
            GameHandler.GameType = GameType.number;
            GameHandler.StartNumbersGame(1);
        }
    }
}
