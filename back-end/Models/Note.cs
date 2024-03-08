using System.ComponentModel.DataAnnotations.Schema;

namespace note_taking_app_api.Models
{

    public class Note
    {

        public int Id { get; set; } // Unique identifier for the note

        public string? Content { get; set; } // Content of the note

        public DateTime CreatedAt { get; set; } = DateTime.Now;// Date and time note was created

        public DateTime UpdatedAt { get; set; } = DateTime.Now;// Date and time note was last updated

    }
}
