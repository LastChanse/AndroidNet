using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using static SimpleUI.Utils;


namespace SimpleUI
{
    public class ItemView : RelativeLayout
    {
        TextView titleTextView;
        TextView descriptionTextView;
        ImageView iconImageView;
        Button closeButton;
        RelativeLayout box;
        int elevation = 8;

        String title;
        String description;
        int icon = Resource.Drawable.default_img;
        bool closeButtonVisible;

        public ItemView(Context? context, IAttributeSet? attrs) : base(context, attrs)
        {
            LayoutInflater.From(context).Inflate(Resource.Layout.item_layout, this, true);
            
            titleTextView = FindViewById<TextView>(Resource.Id.titleText);
            descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionText);
            iconImageView = FindViewById<ImageView>(Resource.Id.icon);
            closeButton = FindViewById<Button>(Resource.Id.closeButton);
            box = FindViewById <RelativeLayout> (Resource.Id.box);

            LoadAttrsFromXML(attrs);

            ShadowController();
        }

        public void SetOnCloseClick(Action action)
        {
            closeButton.Touch += (sender, e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                    Toast.MakeText(Context, "Кнопка нажата", ToastLength.Short).Show();
            };
        }

        void LoadAttrsFromXML(IAttributeSet? attrs) {
            var customAttrs = Context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.Item, 0, 0);
            title = customAttrs.GetString(Resource.Styleable.Item_title);
            description = customAttrs.GetString(Resource.Styleable.Item_description);
            icon = customAttrs.GetResourceId(Resource.Styleable.Item_icon, Resource.Drawable.default_img);
            closeButtonVisible = customAttrs.GetBoolean(Resource.Styleable.Item_closeButtonVisible, false);

            titleTextView.Text = title == null ? "Title" : title;
            descriptionTextView.Text = description == null ? "Description" : description;
            iconImageView.SetImageResource(icon);
            closeButton.Visibility = closeButtonVisible == true ? ViewStates.Visible : ViewStates.Gone;
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
    }
}