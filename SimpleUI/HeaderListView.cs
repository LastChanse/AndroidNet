using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using AndroidX.RecyclerView.Widget;
using Android.Util;
using Android.Views;
using static SimpleUI.Utils;


namespace SimpleUI
{
    public class HeaderListView : RelativeLayout
    {
        #region Fieds
        TextView headerTextView;
        Button headerAddButton;
        SimpleButtonView headerSimpleButton;
        RelativeLayout box;
        RecyclerView listItems;
        int elevation = 8;
        #endregion

        #region Properties
        public string headerText
        {
            get => headerTextView.Text;
            set => headerTextView.Text = value == null ? "Header" : value;
        }
        public string buttonText
        {
            get => headerSimpleButton.Text;
            set => headerSimpleButton.Text = value == null ? "Button" : value;
        }
        public bool buttonVisible
        {
            get => headerSimpleButton.Visibility == ViewStates.Visible;
            set => headerSimpleButton.Visibility = value == true ? ViewStates.Visible : ViewStates.Gone;
        }
        public string buttonAddText
        {
            get => headerAddButton.Text;
            set => headerAddButton.Text = value == null ? "Button" : value;
        }
        public bool buttonAddVisible
        {
            get => headerAddButton.Visibility == ViewStates.Visible;
            set => headerAddButton.Visibility = value == true ? ViewStates.Visible : ViewStates.Gone;
        }
        #endregion

        #region ctor
        public HeaderListView(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            Initialize(attrs);
        }

        protected HeaderListView(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Initialize(null);
        }

        public HeaderListView(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Initialize(attrs);
        }

        public HeaderListView(Context? context, IAttributeSet? attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(attrs);
        }

        public HeaderListView(Context? context) : base(context)
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
            LayoutInflater.From(Context).Inflate(Resource.Layout.header_box_layout, this, true);

            // Получаем элементы макета
            headerTextView = FindViewById<TextView>(Resource.Id.headerText);
            headerAddButton = FindViewById<Button>(Resource.Id.addButton);
            headerSimpleButton = FindViewById<SimpleButtonView>(Resource.Id.headerButton);
            listItems = FindViewById<RecyclerView>(Resource.Id.listItems);
            box = FindViewById<RelativeLayout>(Resource.Id.box);

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

        // Метод загрузки атрибутов из xaml
        void LoadFromXML(IAttributeSet? attrs) {
            // Получаем кастомные атрибуты
            var customAttrs = Context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.Header, 0, 0);
            headerText = customAttrs.GetString(Resource.Styleable.Header_headerText);
            buttonVisible = customAttrs.GetBoolean(Resource.Styleable.HeaderList_buttonVisible, false);
            buttonText = customAttrs.GetString(Resource.Styleable.Header_buttonText);
            buttonAddVisible = customAttrs.GetBoolean(Resource.Styleable.HeaderList_buttonVisible, false);
            buttonAddText = customAttrs.GetString(Resource.Styleable.Header_buttonText);
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
        #endregion
    }
}