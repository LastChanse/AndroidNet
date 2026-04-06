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
            //((ViewHolder) holder).GetTitleView().Text = localDataSet[position].Title;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context)
                                      .Inflate(Resource.Layout.item_frame_layout, parent, false);

            return new ItemViewHolder(view);
        }
    }
}
