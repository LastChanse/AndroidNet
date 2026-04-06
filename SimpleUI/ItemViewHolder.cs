using Android.Views;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleUI
{
    class ItemViewHolder : RecyclerView.ViewHolder
    {
        TextView title;

        public ItemViewHolder(View itemView) : base(itemView)
        {
            title = itemView.FindViewById<TextView>(Resource.Id.titleText);
        }

        public TextView GetTitleView()
        {
            return title;
        }
    }
}
