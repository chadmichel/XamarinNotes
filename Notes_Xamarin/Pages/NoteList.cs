using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Notes_Xamarin
{
    public class NoteList : ContentPage
    {
        public NoteList()
        {
            ToolbarItems.Add(
                new ToolbarItem("Add", null, 
                    new Action(() => 
                        {
                            this.Navigation.PushAsync(new NoteEditPage(), true);
                        }
                    ), ToolbarItemOrder.Primary, 0));
                        
            Title = "poop";

            var list = new List<string>();
            list.Add("a");
            list.Add("b");

            var listView = new ListView();
            listView.ItemsSource = list;

            Content = listView;

        }
    }
}

