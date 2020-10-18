using Nancy;
using Nancy.Routing;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NancyNetFramework
{
    public class MainModule : NancyModule
    {

        public static long counter = 0;
        public MainModule()
        {         
            Get("/", parameters =>
            {
                dynamic model = new ExpandoObject();
                model.Name = "Test";
                return View["MyView.cshtml", model];
            });

            Get("/greeting", args =>
            {
                var name = this.Request.Query["name"];
                if (!name)
                {
                    name = "World";
                }

                dynamic greeting = new ExpandoObject();

                greeting.Counter = ++counter;
                greeting.Name = $"Hello, {name}";

                return greeting.Counter + " " + greeting.Name;

            });
        }
    }
}
