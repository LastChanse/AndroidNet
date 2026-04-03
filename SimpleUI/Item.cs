using Android.Content;
using Android.Util;
using Android.Views;
using static SimpleUI.Utils;


namespace SimpleUI
{
    public class Item : RelativeLayout
    {
        TextView titleTextView;
        TextView descriptionTextView;
        ImageView iconImageView;
        SimpleButton closeSimpleButton;
        RelativeLayout box;
        int elevation = 8;

        // Атрибуты
        String title;
        String description;
        int icon = Resource.Drawable.default_img;
        bool closeButtonVisible;

        public Item(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            // Контекст сохраняем
            LayoutInflater.From(context).Inflate(Resource.Layout.title_layout, this, true);
            
            // Получаем элементы макета
            titleTextView = FindViewById<TextView>(Resource.Id.titleText);
            descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionText);
            iconImageView = FindViewById<ImageView>(Resource.Id.icon);
            closeSimpleButton = FindViewById<SimpleButton>(Resource.Id.closeButton);
            box = FindViewById <RelativeLayout> (Resource.Id.box);

            // Загрузка атрибутов
            LoadFromXML(attrs);

            // Тень при белой теме
            ShadowController();
        }

        // Метод для задания onClick
        public void SetOnCloseClick(Action action)
        {
            closeSimpleButton.Touch += (sender, e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                    action();//Toast.MakeText(this, "Кнопка нажата", ToastLength.Short).Show();
            };
        }

        // Метод загрузки атрибутов из xaml
        void LoadFromXML(IAttributeSet? attrs) {
            // Получаем кастомные атрибуты
            var customAttrs = Context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.Item, 0, 0);
            title = customAttrs.GetString(Resource.Styleable.Item_title);
            description = customAttrs.GetString(Resource.Styleable.Item_description);
            icon = customAttrs.GetResourceId(Resource.Styleable.Item_icon, Resource.Drawable.default_img);
            closeButtonVisible = customAttrs.GetBoolean(Resource.Styleable.Item_closeButtonVisible, false);

            // Применяем атрибуты
            titleTextView.Text = title == null ? "Title" : title;
            descriptionTextView.Text = description == null ? "Description" : description;
            iconImageView.SetImageResource(icon);
            closeSimpleButton.Visibility = closeButtonVisible == true ? ViewStates.Visible : ViewStates.Gone;
        }

        // Метод управления тенью
        void ShadowController()
        {
            int themeColor = Context.Resources.GetColor(Resource.Color.theme_color, Context.Theme);
            if (themeColor < -100) {
            } else
            {
                box = FindViewById<RelativeLayout>(Resource.Id.box);
                box.Elevation = DpToPx(Context, elevation);
            }
        }
    }
}