using Android.Views;
using SimpleUI;

namespace AndroidNet
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        HeaderView headerView;
        ItemView item;
        HeaderListView headerListView1;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.activity_main);

            headerView = FindViewById<HeaderView>(Resource.Id.header_component);
            headerView.SetOnClick(() => { Toast.MakeText(this, "Кнопка заголовка нажата", ToastLength.Short).Show(); });

            headerListView1 = FindViewById<HeaderListView>(Resource.Id.header_list_component1);
            headerListView1.SetBottomButtonOnClick(() => { Toast.MakeText(this, "Кнопка списка нажата", ToastLength.Short).Show(); });
            headerListView1.SetAddButtonOnClick(() => { Toast.MakeText(this, "Кнопка добавления в список нажата", ToastLength.Short).Show(); });

            headerListView1.itemsList = new List<ItemData>() {
                new ItemData(1, "Задача 1", "Создать макет", headerListView1.Context.Resources.GetDrawable(Resource.Drawable.orange_img, headerListView1.Context.Theme), true, () => Toast.MakeText(headerListView1.Context, "Кнопка с крестиком нажата", ToastLength.Short).Show()),
                new ItemData(2, "Задача 2", "Внести 2 правки"),
                new ItemData(3, "Задача 3", "Реализовать доп. функционал"),
                new ItemData(4, "Задача 4", "Описание"),
                new ItemData(5, "Задача 5", "Описание"),
                new ItemData(6, "Задача 6", "Описание"),
                new ItemData(7, "Задача 7", "Описание"),
                new ItemData(8, "Задача 8", "Описание")
            };

            item = FindViewById<ItemView>(Resource.Id.item);
            item.SetOnCloseClick(() => { Toast.MakeText(this, "Кнопка элемента нажата", ToastLength.Short).Show(); });

            SimpleButtonView button = FindViewById<SimpleButtonView>(Resource.Id.button1);
            button.Touch += (sender, e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                    Toast.MakeText(this, "Кнопка с крестиком нажата", ToastLength.Short).Show();
            };
        }
    }
}