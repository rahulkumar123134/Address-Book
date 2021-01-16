using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;

namespace AddressBook.Models
{
    public class ContactService : IContactService
    {
        private ContactDbContext ContactList;

        public ContactService(ContactDbContext context)
        {
            ContactList = context;
        }

        public Contact GetContact(int id)
        {
            return ContactList.Contacts.Find(id);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return ContactList.Contacts.AsNoTracking().ToList();
        }

        public int AddContact(Contact contact)
        {
            ContactList.Add(contact);
            ContactList.SaveChanges();
            return contact.Id;
        }

        public int UpdateContact(Contact contact)
        {
            ContactList.Entry(contact).State = EntityState.Modified;
            ContactList.SaveChanges();
            return contact.Id;
        }

        public void DeleteContact(Contact contact)
        {
            ContactList.Entry(contact).State = EntityState.Deleted;
            ContactList.SaveChanges();
        }
    }
}
