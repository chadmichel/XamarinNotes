using System;

namespace ResourceAccess
{
    public interface INoteAccessor
    {
        void Setup(bool dropTables);
        Note[] FindAll();
        void Save(Note note);
    }

    class NoteAccessor : AccessorBase, INoteAccessor
    {    
        public NoteAccessor()
        {
        }

        public void Setup(bool dropTables)
        {
            using (var db = NewConnection ())
            {
                if (dropTables)
                {
                    db.CreateTable<Note> ();
                }
                db.CreateTable<Note> ();

                db.Execute("delete from Note");
            }
        }

        public Note[] FindAll()
        {
            using (var db = NewConnection ())
            {
                return db.Query<Note> ("select * from Note where IsDeleted=0").ToArray ();
            }
        }

        public void Save(Note note)
        {
            using (var db = NewConnection ())
            {
                note.UpdatedAt = DateTime.UtcNow;
                if (note.Id <= 0)
                {
                    note.CreatedAt = DateTime.UtcNow;
                    db.Insert (note);
                } 
                else
                {
                    db.Update (note);
                }
            }
        }
    }
}

