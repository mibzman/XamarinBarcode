using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Xamarin_Android_Barcode_Example.Scanning
{
    [Activity(Label = "Xamarin_Android_Barcode_Example", MainLauncher = false, Icon = "@drawable/icon")]
    class BarcodeCaptureActivity : Activity
    {
        public const String BARCODE = "Barcode";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.BarcodeActivity);

            if (bundle == null)
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                var fragment = new CameraResource.CameraPreviewFragment();
                transaction.Replace(Resource.Id.fragmentHolder, fragment);
                transaction.Commit();
            }
        }
    }
}