using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Java.Text;

namespace HM.Source.calendar
{
    public class CalendarAdapter : RecyclerView.Adapter
    {
        private List<HMEvent> mData;

        public CalendarAdapter(List<HMEvent> list)
        {
            mData = list;
            NotifyDataSetChanged();
        }

        public override int ItemCount => mData == null ? 0 : mData.Count;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                                          Inflate(Resource.Layout.Layout_item_event, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            VH vh = new VH(itemView);
            return vh;
        }

        private class VH : RecyclerView.ViewHolder
        {

            public TextView tvTime;
            public TextView tvDuration;
            public TextView tvName;
            public TextView tvLocation;
            public TextView tvDesc;
            public Button add;
            public Button edit;
            public Button delete;

            public VH(View itemView) : base(itemView)
            {
                // Locate and cache view references:
                tvTime = itemView.FindViewById<TextView>(Resource.Id.tv_time);
                tvDuration = itemView.FindViewById<TextView>(Resource.Id.tv_duration);
                tvName = itemView.FindViewById<TextView>(Resource.Id.tv_name);
                tvLocation = itemView.FindViewById<TextView>(Resource.Id.tv_location);
                tvDesc = itemView.FindViewById<TextView>(Resource.Id.tv_desc);
                add = itemView.FindViewById<Button>(Resource.Id.add);
                edit = itemView.FindViewById<Button>(Resource.Id.edit);
                delete = itemView.FindViewById<Button>(Resource.Id.delete);
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            VH vh = holder as VH;

            SimpleDateFormat format = new SimpleDateFormat("hh:mm a");
            String time = format.Format(mData[position].date.Time);
            vh.tvTime.Text = time;
            vh.tvDuration.Text = mData[position].duraion;
            vh.tvName.Text = mData[position].name;
            vh.tvLocation.Text = mData[position].location;
            vh.tvDesc.Text = mData[position].desc;
            vh.delete.Click += (o, e) => {
                mData.Remove(mData[position]);
                NotifyDataSetChanged();
            };
            if (position == mData.Count - 1) {
                vh.add.Visibility = ViewStates.Visible;
            } else {
                vh.add.Visibility = ViewStates.Gone;
            }
        }
    }
}
