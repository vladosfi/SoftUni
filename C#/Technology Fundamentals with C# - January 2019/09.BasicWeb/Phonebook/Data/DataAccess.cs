using Phonebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data
{
    public class DataAccess
    {
        static DataAccess()
        {
            Contacts = new List<Contact>();
        }

        public static List<Contact> Contacts { get; set; }
    }
}
