using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace SecretIntentNoam
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button bt1, bt2, bt3, bt4;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            bt1 = (Button)FindViewById(Resource.Id.bt1);
            bt2 = (Button)FindViewById(Resource.Id.bt2);
            bt3 = (Button)FindViewById(Resource.Id.bt3);
            bt4 = (Button)FindViewById(Resource.Id.bt4);
            bt1.Click += Bt1_Click;
            bt2.Click += Bt2_Click;
            bt3.Click += Bt3_Click;
            bt4.Click += Bt4_Click;
        }

        private void Bt4_Click(object sender, System.EventArgs e)
        {
            string message = "I love android";
            string phoneNumber = "0521234567";
            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("sms:" + phoneNumber));
            intent.PutExtra("sms_body", message);
            StartActivity(intent);
        }

        private void Bt3_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://ynet.co.il"));
            StartActivity(intent);
        }

        private void Bt2_Click(object sender, System.EventArgs e)
        {
            string[] emails = { "xxx@xxx.xxx" };
            Intent i = new Intent(Intent.ActionSend);
            i.SetType("text/plain");
            i.PutExtra(Intent.ExtraEmail, emails);
            i.PutExtra(Intent.ExtraSubject, "Subject");
            i.PutExtra(Intent.ExtraText, "I'm email body");
            StartActivity(i);
        }

        private void Bt1_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent();
            intent.SetAction(Intent.ActionCall);
            Android.Net.Uri data = Android.Net.Uri.Parse("tel:" + "52-1111111");
            intent.SetData(data);
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}