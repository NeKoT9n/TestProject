using Assets.Scripts.Features.Rewards;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class JsonSaverLoader <T> where T : new()
    {

        private readonly string _path;
        public JsonSaverLoader(string path)
        {
            _path = Application.streamingAssetsPath + path;
        }

        public void Load(out T data) 
        {
            T loadData = new T();
            string fileData = File.ReadAllText(_path);
            data = JsonUtility.FromJson<T>(fileData);
        }

        public void Save(T data)
        {
            File.WriteAllText(_path, JsonUtility.ToJson(data));
        }
    }
}