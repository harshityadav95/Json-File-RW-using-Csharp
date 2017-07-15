using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace json__csharp
{
    class item  :IEquatable<item>
    {
        public string name;
        public int price;

        public item(string name, int price = 0)
        {

            this.name = name;
            this.price = price;
        }

        public bool Equals(item other)
        {
            if (other == null) return false;
            return (this.name.Equals(other.name));
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            // Deserializing the JSON File  
            Console.WriteLine("hELLO WORLD  ");
            

            // creating json file if path does not exit already  

            string path = Directory.GetCurrentDirectory() + "data.json";
           
            if (!File.Exists(path))
            {
                File.Create(path);
                
                TextWriter tw = new StreamWriter(path);
                tw.Close();


            }
             
           // end of rough code  



            // read the files into a string and deserialize JSON to a type  
            Console.WriteLine("Reading Data .json");
            string jsonString = File.ReadAllText(path);
            List<item> myList = JsonConvert.DeserializeObject<List<item>>(jsonString);

            if (myList == null)
                myList = new List<item>();
            // if list is empty we need to add item to the list since it cannot be blank  



            string input = "";
            int inputInt = 0;
            string inputString = "";

            while (input != "q")
            {
                Console.WriteLine("Enter A to add new Item ");
                Console.WriteLine("Enter D to delete Item ");
                Console.WriteLine("Enter S to Show content ");
                Console.WriteLine("Enter Q to exit the program ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "a":
                        Console.WriteLine("Adding new Item ");
                        Console.WriteLine("Enter Item name ");
                        inputString = Console.ReadLine();
                        Console.WriteLine("Enter the Price Value in digits only");
                        inputInt = Convert.ToInt32(Console.ReadLine());
                        myList.Add(new item(inputString, inputInt));
                        Console.WriteLine("Added Item " + inputString + " with price " + inputInt);
                        break;
                    case "d":
                        Console.WriteLine("Deleting an Item ");
                        Console.WriteLine("Enter the Item to be Deleted ");
                        inputString = Console.ReadLine();
                        myList.Remove(new item(inputString));
                        Console.WriteLine("Deleted item with name " + inputString);

                        break;


                    case "s":
                        Console.WriteLine("\n Showing contents");
                        foreach (item a in myList)
                        {
                            Console.WriteLine("Item : " + a.name + " and Price " + a.price);

                        }
                        Console.WriteLine("\n");

                       break;


                    default:
                        Console.WriteLine("Incorrect Command , try Again");

                        break;


                }
                Console.WriteLine("Rewriting  data.json");
                string data = JsonConvert.SerializeObject(myList);
                File.WriteAllText(path,data);

                

            }

            Console.ReadLine();



        }
    }
}
