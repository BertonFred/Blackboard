using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackboardN
{
    class Program
    {
        class ClassOne 
        {
            public static BlackboardProperty<string> BlackboardProperty_Nom = new BlackboardProperty<string>(nameof(ClassOne), "Nom");

            public ClassOne()
            {
                blackboard.Set(BlackboardProperty_Nom, "One");
            }
        }

        class ClassTwo
        {
            public static BlackboardProperty<double> BlackboardProperty_Vitesse = new BlackboardProperty<double>(nameof(ClassTwo), "Vitesse");

            public ClassTwo() 
            {
                blackboard.Set(BlackboardProperty_Vitesse, 2.0);
            }
        }

        class Class3
        {
            public Class3()
            {
                blackboard.Set(new BlackboardProperty<double>(nameof(Class3),"Altitude"), 62.0);
            }
        }

        static Blackboard blackboard = new Blackboard();

        static void Main(string[] args)
        {
            Console.WriteLine($"{ClassOne.BlackboardProperty_Nom.Key} exist ? {blackboard.ContainsKey(ClassOne.BlackboardProperty_Nom)}");
            Console.WriteLine($"{ClassTwo.BlackboardProperty_Vitesse.Key} exist ? {blackboard.ContainsKey(ClassTwo.BlackboardProperty_Vitesse)}");
            var v1 = new ClassOne();
            var v2 = new ClassTwo();
            var v3 = new Class3();

            Console.WriteLine($"{ClassOne.BlackboardProperty_Nom.Key} exist ? {blackboard.ContainsKey(ClassOne.BlackboardProperty_Nom)}");
            Console.WriteLine($"{ClassTwo.BlackboardProperty_Vitesse.Key} exist ? {blackboard.ContainsKey(ClassTwo.BlackboardProperty_Vitesse)}");

            var v4 = blackboard.Get(ClassOne.BlackboardProperty_Nom);
            var v5 = blackboard.Get(ClassTwo.BlackboardProperty_Vitesse);
            var v6 = blackboard.Get<double>("Class3.Altitude");
            var v7 = blackboard.Get("Class3.Altitude");

            Console.ReadKey();
        }

        private static void Dump(Blackboard bl)
        {
            Console.WriteLine($"bl.Count = {bl.Count}");
        }
    }
}
