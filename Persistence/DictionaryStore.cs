using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace EDCrew
{
    public interface IDictionaryStore
    {
        Dictionary<string, T> Load<T>(string dictionaryName);

        Dictionary<string, T> Add<T>(string dictionaryName, string key, T value);

        Dictionary<string, T> Remove<T>(string dictionaryName, string key);

        Dictionary<string, T> Clear<T>(string dictionaryName);

        Dictionary<string, Dictionary<string, bool>> LoadScanned2(string commander);

        void AddScanned2(string commander, string systemAddress, string body, string speciesLocalised, bool analysed);
    }

    public class DictionaryStore : IDictionaryStore
    {
        private readonly string _baseDirectory;

        public DictionaryStore()
            : this(Path.GetDirectoryName(typeof(DictionaryStore).Assembly.Location))
        {
        }

        public DictionaryStore(string baseDirectory)
        {
            _baseDirectory = baseDirectory;
        }

        private string FilePath(string dictionaryName)
        {
            return Path.Combine(_baseDirectory, $"Dictionary{dictionaryName}.json");
        }

        private string Scanned2FilePath(string commander)
        {
            return Path.Combine(_baseDirectory, $"DictionaryScanned.{commander}.json");
        }

        public Dictionary<string, T> Load<T>(string dictionaryName)
        {
            string filename = FilePath(dictionaryName);

            Dictionary<string, T> d = new Dictionary<string, T>();

            if (File.Exists(filename)) d = JsonConvert.DeserializeObject<Dictionary<string, T>>(File.ReadAllText(filename));

            return d;
        }

        public Dictionary<string, T> Add<T>(string dictionaryName, string key, T value)
        {
            string filename = FilePath(dictionaryName);

            Dictionary<string, T> d = new Dictionary<string, T>();

            if (File.Exists(filename)) d = JsonConvert.DeserializeObject<Dictionary<string, T>>(File.ReadAllText(filename));

            if (!d.ContainsKey(key))
            {
                d.Add(key, value);
            }

            if (!d[key].Equals(value))
            {
                d[key] = value;
            }

            File.WriteAllText(filename, JsonConvert.SerializeObject(d));

            return d;
        }

        public Dictionary<string, T> Remove<T>(string dictionaryName, string key)
        {
            string filename = FilePath(dictionaryName);

            Dictionary<string, T> d = new Dictionary<string, T>();

            if (File.Exists(filename)) d = JsonConvert.DeserializeObject<Dictionary<string, T>>(File.ReadAllText(filename));

            if (d.ContainsKey(key))
            {
                d.Remove(key);
            }

            File.WriteAllText(filename, JsonConvert.SerializeObject(d));

            return d;
        }

        public Dictionary<string, T> Clear<T>(string dictionaryName)
        {
            string filename = FilePath(dictionaryName);

            Dictionary<string, T> d = new Dictionary<string, T>();

            File.WriteAllText(filename, JsonConvert.SerializeObject(d));

            return d;
        }

        public Dictionary<string, Dictionary<string, bool>> LoadScanned2(string commander)
        {
            string filename = Scanned2FilePath(commander);

            return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, bool>>>(File.ReadAllText(filename));
        }

        public void AddScanned2(string commander, string systemAddress, string body, string speciesLocalised, bool analysed)
        {
            string filename = Scanned2FilePath(commander);

            Dictionary<string, Dictionary<string, bool>> Scanned2 = new Dictionary<string, Dictionary<string, bool>>();

            if (File.Exists(filename))
            {
                Scanned2 = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, bool>>>(File.ReadAllText(filename));
            }

            if (!Scanned2.ContainsKey(systemAddress))
            {
                Scanned2.Add(systemAddress, new Dictionary<string, bool>());
            }

            string skey2 = $"{body}_{speciesLocalised}";

            Scanned2[systemAddress].Add(skey2, analysed);

            File.WriteAllText(filename, JsonConvert.SerializeObject(Scanned2));
        }
    }
}
