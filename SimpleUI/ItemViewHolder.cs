using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using static Android.Icu.Text.Transliterator;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace SimpleUI
{
    class ItemViewHolder : RecyclerView.ViewHolder
    {
        TextView titleTextView;
        TextView descriptionTextView;
        ImageView iconImageView;
        Button closeButton;
        Context context;

        public ItemViewHolder(View itemView) : base(itemView)
        {
            titleTextView = itemView.FindViewById<TextView>(Resource.Id.titleText);
            descriptionTextView = itemView.FindViewById<TextView>(Resource.Id.descriptionText);
            iconImageView = itemView.FindViewById<ImageView>(Resource.Id.icon);
            closeButton = itemView.FindViewById<Button>(Resource.Id.closeButton);
            closeButton.Touch += (sender, e) =>
            {
                closeButton.Alpha = (
                    e.Event.Action == MotionEventActions.Up ?
                    1.0f : 0.6f
                    );

                e.Handled = true;
            };
            context = titleTextView.Context;
        }

        public TextView GetTitleView()
        {
            return titleTextView;
        }

        public TextView GetDescriptionView()
        {
            return descriptionTextView;
        }

        public ImageView GetIconView()
        {
            return iconImageView;
        }

        public Button GetCloseButton()
        {
            return closeButton;
        }

        public void SetCloseButtonOnClick(Action action)
        {
            closeButton.Touch += (sender, e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                    action();
                e.Handled = true;
            };
        }
        public void SetCloseButtonVisibility(bool visible)
        {
            closeButton.Visibility = visible == true ? ViewStates.Visible : ViewStates.Gone;
        }
        public void SetIcon(Drawable icon)
        {
            var iconDefault = context.Resources.GetDrawable(Resource.Drawable.default_img, context.Theme);
            iconImageView.SetImageDrawable(icon == null ? iconDefault : icon);
        }
        public void makeCardStyles()
        {
            descriptionTextView.SetTextColor(context.Resources.GetColor(Resource.Color.header, context.Theme));
            titleTextView.SetFontVariationSettings("'wght' 500");
        }
    }
}
