using System;
using Xamarin.Forms;
using ResourceAccess;

namespace Notes_Xamarin
{
    public class NoteEditPage : BaseContentPage
    {
        NoteEditModel _model;
        Note _note;
        bool _isNew = false;
        Entry entry;
        MyEditor editor;
        Button deleteCancel;
        bool _isCanceling = false;

        public NoteEditPage(NoteEditModel model)
        {
            _model = model;
            _note = model.Note;
            _isNew = model.IsNew;
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
                Text = _note.Body
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
                    _model.Save();
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

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();           

            if (!_isCanceling)
            {
                _note.Title = entry.Text;
                _note.Body = editor.Text;

                bool save = false;
                if (!string.IsNullOrWhiteSpace(_note.Title) || !string.IsNullOrWhiteSpace(_note.Body) || _note.Id > 0)
                {
                    save = true;
                }

                if (save)
                    _model.Save();
                else
                    _model.Cancel();
            }
        }
    }

    public class NoteEditModel
    {
        public Note Note { get; set; }
        public bool IsNew { get; set; }
        public Action Save { get; set; }
        public Action Cancel { get; set; }
    }
}

