using Newtonsoft.Json;
using System;
using System.IO;

namespace ConnectionCheckerConsoleApp.Utils
{
    public class FileManager
    {
        public static void SaveJsonToFile<T>(T model, string fileName)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model, Formatting.Indented);
                File.WriteAllText(fileName, json);
            }
            catch (Exception ex)
            {
                Program.logger.Error(ex);
            }
        }

        public static string GetJsonFromFile(string fileName)
        {
            var result = string.Empty;
            try
            {
                result = File.ReadAllText(fileName);

                return result;
            }
            catch (Exception ex)
            {
                Program.logger.Error(ex);

                return result;
            }
        }
    }
}