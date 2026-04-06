using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace SimpleUI
{
    class ItemViewHolder : RecyclerView.ViewHolder
    {
        TextView titleTextView;
        TextView descriptionTextView;
        ImageView iconImageView;
        Button closeButton;

        public ItemViewHolder(View itemView) : base(itemView)
        {
            titleTextView = itemView.FindViewById<TextView>(Resource.Id.titleText);
            descriptionTextView = itemView.FindViewById<TextView>(Resource.Id.descriptionText);
            iconImageView = itemView.FindViewById<ImageView>(Resource.Id.icon);
            closeButton = itemView.FindViewById<Button>(Resource.Id.closeButton);
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
    }
}
