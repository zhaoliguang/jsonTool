using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teachJson
{
    public class Choice : Base
    {
       private String questionType;
        private String speech;

        public String Speech
        {
            get { return speech; }
            set { speech = value; }
        }
        public String QuestionType
        {
            get { return questionType; }
            set { questionType = value; }
        }
        private String exciseName;

        public String ExciseName
        {
            get { return exciseName; }
            set { exciseName = value; }
        }


        private ImageItem answer;

        public ImageItem Answer
        {
            get { return answer; }
            set { answer = value; }
        }



        private ImageItem distractor;

        public ImageItem Distractor
        {
            get { return distractor; }
            set { distractor = value; }
        }

   




     public Choice()
        {
           
     
        }

    }
}
