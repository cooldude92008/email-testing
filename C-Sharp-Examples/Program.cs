using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace C_Sharp_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var myBinaryFormatter = new BinaryFormatter();
            //myBinaryFormatter.Deserialize(stream); // Noncompliant: a binder is not used to limit types during deserialization
//             var decodedtoken1 = decoder.Decode(token, secret, verify: false); // Noncompliant: signature should be verified

//             var decodedtoken2 = new JwtBuilder()
//                .WithSecret(secret)
//                .Decode(forgedtoken1); // Noncompliant: signature should be verified        
            var tempPath = Path.GetTempFileName();  // Noncompliant

            using (var writer = new StreamWriter(tempPath))
            {
                writer.WriteLine("content");
            }
            
            int target = -5;
            int num = 3;

            target =- num;  // Noncompliant; target = -3. Is that really what's meant?
            target =+ num; // Noncompliant; target = 3
            
            

        }
    }
}
