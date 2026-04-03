using Android.Views;
using static Android.Preferences.PreferenceActivity;

namespace AndroidNet
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Убираем заголовок
            this.RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.activity_main);
        }

        public void test(View view) {
            Toast.MakeText(this, "Кнопка нажата", ToastLength.Short).Show();
        }
    }
}