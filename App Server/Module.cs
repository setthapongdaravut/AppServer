using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Json;
using Newtonsoft.Json;

namespace Testetc
{
    public class Module : NancyModule
    {
        public Module() : base("")
        {
            //receive data from client
            Post("/func1", args =>
            {
                string myNewText = Request.Body.AsString();
                PostData.windSpeed_Parameter = myNewText;
                string value = PostData.windSpeed_Parameter;
                Console.WriteLine("Receive :" + value);
                return Response.AsText(value);

            });

            //Sent value to web
            Get("/", args =>
            {
                // deserialize json
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = PostData.windSpeed_Parameter;
                dynamic blogObject = js.Deserialize<dynamic>(json);
                double value = blogObject["WindSpeedControl"];
                Console.WriteLine(value.ToString());

                return Response.AsText("WindSpeed :" + value.ToString());
            });
        }
    }
}
