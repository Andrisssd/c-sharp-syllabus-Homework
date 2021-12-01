using System;
using System.Collections.Generic;

namespace PhoneBook
{
    public class PhoneDirectory
    {
        private SortedDictionary<string, string> _data;
        public PhoneDirectory() {
            _data = new SortedDictionary<string, string>();
        }

        private bool NameExists(string name) {
            foreach(var data in _data)
            {
                if (_data.ContainsKey(name))
                {
                    return true;
                }
            }

            return false;
        }

        public string GetNumber(string name) 
        {
            if (NameExists(name))
            {
                return _data[name];
            }

            return "Couldn't find name!";
        }

        public void PutNumber(string name, string number) 
        {
            if (name == null || number == null) 
            {
                throw new Exception("name and number cannot be null");
            }

            _data.Add(name, number);
        }
    }
}