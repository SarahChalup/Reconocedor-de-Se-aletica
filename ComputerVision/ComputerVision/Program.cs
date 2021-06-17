using System;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Linq;

namespace ComputerVision
{
    class Program
    {


        public static ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
              { Endpoint = endpoint };
            return client;
        }

        /* 
         * ANALYZE IMAGE - URL IMAGE
         * Analyze URL image. Extracts captions, categories, tags, objects, faces, racy/adult/gory content,
         * brands, celebrities, landmarks, color scheme, and image types.
         */
        public static async Task AnalyzeMenu(ComputerVisionClient client)
        {

            string pregunta = "";   

            while (pregunta != "exit")
            {
                Console.WriteLine("");
                Console.WriteLine(@"(='3´=) Inserte el link de su michimagen");
       
                pregunta = Console.ReadLine();

                if(pregunta != "exit")
                {
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine(@"(=^ ◡ ^=) MICHIANALIZANDO TU IMAGEN ");
                    Console.WriteLine();

                    // Crea una lista para las features que se sacaran de la imagen.
                    List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
                    {
                        VisualFeatureTypes.Categories
                    };


                    Console.WriteLine(@"/\_/\");
                    Console.WriteLine(@"=@,@=");
                    Console.WriteLine(@" / \");
                    Console.WriteLine(@"(__)__");


                    Console.WriteLine($"El michi esta analizando tu imagen: {Path.GetFileName(pregunta)}...");
                    Console.WriteLine();
                    // Analar la imagen 
                    ImageAnalysis results = await client.AnalyzeImageAsync(pregunta, visualFeatures: features);

                    // Mostrar en pantalla los resultados.
                    bool haymichi = false;
                    foreach (var category in results.Categories)
                    {
                        if(category.Name == "animal_cat")
                            haymichi = true;
                    }

                    if (haymichi)
                    {
                        Console.WriteLine("Michi Approve This");
                        Console.WriteLine(@"/\_/\ ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥");
                        Console.WriteLine(@"=^,^=");
                        Console.WriteLine(@" / \");
                        Console.WriteLine(@"(__)__");
                        foreach (var category in results.Categories)
                        {
                            float posi = 100f * (float)category.Score;
                            int porcentaje = Convert.ToInt32(posi);
                            if(category.Name == "animal_cat")
                                Console.WriteLine($"Es un michi {category.Name} con un {porcentaje}% de seguridad");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Michi Disapprove This");
                        Console.WriteLine(@"/\_/\ XXXXXXXXXXXXXXXXX");
                        Console.WriteLine(@"=>.<=");
                        Console.WriteLine(@" / \");
                        Console.WriteLine(@"(__)__");
                      foreach (var category in results.Categories)
                      {
                            float posi = 100f * (float)category.Score;
                            int porcentaje = Convert.ToInt32(posi);
                            if (category.Name != "animal_cat")
                                Console.WriteLine($"This is a {category.Name} con un {porcentaje}% de seguridad");
                      }
                    }
                }
            }
        }

        // Variables para la subscription key y endpoint del Computer Vision
        static string subscriptionKey = "028c736f2caa47c4a106b39738d66cac";
        static string endpoint = "https://compvisionjaime.cognitiveservices.azure.com/";

        static void Main(string[] args)
        {
            // Crear un cliente
            ComputerVisionClient client = Authenticate(endpoint, subscriptionKey);

            // Analizar una imagen.
            AnalyzeMenu(client).Wait();

        }


    }
}
