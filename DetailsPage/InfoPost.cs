using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DetailsPage
{
    public class InfoPost
    {
        private String time;
        private String content;
        private String link;
      
        public string Time { get => time; set => time = value; }
        public string Content { get => content; set => content = value; }
        public string Link { get => link; set => link = value; }
    }
}