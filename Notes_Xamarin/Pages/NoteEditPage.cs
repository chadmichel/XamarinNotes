using System;
using Xamarin.Forms;
using ResourceAccess;

namespace Notes_Xamarin
{
    public class NoteEditPage : BaseContentPage
    {
        Note _note = null;

        public NoteEditPage(Note note)
        {
            _note = note;
            Title = "Note";

            var entry = new Entry()
            {
                Placeholder = "Title",
            };
            entry.Text = _note.Title;
            entry.TextChanged += (object sender, TextChangedEventArgs e) => 
            {
                if (!(sender as Entry).IsFocused)
                {
                    _note.Title = e.NewTextValue;
                    NoteAccessor.Save(_note);
                }
            };                   

            var editor = new MyEditor()
            {
                Keyboard = Keyboard.Create(KeyboardFlags.All),
                VerticalOptions = LayoutOptions.FillAndExpand,                     
            };                   
            editor.TextChanged += (object sender, TextChangedEventArgs e) => 
            {
                if (!(sender as Editor).IsFocused)
                {
                    _note.Body = e.NewTextValue;
                    NoteAccessor.Save(_note);
                }
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
    }
}

