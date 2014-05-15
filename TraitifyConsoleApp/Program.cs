using com.traitify.net.TraitifyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraitifyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Use this console app to test Traitify APIs");
            Console.WriteLine("Type hostname and hit enter:");
            string hostname = Console.ReadLine();
            Console.WriteLine("Type Public Key and hit enter:");
            string publicKey = Console.ReadLine();
            Console.WriteLine("Type Secret Key and hit enter:");
            string secretKey = Console.ReadLine();

            Traitify traitify = new Traitify(hostname, publicKey, secretKey, "v1");

            Console.WriteLine("Type DeckId and hit enter:");
            string deckId = Console.ReadLine();

            Assessment assess = traitify.CreateAssesment(deckId);

            Console.WriteLine("The AssesmentId is " + assess.id);

            Console.WriteLine("Press Any key to quit:");
            Console.ReadLine();
        }
    }
}
