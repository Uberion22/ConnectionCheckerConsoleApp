using Newtonsoft.Json;
using System;
using System.IO;

namespace TestService
{   
    public class FileManager
    {
        private static readonly string _settingsNameString = "settings.json";
        public static Settings GetSettingsFromFile()
        {
            var result = new Settings();
            //var settingsPath = Path.Combine(Directory.GetCurrentDirectory(), _settingsNameString);
            var settingsPath = Path.Combine(CheckingService.SAVE_PATH, _settingsNameString);
            if (!File.Exists(settingsPath))
            {
                SaveJsonToFile(result, settingsPath);
                
                return result;
            }

            try
            {
                string jsonString = File.ReadAllText(settingsPath);
                var settings = JsonConvert.DeserializeObject<Settings>(jsonString);
                if (settings != null)
                {
                    result = settings;
                }
            }
            catch(Exception ex)
            {
                SaveJsonToFile<Settings>(result, settingsPath);
            }

            return result;
        }

        public static void SaveJsonToFile<T>(T model, string fileName)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model, Formatting.Indented);
                File.WriteAllText(fileName, json);
            }
            catch
            {
                
            }
        }

        public static string GetJsonFromFile(string fileName)
        {
            var result = String.Empty;
            try
            {
                result = File.ReadAllText(fileName);
               // SerilizedText = JsonConvert.SerializeObject(myclass, Formatting.Indented);
                return result;
            }
            catch
            {
                return result;
            }
        }
    }
}
