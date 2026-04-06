using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using static SimpleUI.Utils;


namespace SimpleUI
{
    public class HeaderList : RelativeLayout
    {
        TextView headerTextView;
        TextView subheaderTextView;
        ImageView headerImageView;
        SimpleButtonView headerSimpleButton;
        RelativeLayout box;
        int elevation = 8;

        // Атрибуты
        String headerText;
        String subheaderText;
        int image = Resource.Drawable.default_img;
        String buttonText;

        public HeaderList(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            // Контекст сохраняем
            LayoutInflater.From(context).Inflate(Resource.Layout.header_layout, this, true);
            
            // Получаем элементы макета
            headerTextView = FindViewById<TextView>(Resource.Id.headerText);
            subheaderTextView = FindViewById<TextView>(Resource.Id.subheaderText);
            headerImageView = FindViewById<ImageView>(Resource.Id.headerImage);
            headerSimpleButton = FindViewById<SimpleButtonView>(Resource.Id.headerButton);
            box = FindViewById <RelativeLayout> (Resource.Id.box);

            headerSimpleButton.Text = "test";

            // Загрузка атрибутов
            LoadFromXML(attrs);

            // Выбираем макет
            ChoseLayout();

            // Тень при белой теме
            ShadowController();
        }

        // Метод для задания onClick
        public void SetOnClick(Action action)
        {
            HeaderMaximal();
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
            subheaderText = customAttrs.GetString(Resource.Styleable.Header_subheaderText);
            image = customAttrs.GetResourceId(Resource.Styleable.Header_image, Resource.Drawable.default_img);
            buttonText = customAttrs.GetString(Resource.Styleable.Header_buttonText);

            // Применяем атрибуты
            headerTextView.Text = headerText == null ? "Header" : headerText;
            subheaderTextView.Text = subheaderText == null ? "Subheader" : subheaderText;
            headerImageView.SetImageResource(image);
            headerSimpleButton.Text = buttonText == null ? "Button" : buttonText;
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

        // Метод выбора макета в зависимости от полученых атрибутов
        void ChoseLayout()
        {
            if (subheaderText == null)
                HeaderMinimal();
            else if (buttonText == null)
                HeaderStandart();
            else
                HeaderMaximal();
        }

        // Метод отрисовки макета с заголовком, подзаголовком и изображением
        void HeaderStandart()
        {
            // Применяем макет
            headerSimpleButton.Visibility = ViewStates.Gone;
            subheaderTextView.Visibility = ViewStates.Visible;


        }

        // Метод отрисовки макета с заголовком и изображением
        void HeaderMinimal()
        {
            // Применяем макет
            headerSimpleButton.Visibility = ViewStates.Gone;
            subheaderTextView.Visibility = ViewStates.Gone;
            
            var layoutParams = (RelativeLayout.LayoutParams)box.LayoutParameters;
            layoutParams.Height = ((int)DpToPx(Context, 72));
            box.LayoutParameters = layoutParams;

            var layoutParams2 = (ViewGroup.MarginLayoutParams)headerTextView.LayoutParameters;
            layoutParams2.SetMargins((int)DpToPx(Context, 20f), (int)DpToPx(Context, 24.5f), 0, 0);
            headerTextView.LayoutParameters = layoutParams2;
        }

        // Метод отрисовки макета с заголовком, подзаголовком, изображением и кнопкой
        void HeaderMaximal()
        {
            // Применяем макет
            headerSimpleButton.Visibility = ViewStates.Visible;
            subheaderTextView.Visibility = ViewStates.Visible;

            var layoutParams = (RelativeLayout.LayoutParams)box.LayoutParameters;
            layoutParams.Height = ((int)DpToPx(Context, 141));
            box.LayoutParameters = layoutParams;

        }
    }
}