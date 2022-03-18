using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ClassDemoReflection
{
    internal class ReflectionWorker
    {
        public void Start()
        {
            Person person = new Person() { Id = 9, Name = "Peter" };
            Object o = person;
            Console.WriteLine("Person object ==> " + o);
           

            /*
            * Reflection
            */
            Type t = o.GetType();

            Console.WriteLine("Name: " + t.FullName);
            Console.WriteLine("Interface? " + t.IsInterface);
            Console.WriteLine("Class? " + t.IsClass);
            Console.WriteLine("Base " + t.BaseType);


            Console.WriteLine("    Properties ");
            foreach (PropertyInfo info in t.GetProperties())
            {
                Console.WriteLine(info);
            }
            

            Console.WriteLine("    Methods ");
            foreach (MethodInfo info in t.GetMethods())
            {
                Console.WriteLine(info);
            }


            /*
             * Call of method
             */
            MethodInfo setId = t.GetMethods().First(m => m.Name == "set_Id");

            Console.WriteLine("Before: " + o);
            setId.Invoke(o, new object?[] { 15 });
            Console.WriteLine("After: "+ o);

            PropertyInfo idprop = t.GetProperty("Id");
            Console.WriteLine($"Name: {idprop.Name} and value {idprop.GetValue(o)}");


            /*
             * Call extension method
             */
            
            Console.WriteLine("Person upper name " + person.GetUpperCaseName());

            /*
             * new  'anonymous' classes
             */
            var pnew = new { person.Name, OddId = person.Id % 2 == 1 };

            Console.WriteLine(pnew);
            Console.WriteLine($"Name = {pnew.Name} is odd id = {pnew.OddId}");

            //pnew.Name = "Something new";



        }


    }

    public class Person
    {
        public String Name { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Id)}: {Id}";
        }
    }




    /*
     * Extension class - extent Person with a method
     */
    public static class PersonExtension
    {

        public static string GetUpperCaseName(this Person p)
        {
            return p.Name.ToUpper();
        }
    }

}