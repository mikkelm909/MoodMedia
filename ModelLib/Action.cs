using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class Action
    {
        public string Url { get; set; }
        public string Button { get; set; }

        public Action()
        {

        }

        public Action(string url, string button)
        {
            Url = url;
            Button = button;
        }

        public override string ToString()
        {
            return $"{Button} clicked on {Url}";
        }

        public override bool Equals(object obj)
        {
            return obj is Action action &&
                   Url == action.Url &&
                   Button == action.Button;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Url, Button);
        }
    }
}
