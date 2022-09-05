using System;
using System.IO;
using System.Text.Json;

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
                var settings = JsonSerializer.Deserialize<Settings>(jsonString);
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
            var json = JsonSerializer.Serialize<T>(model);
            File.WriteAllText(fileName, json);
        }
    }
}
