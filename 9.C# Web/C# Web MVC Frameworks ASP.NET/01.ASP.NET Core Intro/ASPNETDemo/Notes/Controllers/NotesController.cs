namespace Notes.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Notes.BindingModels;
    using Notes.Data;
    using Notes.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class NotesController : BaseController
    {
        public IActionResult All() {
            List<Note> notes = this.Context.Notes.Include(u => u.Author).ToList();
            return View(model: notes);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(NotesBindingModel notesBindingModel) {
            
            Note newNote = new Note() {
                Title = notesBindingModel.Title,
                Content = notesBindingModel.Content,
                AuthorId = 1
            };

            this.Context.Notes.Add(newNote);

            this.Context.SaveChanges();

            return this.RedirectToAction("/all");
        }

    }
}
