using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teachJson
{
    public class Trail
    {
        public Trail()
        {
            questions = new List<Base>();
         }
        private List<Base> questions;

        public List<Base> Questions
        {
            get { return questions; }
            set { questions = value; }
        }

      
       

    }
}
