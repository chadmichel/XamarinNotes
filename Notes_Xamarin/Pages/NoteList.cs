using System;
using Xamarin.Forms;
using System.Collections.Generic;
using ResourceAccess;

namespace Notes_Xamarin
{
    public class NoteList : BaseContentPage
    {
        public NoteList()
        {
            ToolbarItems.Add(
                new ToolbarItem("Add", null, 
                    new Action(() => 
                        {
                            this.Navigation.PushAsync(new NoteEditPage(new Note()), true);
                        }
                    ), ToolbarItemOrder.Primary, 0));
                        
            Title = "poop";

            var list = NoteAccessor.FindAll();

            var listView = new ListView();
            listView.ItemsSource = list;

            Content = listView;

        }
    }
}

