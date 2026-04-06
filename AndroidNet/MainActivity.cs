using Android.Views;
using Java.Lang;
using Java.Lang.Reflect;
using SimpleUI;

namespace AndroidNet
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        HeaderView header;
        ItemView item;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Убираем заголовок
            this.RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.activity_main);

            header = FindViewById<HeaderView>(Resource.Id.header);
            header.SetOnClick(() => { Toast.MakeText(this, "Кнопка заголовка нажата", ToastLength.Short).Show(); });

            item = FindViewById<ItemView>(Resource.Id.item);
            item.SetOnCloseClick(() => { Toast.MakeText(this, "Кнопка элемента нажата", ToastLength.Short).Show(); });

            SimpleButtonView button = FindViewById<SimpleButtonView>(Resource.Id.button1);
            button.Touch += (sender, e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                    Toast.MakeText(this, "Кнопка нажата", ToastLength.Short).Show();
            };


        }
    }
}