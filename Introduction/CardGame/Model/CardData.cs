using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CardGame.Model
{
   public class CardData:ViewModelBase
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

       private bool _isEmpy;

       private ICommand _cardClickCommand;

       private static void OnCardClickCommand(CardData card)
       {
           card.IsEmpy = true;
       }
   }
}
