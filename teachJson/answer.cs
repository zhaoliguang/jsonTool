using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teachJson
{
    class Answer
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
    }
}
