using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Views;
using static SimpleUI.Utils;


namespace SimpleUI
{
    public class HeaderView : RelativeLayout
    {
        #region Fieds
        TextView headerTextView;
        TextView subheaderTextView;
        ImageView headerImageView;
        SimpleButtonView headerSimpleButton;
        RelativeLayout box;
        int elevation = 8;
        #endregion

        #region Properties
        public string headerText
        {
            get => headerTextView.Text;
            set => headerTextView.Text = value == null ? "Header" : value;
        }
        public string subheaderText
        {
            get => subheaderTextView.Text;
            set => subheaderTextView.Text = value == null ? "Subheader" : value;
        }
        public int image
        {
            get => headerImageView.Id;
            set => headerImageView.SetImageResource(value == null ? Resource.Drawable.default_img : value);
        }
        public string buttonText
        {
            get => headerSimpleButton.Text;
            set => headerSimpleButton.Text = value == null ? "Button" : value;
        }
        public bool subheaderVisible
        {
            get => subheaderTextView.Visibility == ViewStates.Visible;
            set => subheaderTextView.Visibility = (value == true) ? ViewStates.Visible : ViewStates.Gone;
        }
        public bool buttonVisible
        {
            get => headerSimpleButton.Visibility == ViewStates.Visible;
            set => headerSimpleButton.Visibility = value == true ? ViewStates.Visible : ViewStates.Gone;
        }
        #endregion

        #region ctor
        public HeaderView(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            Initialize(attrs);
        }

        protected HeaderView(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Initialize(null);
        }

        public HeaderView(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Initialize(attrs);
        }

        public HeaderView(Context? context, IAttributeSet? attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(attrs);
        }

        public HeaderView(Context? context) : base(context)
        {
            Initialize(null);
        }
        #endregion

        #region Public methods
        // Метод для задания onClick
        public void SetOnClick(Action action)
        {
            headerSimpleButton.Touch += (sender, e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                    action();
            };
        }
        #endregion

        #region Private methods
        void Initialize(IAttributeSet? attrs)
        {
            LayoutInflater.From(Context).Inflate(Resource.Layout.header_layout, this, true);

            // Получаем элементы макета
            headerTextView = FindViewById<TextView>(Resource.Id.headerText);
            subheaderTextView = FindViewById<TextView>(Resource.Id.subheaderText);
            headerImageView = FindViewById<ImageView>(Resource.Id.headerImage);
            headerSimpleButton = FindViewById<SimpleButtonView>(Resource.Id.headerButton);
            box = FindViewById<RelativeLayout>(Resource.Id.box);

            headerSimpleButton.Text = "test";

            // Загрузка атрибутов
            LoadFromXML(attrs);

            // Выбираем макет
            ChoseLayout();

            // Тень при белой теме
            ShadowController();

        }

        // Метод загрузки атрибутов из xaml
        void LoadFromXML(IAttributeSet? attrs) {
            // Получаем кастомные атрибуты
            var customAttrs = Context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.Header, 0, 0);
            headerText = customAttrs.GetString(Resource.Styleable.Header_headerText);
            subheaderText = customAttrs.GetString(Resource.Styleable.Header_subheaderText);
            image = customAttrs.GetResourceId(Resource.Styleable.Header_image, Resource.Drawable.default_img);
            buttonText = customAttrs.GetString(Resource.Styleable.Header_buttonText);
            subheaderVisible = customAttrs.GetBoolean(Resource.Styleable.Header_subheaderVisible, true);
            buttonVisible = customAttrs.GetBoolean(Resource.Styleable.Header_subheaderVisible, false);
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
            if (subheaderVisible == false)
                HeaderMinimal();
            else if (buttonVisible == false)
                HeaderStandart();
            else
                HeaderMaximal();
        }

        // Метод отрисовки макета с заголовком, подзаголовком и изображением
        void HeaderStandart()
        {
            // Применяем макет
            var lp = (RelativeLayout.LayoutParams)box.LayoutParameters;
            lp.Height = ((int)DpToPx(Context, 81));
            box.LayoutParameters = lp;

            headerTextView.LayoutParameters = new RelativeLayout.LayoutParams(headerTextView.LayoutParameters)
            {
                TopMargin = (int)DpToPx(Context, 16f),
                LeftMargin = (int)DpToPx(Context, 20f)
            };
        }

        // Метод отрисовки макета с заголовком и изображением
        void HeaderMinimal()
        {
            // Применяем макет
            var lp = (RelativeLayout.LayoutParams)box.LayoutParameters;
            lp.Height = ((int)DpToPx(Context, 72));
            box.LayoutParameters = lp;

            headerTextView.LayoutParameters = new RelativeLayout.LayoutParams(headerTextView.LayoutParameters)
            {
                TopMargin = (int)DpToPx(Context, 24.5f),
                LeftMargin = (int)DpToPx(Context, 20f)
            };
        }

        // Метод отрисовки макета с заголовком, подзаголовком, изображением и кнопкой
        void HeaderMaximal()
        {
            // Применяем макет
            box.LayoutParameters = new RelativeLayout.LayoutParams(box.LayoutParameters)
            {
                Height = ((int)DpToPx(Context, 141))
            };

        }
        #endregion
    }
}