using Android.Views;
using Java.Lang;
using Java.Lang.Reflect;
using SimpleUI;

namespace AndroidNet
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Header header;
        Item item;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Убираем заголовок
            this.RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.activity_main);

            header = FindViewById<Header>(Resource.Id.header);
            header.SetOnClick(() => { Toast.MakeText(this, "Кнопка заголовка нажата", ToastLength.Short).Show(); });

            item = FindViewById<Item>(Resource.Id.item);
            item.SetOnCloseClick(() => { Toast.MakeText(this, "Кнопка элемента нажата", ToastLength.Short).Show(); });

            SimpleButton button = FindViewById<SimpleButton>(Resource.Id.button1);
            button.Touch += (sender, e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                    Toast.MakeText(this, "Кнопка нажата", ToastLength.Short).Show();
            };


        }
    }
}