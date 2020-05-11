using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Products.Models;

namespace Products.Controllers
{
    public class NotesController : ApiController
    {
        Note[] notes = new Note[]
            {
        new Note { NoteId = 1, Priority = 3, Subject = "Wake up", Details = "Set alarm 7:00 and get out of bed."},
        new Note { NoteId = 2, Priority = 2, Subject = "Eat breakfast", Details = "Eat a healthy breakfast."},
        new Note { NoteId = 3, Priority = 5, Subject = "Go to work", Details = "Get to work before 9:00 am."}
            };
        // GET: Notes
        public IEnumerable<Note> GetAllNotes()
        {
            return notes;
        }

        public IHttpActionResult GetNote(int id)
        {
            var note = notes.FirstOrDefault((p) => p.NoteId == id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }
    }

}
