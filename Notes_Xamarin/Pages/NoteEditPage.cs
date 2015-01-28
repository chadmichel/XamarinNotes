using System;
using Xamarin.Forms;
using ResourceAccess;

namespace Notes_Xamarin
{
    public class NoteEditPage : BaseContentPage
    {
        Note _note = null;
        bool _isNew = false;
        Entry entry;
        MyEditor editor;
        Button deleteCancel;
        bool _isCanceling = false;

        public NoteEditPage(Note note)
        {
            _note = note;
            _isNew = note.Id <= 0;
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

            deleteCancel = new Button()
            {
                Text = _isNew ? "Cancel" : "Delete"
            };

            deleteCancel.Clicked += (object sender, EventArgs e) => 
            {
                _isCanceling = true;
                
                if (!_isNew)
                {
                    _note.IsDeleted = true;
                    NoteAccessor.Save(_note);
                }

                Navigation.PopAsync();                    
            };
                    
            Content = new StackLayout()
            {
                Children = 
                {
                    new Label {Text = "Title"},
                    entry,
                    new Label {Text = "Note"},
                    editor,
                    deleteCancel
                },
                Padding = new Thickness(5, 5, 5, 5)
            };
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();           

            if (!_isCanceling)
            {
                _note.Title = entry.Text;
                _note.Body = editor.Text;

                if (!string.IsNullOrWhiteSpace(_note.Title) || !string.IsNullOrWhiteSpace(_note.Body) || _note.Id > 0)
                {
                    NoteAccessor.Save(_note);
                }
            }
        }
    }
}

