using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UkrMobilServiceNotes.Models;

namespace UkrMobilServiceNotes.Data
{
    public class NotesRepository : INotesRepository
    {
        private readonly ApplicationDbContext context;

        public NotesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Note> CreateNote(Note note)
        {
            context.Notes.Add(note);
            await context.SaveChangesAsync();
            return note;
        }

        public async Task DeleteNote(Guid id)
        {
            var tmp = context.Notes.Find(id);
            context.Notes.Remove(tmp);
            await context.SaveChangesAsync();
        }

        public async Task<Note> UpdateNote(Note note)
        {
            var tmp = context.Notes.Find(note.Id);
            tmp = note;
            await context.SaveChangesAsync();
            return tmp;
        }

        public async Task<List<Note>> GetAllNotes()
        {
            return await context.Notes.ToListAsync();
        }
    }
}