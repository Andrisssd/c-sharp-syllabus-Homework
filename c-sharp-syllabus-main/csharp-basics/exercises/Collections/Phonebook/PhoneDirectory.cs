using System;
using System.Collections.Generic;

namespace Phonebook
{
    public class PhoneDirectory
    {
        private SortedDictionary<string, string> _data;
        public PhoneDirectory() {
            _data = new SortedDictionary<string, string>();
        }

        public bool NameExists(string name) 
        {
            return _data.ContainsKey(name);
        }

        public string GetNumber(string name) 
        {
            if (NameExists(name))
            {
                return _data[name];
            }

            throw new NameNotFoundException(name);
        }

        public void PutNumber(string name, string number) 
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(name)) 
            {
                throw new PutNumberNullParameterException();
            }

            _data.Add(name, number);
        }

        public Dictionary<string, string> GetDataDictionary()
        {
            return new Dictionary<string, string>(_data);
        }
    }
}