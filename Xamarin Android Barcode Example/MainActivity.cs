using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Content;
using Android;
using Android.Gms.Vision.Barcodes;

namespace Xamarin_Android_Barcode_Example
{
    [Activity(Label = "Xamarin_Android_Barcode_Example", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private TextView _textView;

        private const int RC_BARCODE_CAPTURE = 9001;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            _textView = FindViewById<TextView>(Resource.Id.textView1);
            _textView.Text = "Test";

            Button button = FindViewById<Button>(Resource.Id.button1);
            button.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Scanning.BarcodeCaptureActivity));
                StartActivityForResult(intent, RC_BARCODE_CAPTURE);
            };
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == RC_BARCODE_CAPTURE)
            {
                if (resultCode == Result.Ok)
                {
                    Barcode thisBarcode = (Barcode)data.GetParcelableExtra(Scanning.BarcodeCaptureActivity.BARCODE) ?? null;
                    _textView.Text = thisBarcode.DisplayValue ?? "Barcode Read Failed";
                }
            }
        }
    }
}
