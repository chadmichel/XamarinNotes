using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using ResourceAccess;

namespace Notes_Xamarin.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

            // init database 
            string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
            AccessorBase.SetPath(folder);
            ResourceAccessFactory Factory = new ResourceAccessFactory();
            var noteAccessor = Factory.Create<INoteAccessor>();
            noteAccessor.Setup(false);

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

