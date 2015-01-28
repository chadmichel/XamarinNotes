using System;
using Xamarin.Forms;

namespace Notes_Xamarin
{
    public class NoteEditPage : ContentPage
    {
        public NoteEditPage()
        {
            this.Title = "Note";

            var entry = new Entry()
            {
                    Placeholder = "Title"
            };

            var editor = new MyEditor()
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
    }
}

