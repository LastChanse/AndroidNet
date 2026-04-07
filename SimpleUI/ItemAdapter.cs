using Android.Content;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace SimpleUI
{
    class ItemAdapter : RecyclerView.Adapter
    {
        List<ItemData> localDataSet;

        public ItemAdapter(List<ItemData> dataSet)
        {
            localDataSet = dataSet;
        }

        public override int ItemCount => localDataSet.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var newHolder = holder as ItemViewHolder;
            if (newHolder != null)
            {
                newHolder.GetTitleView().Text = localDataSet[position].Title;
                newHolder.GetDescriptionView().Text = localDataSet[position].Description;
                newHolder.SetIcon(localDataSet[position].icon);
                newHolder.SetCloseButtonOnClick(localDataSet[position].closeButtonOnClick);
                newHolder.SetCloseButtonVisibility(localDataSet[position].closeButtonVisible);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context)
                                      .Inflate(Resource.Layout.item_frame_layout, parent, false);

            return new ItemViewHolder(view);
        }
    }
}
