using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public interface IContactService
    {
        public Contact GetContact(int Id);

        public IEnumerable<Contact> GetAllContacts();

        public int AddContact(Contact contact);

        public int UpdateContact(Contact contact);

        public void DeleteContact(Contact contact);
    }
}
