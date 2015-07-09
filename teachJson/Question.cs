using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teachJson
{
    public class Question
    {
        
        private String image;

        public String Image
        {
            get { return image; }
            set { image = value; }
        }
        private String video;

        public String Video
        {
            get { return video; }
            set { video = value; }
        }
        private String text;

        public String Text
        {
            get { return text; }
            set { text = value; }
        }

        private String speechText;

        public String SpeechText
        {
            get { return speechText; }
            set { speechText = value; }
        }



    }
}
