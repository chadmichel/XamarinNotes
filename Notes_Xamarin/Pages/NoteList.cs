using System;
using Xamarin.Forms;
using System.Collections.Generic;
using ResourceAccess;

namespace Notes_Xamarin
{
    public class NoteList : BaseContentPage
    {
        ListView listView;

        public NoteList()
        {
            ToolbarItems.Add(
                new ToolbarItem("Add", null, 
                    new Action(() => 
                        {
                            this.Navigation.PushAsync(new NoteEditPage(new Note()), true);
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
                        this.Navigation.PushAsync(new NoteEditPage(note), true);
                    }
                };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var list = NoteAccessor.FindAll();
            listView.ItemsSource = list;           

        }
    }
}

