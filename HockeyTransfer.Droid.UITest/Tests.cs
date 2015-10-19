using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;
using System.Threading.Tasks;

namespace HockeyTransfer.Droid.UITest
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest ()
		{
			// TODO: If the Android app being tested is included in the solution then open
			// the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			app = ConfigureApp
				.Android
			// TODO: Update this path to point to your Android app and uncomment the
			// code if the app is not included in the solution.
			//.ApkFile ("../../../Android/bin/Debug/UITestsAndroid.apk")
				.StartApp ();
		}

		[Test]
		public async void AppLaunches ()
		{
			
			//app.Repl ();
			app.Screenshot ("fist view");
			app.WaitForElement (x => x.Text ("Hockeyallsvenskan"));
			app.Tap (x => x.Text ("Hockeyallsvenskan"));
			await Task.Delay(2000);
			app.Tap (x => x.Text ("SHL"));
			app.Tap (x => x.Class ("ListView").Child (3));
		}
	}
}

