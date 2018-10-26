using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID_VNM.Assets.Scripts.Text
{
    public class TextDatabaseScriptableObject : ScriptableObject, ITextDatabase
    {
        public List<KeyValue> _database;

        private int NextUniqueId()
        {
            int id = 0;
            if (_database.Count > 0)
            {
                id = _database[_database.Count - 1].key + 1;
            }
            return id;
        }

        public int CreateText(string text)
        {
            int id = NextUniqueId();
            _database.Add(new KeyValue()
            {
                key = id,
                value = text
            });
            return id;
        }

        public string GetText(int id)
        {
            for (int i = 0; i < _database.Count; i++)
            {
                if (_database[i].key == id)
                {
                    return _database[i].value;
                }
            }

            return null;
        }

        public void UpdateText(int id, string text)
        {
            for (int i = 0; i < _database.Count; i++)
            {
                if (_database[i].key == id)
                {
                    _database[i] = new KeyValue()
                    {
                        key = id,
                        value = text
                    };
                }
            }

            throw new System.Exception("Text not found");
        }

        [System.Serializable]
        public struct KeyValue
        {
            public int key;
            public string value;
        }
    }
}