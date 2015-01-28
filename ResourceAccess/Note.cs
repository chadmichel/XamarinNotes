using System;
using SQLite;

namespace ResourceAccess
{
    public class Note
    {
        public Note()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title {get;set;}

        public string Body {get;set;}

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public string ToString()
        {
            return Title;
        }
    }
}

