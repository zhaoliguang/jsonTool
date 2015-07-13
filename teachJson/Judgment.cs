using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teachJson
{
    public class Judgment : Base
    {
        private String questionType;
        private String exciseName;
        private String speech;

        public String Speech
        {
            get { return speech; }
            set { speech = value; }
        }
        public Judgment()
        {
        
        }

        public String ExciseName
        {
            get { return exciseName; }
            set { exciseName = value; }
        }

        public String QuestionType
        {
            get { return questionType; }
            set { questionType = value; }
        }
        private ImageItem question;

        public ImageItem Question
        {
            get { return question; }
            set { question = value; }
        }

   
        private ImageItem distractor;

        public ImageItem Distractor
        {
            get { return distractor; }
            set { distractor = value; }
        }

     

    }
}
