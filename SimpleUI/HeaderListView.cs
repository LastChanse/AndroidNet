using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.RecyclerView.Widget;
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
        RecyclerView itemsListView;
        List<ItemData> items;
        int elevation = 8;
        bool cardItemModeValue = false;

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
            set => headerAddButton.Visibility = value == false ? ViewStates.Gone : ViewStates.Visible;
        }

        public bool cardItemMode
        {
            get => cardItemModeValue;
            set {
                cardItemModeValue = value;
                if (value == true)
                    itemsListView.SetLayoutManager(new LinearLayoutManager(Context, LinearLayoutManager.Horizontal, false));
                else
                    itemsListView.SetLayoutManager(new LinearLayoutManager(Context));
            }
        }

        public List<ItemData> itemsList
        {
            get => items;
            set {
                items = value;
                itemsListView.SetAdapter(new ItemAdapter(value, cardItemModeValue));
            }
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

        public void SetBottomButtonOnClick(Action action)
        {
            headerSimpleButton.Touch += (sender, e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                    action();
            };
        }
        public void SetAddButtonOnClick(Action action)
        {
            headerAddButton.Touch += (sender, e) =>
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

            headerTextView = FindViewById<TextView>(Resource.Id.headerText);
            headerAddButton = FindViewById<Button>(Resource.Id.addButton);
            headerSimpleButton = FindViewById<SimpleButtonView>(Resource.Id.headerButton);
            itemsListView = FindViewById<RecyclerView>(Resource.Id.listItems);
            box = FindViewById<RelativeLayout>(Resource.Id.box);

            itemsListView.SetLayoutManager(new LinearLayoutManager(Context));

            LoadAttrsFromXML(attrs);
            
            var listParams = (RelativeLayout.LayoutParams)itemsListView.LayoutParameters;
            var buttonParams = (RelativeLayout.LayoutParams)headerSimpleButton.LayoutParameters;
            if (cardItemModeValue)
            {
                listParams.RemoveRule(LayoutRules.Above);
                listParams.Height = RelativeLayout.LayoutParams.WrapContent;

                buttonParams.AddRule(LayoutRules.Below, Resource.Id.listItems);
            }
            else
            {
                listParams.AddRule(LayoutRules.Above, Resource.Id.headerButton);
                listParams.Height = RelativeLayout.LayoutParams.MatchParent;

                buttonParams.RemoveRule(LayoutRules.Below);
            }

            itemsListView.LayoutParameters = listParams;
            headerSimpleButton.LayoutParameters = buttonParams;

            if (buttonVisible)
            {
                headerSimpleButton.Visibility = ViewStates.Visible;
            }
            else
            {
                headerSimpleButton.Visibility = ViewStates.Gone;
            }

            headerAddButton.Touch += (sender, e) =>
            {
                var color_clicked = Context.Resources.GetColor(Resource.Color.button_clicked, Context.Theme);
                var color = Context.Resources.GetColor(Resource.Color.button, Context.Theme);

                headerAddButton.SetTextColor(
                    e.Event.Action == MotionEventActions.Up?
                    color : color_clicked
                    );
                
                e.Handled = true;
            };

            ShadowController();
        }

        void LoadAttrsFromXML(IAttributeSet? attrs) {
            var customAttrs = Context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.HeaderList, 0, 0);
            
            headerText = customAttrs.GetString(Resource.Styleable.HeaderList_headerText);
            buttonVisible = customAttrs.GetBoolean(Resource.Styleable.HeaderList_buttonVisible, false);
            buttonText = customAttrs.GetString(Resource.Styleable.HeaderList_buttonText);
            buttonAddVisible = customAttrs.GetBoolean(Resource.Styleable.HeaderList_buttonVisible, true);
            buttonAddText = customAttrs.GetString(Resource.Styleable.HeaderList_buttonAddText);
            cardItemMode = customAttrs.GetBoolean(Resource.Styleable.HeaderList_cardItemMode, false);
        }

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