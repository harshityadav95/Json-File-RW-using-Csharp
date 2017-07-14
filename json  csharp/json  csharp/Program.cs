using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace json__csharp
{
    class person
    {
        public string name { get; set; }
        public int age { get; set; }
        public override string ToString()
        {
            return string.Format("Name  :  {0} \n Age {1}", name, age);
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            // Deserializing the JSON File  
            Console.WriteLine("hELLO WORLD  ");

            ////for reading the json file
            String jsonString = File.ReadAllText("JSON.json");

            JavaScriptSerializer ser = new JavaScriptSerializer();
            person p1 = ser.Deserialize<person>(jsonString);
            Console.WriteLine(p1);

            // for wrtiting the json file  

            person p2 = new person() { name = "Harddddshit", age = 22 };
            string outputjson = ser.Serialize(p2);
            File.WriteAllText("JSON.json", outputjson);


            Console.ReadLine();



        }
    }
}
