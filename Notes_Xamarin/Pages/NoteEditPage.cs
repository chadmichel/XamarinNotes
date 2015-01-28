using System;
using Xamarin.Forms;
using ResourceAccess;

namespace Notes_Xamarin
{
    public class NoteEditPage : BaseContentPage
    {
        Note _note = null;

        Entry entry;
        MyEditor editor;

        public NoteEditPage(Note note)
        {
            _note = note;
            Title = "Note";           

            entry = new Entry()
            {
                Placeholder = "Title",
            };
            entry.Text = _note.Title;

            editor = new MyEditor()
            {
                Keyboard = Keyboard.Create(KeyboardFlags.All),
                VerticalOptions = LayoutOptions.FillAndExpand,                     
            };                   
                    
            Content = new StackLayout()
            {
                Children = 
                {
                    new Label {Text = "Title"},
                    entry,
                    new Label {Text = "Note"},
                    editor
                },
                Padding = new Thickness(5, 5, 5, 5)
            };
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();           

            _note.Title = entry.Text;
            _note.Body = editor.Text;

            if (!string.IsNullOrWhiteSpace(_note.Title) || !string.IsNullOrWhiteSpace(_note.Body) || _note.Id > 0)
            {
                NoteAccessor.Save(_note);
            }
        }
    }
}

