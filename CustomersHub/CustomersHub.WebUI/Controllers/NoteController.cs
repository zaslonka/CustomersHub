using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomersHub.Core.Contracts;
using CustomersHub.Core.Models;

namespace CustomersHub.WebUI.Controllers
{
    public class NoteController : Controller
    {
        IRepository<Note> context;

        public NoteController(IRepository<Note> noteContext)
        {
            context = noteContext;
        }

        public ActionResult Create(string customerId)
        {
            Note model = new Note { CustomerId = customerId };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            if (!ModelState.IsValid)
            {
                return View(note);
            }

            context.Insert(note);
            context.Commit();

            return RedirectToAction("Details", "Customer", new { id = note.CustomerId });
        }

        public ActionResult Edit(string Id)
        {
            Note note = context.Find(Id);
            if (note == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(note);
            }
        }

        [HttpPost]
        public ActionResult Edit(Note note, string Id)
        {
            Note noteToEdit = context.Find(Id);

            if (noteToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(note);
                }

                noteToEdit.Name = note.Name;
                noteToEdit.Description = note.Description;

                context.Commit();

                return RedirectToAction("Details", "Customer", new { id = note.CustomerId });
            }
        }
    }
}