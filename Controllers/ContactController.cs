using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService ContactList;
        public ContactController(IContactService repository)
        {
            ContactList = repository;
        }
        public IActionResult Index()
        {
            ViewBag.list = ContactList.GetAllContacts();
            var contacts = ContactList.GetAllContacts();
            return View(contacts);
        }

        public ViewResult Details(int id)
        {
            ViewBag.list = ContactList.GetAllContacts();
            var contact = ContactList.GetContact(id);
            return View(contact);
        }

        public ViewResult Add()
        {
            ViewBag.list = ContactList.GetAllContacts();
            return View("Add");
        }

        public IActionResult AddContact(Contact contact)
        {
            ViewBag.list = ContactList.GetAllContacts();
            if(ModelState.IsValid)
            {
                var getId = ContactList.AddContact(contact);
                return RedirectToAction("Details", new { id = getId });
            }
            else
            {
                return View("Add");
            }
        }

        public IActionResult DeleteContact(int id)
        {
            Contact contact = ContactList.GetContact(id);
            ContactList.DeleteContact(contact);
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int id)
        {
            ViewBag.list = ContactList.GetAllContacts();
            var contact = ContactList.GetContact(id);
            return View("Edit", contact);
        }

        public IActionResult EditContact(Contact contact, int id)
        {
            ViewBag.list = ContactList.GetAllContacts();
            if (ModelState.IsValid)
            {
                contact.Id = id;
                ViewBag.list = ContactList.GetAllContacts();
                var getId = ContactList.UpdateContact(contact);
                return RedirectToAction("Details", new { id = getId });
            }
            else
            {
                return View("Edit", contact);
            }
        }
    }
}
