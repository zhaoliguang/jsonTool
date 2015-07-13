using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teachJson
{
    public class Learning :Base
    {

        private String questionType;
        private String pinYing;
        private String exciseName;
        private ImageItem question;
        private String speech;

        public String Speech
        {
            get { return speech; }
            set { speech = value; }
        }

        public ImageItem Question
        {
            get { return question; }
            set { question = value; }
        }

        public String ExciseName
        {
            get { return exciseName; }
            set { exciseName = value; }
        }

        public String PinYing
        {
            get { return pinYing; }
            set { pinYing = value; }
        }

        public String QuestionType
        {
            get { return questionType; }
            set { questionType = value; }
        }
        

      

     

    }
}
