using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ResourceAccess;

namespace Notes_Xamarin.Droid
{
	[Activity (Label = "Notes_Xamarin.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // init database 
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            AccessorBase.SetPath(folder);
            ResourceAccessFactory Factory = new ResourceAccessFactory();
            var noteAccessor = Factory.Create<INoteAccessor>();
            noteAccessor.Setup(false);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}
	}
}

