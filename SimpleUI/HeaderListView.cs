using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using static SimpleUI.Utils;


namespace SimpleUI
{
    public class HeaderListView : RelativeLayout
    {
        TextView headerTextView;
        Button headerAddButton;
        SimpleButtonView headerSimpleButton;
        RelativeLayout box;
        int elevation = 8;

        // Атрибуты
        String headerText;
        String subheaderText;
        int image = Resource.Drawable.default_img;
        String buttonText;
        bool buttonVisible;
        String buttonAddText;
        bool buttonAddVisible;

        public HeaderListView(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            // Контекст сохраняем
            LayoutInflater.From(context).Inflate(Resource.Layout.header_box_layout, this, true);
            
            // Получаем элементы макета
            headerTextView = FindViewById<TextView>(Resource.Id.headerText);
            headerAddButton = FindViewById<Button>(Resource.Id.addButton);
            headerSimpleButton = FindViewById<SimpleButtonView>(Resource.Id.headerButton);
            box = FindViewById <RelativeLayout> (Resource.Id.box);

            headerSimpleButton.Text = "test";

            // Загрузка атрибутов
            LoadFromXML(attrs);

            if (buttonVisible)
            {
                headerSimpleButton.Visibility = ViewStates.Visible;
            }
            else
            {
                headerSimpleButton.Visibility = ViewStates.Gone;
            }

            // Тень при белой теме
            ShadowController();
        }

        // Метод для задания onClick
        public void SetOnClick(Action action)
        {
            headerSimpleButton.Touch += (sender, e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                    action();//Toast.MakeText(this, "Кнопка нажата", ToastLength.Short).Show();
            };
        }

        // Метод загрузки атрибутов из xaml
        void LoadFromXML(IAttributeSet? attrs) {
            // Получаем кастомные атрибуты
            var customAttrs = Context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.Header, 0, 0);
            headerText = customAttrs.GetString(Resource.Styleable.Header_headerText);
            buttonVisible = customAttrs.GetBoolean(Resource.Styleable.HeaderList_buttonVisible, false);
            buttonText = customAttrs.GetString(Resource.Styleable.Header_buttonText);
            buttonAddVisible = customAttrs.GetBoolean(Resource.Styleable.HeaderList_buttonVisible, false);
            buttonAddText = customAttrs.GetString(Resource.Styleable.Header_buttonText);

            // Применяем атрибуты
            headerTextView.Text = headerText == null ? "Header" : headerText;
            headerSimpleButton.Text = buttonText == null ? "Button" : buttonText;
            headerAddButton.Text = buttonAddText == null ? "Button" : buttonAddText;
        }

        // Метод управления тенью
        void ShadowController()
        {
            var currentNightMode = UiMode.NightMask & Resources.Configuration.UiMode;
            if (currentNightMode != UiMode.NightYes)
            {
                box = FindViewById<RelativeLayout>(Resource.Id.box);
                box.Elevation = DpToPx(Context, elevation);
            }
        }
    }
}