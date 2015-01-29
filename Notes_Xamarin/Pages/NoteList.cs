using System;
using Xamarin.Forms;
using System.Collections.Generic;
using ResourceAccess;
using System.Collections.ObjectModel;

namespace Notes_Xamarin
{
    public class NoteList : BaseContentPage
    {
        ListView listView;
        ObservableCollection<Note> collection = new ObservableCollection<Note>();

        public NoteList()
        {
            ToolbarItems.Add(
                new ToolbarItem("Add", null, 
                    new Action(() => 
                        {
                            var model = NewModel(new Note());
                            Navigation.PushAsync(new NoteEditPage(model), true);
                        }
                    ), ToolbarItemOrder.Primary, 0));
                        
            Title = "Notes";

            listView = new ListView();
            Content = listView;
            listView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => 
                {
                    var note = e.SelectedItem as Note;
                    if (note != null)
                    {
                        var model = NewModel(note);
                        Navigation.PushAsync(new NoteEditPage(model), true);
                    }
                };
            listView.ItemsSource = collection;

            // add all notes
            var list = NoteAccessor.FindAll();           
            foreach(var item in list)
                collection.Add(item);
        }

        protected void ReloadList()
        {
            listView.ItemsSource = null;
            collection.Clear();
            var list = NoteAccessor.FindAll();           
            foreach(var item in list)
                collection.Add(item);
            listView.ItemsSource = collection;
        }

        protected NoteEditModel NewModel(Note note)
        {
            var model = new NoteEditModel()
            {
                Note = note,
                IsNew = (note.Id <= 0),
            };

            model.Save = () =>
            {
                NoteAccessor.Save(model.Note);
                ReloadList();
            };

            model.Cancel = () =>
            {
                listView.ItemsSource = null;
                ReloadList();
            };

            return model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing(); 


        }

    }
}

