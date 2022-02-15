using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDateTime { get; set; }

        public string JournalEntry
        {
            get
            {
                return $"\nEntry Title: {Title} \nPublished on {CreateDateTime}\n {Content}\n";
            }
        }

        public override string ToString()
        {
            return JournalEntry;
        }
    }
}