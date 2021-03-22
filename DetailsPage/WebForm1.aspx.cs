using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DetailsPage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var request = WebRequest.Create("https://graph.facebook.com/401937776577181/posts?access_token=<EAAA...>");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);
            var results = new List<InfoPost>();
            foreach (var item in jsonData.data)
            {
                results.Add(new InfoPost
                {
                    Time = item.created_time,
                    Content = item.message,
                    Link = item.actions[0].link,
                });
            }
            string str = "";
            for (int i = 0; i <  3; i++)
            {
                str += "<h4>Post" + (i + 1) + ": </h4>" + "</br>";
                str += "<h4>Time: <h4>" + results[i].Time + "</br>";
                str += "<h4>Content: </h4>" + results[i].Content + "</br>";
                str  += "<h4> Link post: </h4>" + results[i].Link + "</br>";
            }
            lbResult.Text = str;
        }
    }
}
