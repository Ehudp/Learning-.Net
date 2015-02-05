using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CardGame.Model
{
    public class CardData : ViewModelBase, ICloneable
   {
       public CardData()
       {
           CardClickCommand = new RelayCommand<CardData>(OnCardClickCommand);
       }
       private string _text;

       public string Text
       {
           get { return _text; }
           set
           {
               _text = value;
               RaisePropertyChanged();
           }
       }

       public bool IsEmpy
       {
           get { return _isEmpy; }
           set { _isEmpy = value; 
               RaisePropertyChanged(); }
       }

       public ICommand CardClickCommand
       {
           get { return _cardClickCommand; }
           set { _cardClickCommand = value;
               RaisePropertyChanged(); }
       }

       public Point LocationInGrid
       {
           get { return _locationInGrid; }
           set
           {
               _locationInGrid = value;
               RaisePropertyChanged();
           }
       }

       public int IndexInCollection
       {
           get { return _indexInCollection; }
           set
           {
               _indexInCollection = value;
               RaisePropertyChanged();
           }
       }

       private int _indexInCollection;

       private bool _isEmpy;

       private ICommand _cardClickCommand;

       private Point _locationInGrid;

       private static void OnCardClickCommand(CardData card)
       {
           card.IsEmpy = true;
       }

        public object Clone()
        {
            var cardData= new CardData();

            cardData.Text = this.Text;
            cardData.IndexInCollection = this.IndexInCollection;
            cardData.LocationInGrid = this.LocationInGrid;
            cardData.IsEmpy = this.IsEmpy;

            return cardData;
        }
   }
}
