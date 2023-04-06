using System.IO;
using UnityEngine;

namespace Saver
{
    public static class SaveService<T>
    {
        public static void Save(T data, string path, string name)
        {
            var json = JsonUtility.ToJson(data);

            var fullPath =Application.dataPath + path;
            var fullPathToName = fullPath + name + ".json";

            File.WriteAllText(fullPathToName, json);
        }

        public static T Load(string path)
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(path));
        }
    }




}