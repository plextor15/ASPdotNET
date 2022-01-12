using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class PhoneBookEntry
    {
        public int ID { get;  set; } = -1;
        public String Name { get; set; }
        public String CountryPrefix { get;  set; }
        public String Number { get; set; }

        public PhoneBookEntry() { }
        public PhoneBookEntry(int newId)
        {
            this.ID = newId;
        }

        public void CopyFrom(PhoneBookEntry el)
        {
            Name = el.Name;
            CountryPrefix = el.CountryPrefix;
            Number = el.Number;
        }

        public PhoneBookEntry(int iD, string name, string countryPrefix, string number)
        {
            ID = iD;
            Name = name;
            CountryPrefix = countryPrefix;
            Number = number;
        }
        public override string ToString()
        {
            return this.Name+": +" + this.CountryPrefix + " " + this.Number;
        }
    }
}
