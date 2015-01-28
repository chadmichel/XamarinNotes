using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using Notes_Xamarin;
using Notes_Xamarin.iOS;

[assembly: ExportRenderer (typeof (MyEditor), typeof (MyEditorRenderer))]
namespace Notes_Xamarin.iOS
{

    public class MyEditorRenderer : EditorRenderer
    {
        public MyEditorRenderer()
        {
        }

        // Override the OnElementChanged method so we can tweak this renderer post-initial setup
        protected override void OnElementChanged (ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged (e);

            if (Control != null) 
            {   // perform initial setup
                // do whatever you want to the UITextField here!
                Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                Control.Layer.BorderWidth = (nfloat)0.5;
            }
        }
    }
}

