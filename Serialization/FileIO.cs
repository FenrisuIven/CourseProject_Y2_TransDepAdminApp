using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace TransDep_AdminApp
{
    public static class FileIO<T>
    {
        public static void Serialize(List<T> objList, string path)
        {
            var jsonString = JsonSerializer.Serialize(objList);
            File.WriteAllText(path, string.Empty);
            File.WriteAllText(path, jsonString);
        }

        public static List<T> Deserialize(string path)
        {
            if (File.Exists(path) && new FileInfo(path).Length != 0)
            {
                var jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<T>>(jsonString);
            }
            return new List<T>();
        }
    }
}