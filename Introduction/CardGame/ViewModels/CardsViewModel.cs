using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using CardGame.Model;
using CardGame.Utilities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CardGame.ViewModels
{
    public class CardsViewModel : ViewModelBase
    {

        #region Ctor

        public CardsViewModel()
        {
            _rnd = _rnd = new Random();
            Rows = 3;
            InitGame();

            StartCommand = new RelayCommand<object>(OnStartCommand);
        }

        #endregion

        #region DataMembers

        private Random _rnd;
 
        #endregion
    
        
        #region Properties
        
        private ObservableCollection<CardData> _cardsCollection;        
        public ObservableCollection<CardData> CardsCollection
        {
            get { return _cardsCollection; }
            set
            {
                _cardsCollection = value;
                RaisePropertyChanged(() => CardsCollection);
            }
        }
        
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

        private int _rows;
        public int Rows
        {
            get { return _rows; }
            set
            {
                _rows = value;
                RaisePropertyChanged(() => Rows);
            }
        }
        #endregion


        #region Methods
            
        private void OnStartCommand(object count)
        {
            int rows = 0;
            if (count != null &&
                int.TryParse(count.ToString(), out rows))
            {
                Rows = rows;
                InitGame();
            }
        }
      
        //Main Method For initialization the game
        private void InitGame()
        {
            InitCards();
            MixCards();
        }
        
        //Mix the cards on board Game
        private void MixCards()
        {

            for (int i = 0; i < _rnd.Next(100,1000); i++)
            {
                
                Tuple<int, int> indexes = GetIndexes(Rows*2);

                CardsCollection.RpelcaCards(indexes.Item1, indexes.Item2);
            }
         
        }

        //get pair of indexes to replace 
        public  Tuple<int, int> GetIndexes(int maxIndex)
        {
            Tuple<int, int> indexes = new Tuple<int, int>(0, 0);

            while (indexes.Item1== indexes.Item2)
            {
                indexes = Tuple.Create(_rnd.Next(maxIndex), _rnd.Next(maxIndex));
            }

            return indexes;
        }

        //initialization the cards collection
        private void InitCards()
        {
            if (Rows==0)return;
         
            List<CardData> cards = new List<CardData>();
            int index = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Rows; j++)
                {

                    var tempCard = new CardData
                    {
                        Text = (1 + index).ToString(),
                        IndexInCollection = index,
                        LocationInGrid = new Point(i, j)
                    };
                    cards.Add(tempCard);
                    index++;
                }
            }

            var lastOrDefault = cards.LastOrDefault();
            if (lastOrDefault != null)
            {
                lastOrDefault.Text = string.Empty;
                lastOrDefault.IsEmpy = true;
            }

            CardsCollection = new ObservableCollection<CardData>(cards);
        }
  
        #endregion

    }
}
