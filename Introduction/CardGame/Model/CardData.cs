using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Model
{
   public class CardData
   {
       private string _text;

       public string Text
       {
           get { return _text; }
           set { _text = value; }
       }
   }
}
