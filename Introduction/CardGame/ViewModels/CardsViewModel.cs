using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using CardGame.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CardGame.ViewModels
{
    public class CardsViewModel : ViewModelBase
    {

        public CardsViewModel()
        {
            CardsCollection = new ObservableCollection<CardData>();
            StartCommand = new RelayCommand<object>(OnStartCommand);
        }

        private void OnStartCommand(object count)
        {
            int rows = 0;
            if (count != null &&
                int.TryParse(count.ToString(), out rows))
            {
                Rows = rows;
                InitCards();
            }
        }

        private ObservableCollection<CardData> _cardsCollection;

        private ICommand _startCommand;

        public ICommand StartCommand
        {
            get { return _startCommand; }
            set
            {
                _startCommand = value;
                RaisePropertyChanged(() => StartCommand);
            }
        }

        public int Rows
        {
            get { return _rows; }
            set
            {
                _rows = value;
                RaisePropertyChanged(() => Rows);
            }
        }

        public ObservableCollection<CardData> CardsCollection
        {
            get { return _cardsCollection; }
            set
            {
                _cardsCollection = value;
                RaisePropertyChanged(() => Rows);
            }
        }

        private int _rows;

        private void InitCards()
        {
            ObservableCollection<CardData> cards = new ObservableCollection<CardData>();

            for (int i = 0; i < Rows; i++)
            {
                var tempCard = new CardData { Text = i.ToString() };
                cards.Add(tempCard);
            }
            CardsCollection = cards;
        }

    }
}
