using System;
using Microsoft.WindowsAPICodePack.ExtendedLinguisticServices;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ELSTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            FileStream inputStream = File.OpenRead(@"C:\Users\Mad_Fool\Documents\Visual Studio 2013\Projects\ELSTest\eurovisiontitles+languages.csv");
            StreamReader inputReader = new StreamReader(inputStream);

            int totalSongs = 0;
            int correctSongs = 0;
            int nodetection = 0;
            while (!inputReader.EndOfStream)
            {
                string currentLine = inputReader.ReadLine();
                string[] componets = currentLine.Split(',');
                if (componets.Length == 2)
                {
                    string detectedLanguage = LinguisticServicesHelper.ReturnPredictedLanguage(componets[0]);
                    string providedLanguage = componets[1];

                    //Console.WriteLine("Language detected " + detectedLanguage);
                    //Console.WriteLine("Language flagged " + providedLanguage);

                    totalSongs++;
                    if (detectedLanguage.Contains(providedLanguage) || providedLanguage.Contains(detectedLanguage))
                    {
                        correctSongs++;
                    }
                    else if (detectedLanguage == "Unknown")
                    {
                        nodetection++;
                    }
                    else
                    {
                        //Console.WriteLine("\"" + componets[0] + "\" should be " + providedLanguage + " not " + detectedLanguage);
                    }
                }
            }
            inputReader.Close();
            inputStream.Close();

            double accuracy = 100.0 * correctSongs / totalSongs;
            double accuracyWithoutUnlabeled = 100.0 * correctSongs / (totalSongs - nodetection);
            Console.WriteLine("Correctly detected the language in " + correctSongs + "/" + totalSongs + " [" + nodetection + " no detection]. Accuracy : " + Math.Round(accuracy, 2) + "% [" + Math.Round(accuracyWithoutUnlabeled, 3) + "%]");

            // stop console output disappearing
            Console.Write("Press any key to continue . . .");
            Console.ReadKey();
        }
    }
}
