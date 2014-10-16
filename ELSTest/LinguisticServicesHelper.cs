using System;
using Microsoft.WindowsAPICodePack.ExtendedLinguisticServices;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ELSTest
{
    class LinguisticServicesHelper
    {
        public static string ReturnPredictedLanguage(string inputText)
        {
            MappingService languageDetection = new MappingService(MappingAvailableServices.LanguageDetection);
            using (
                MappingPropertyBag bag =
                languageDetection.RecognizeText(inputText, null))
            {
                string[] languages = bag.GetResultRanges()[0].FormatData(
                    new StringArrayFormatter());

                if (languages.Length > 0)
                {
                    return LinguisticServicesHelper.LanguageCodeToFullName(languages[0]);
                }
                else return "Unknown";
            }
        }

        public static string LanguageCodeToFullName(string languageCode)
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.GetCultureInfo(languageCode);
            return culture.DisplayName;
        }
    }
}
