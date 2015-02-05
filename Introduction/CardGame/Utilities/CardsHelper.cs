using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Model;

namespace CardGame.Utilities
{
    public static class CardsHelper
    {
        //this is extension method
        public static void RpelcaCards(this ObservableCollection<CardData> collection, int index1, int index2)
        {

            if (collection.Count<=index1||collection.Count<=index2)return;

            var item1 = collection[index1];
            var item2 = collection[index2];
            SwapCards(item1, item2);


            collection.Move(index1, index2);
        }

        //this reference type so we can modify the variables
        public static void SwapCards(CardData item1, CardData item2)
        {

            var tempItem = (CardData)item1.Clone();

            item1 = (CardData)item2.Clone();
            item2 = (CardData)tempItem.Clone();
        }

    }
}
