using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;

namespace HM.Source.search
{
    public class SearchAdapter : RecyclerView.Adapter
    {
        private List<SearchResult> mSearchResults;

        public SearchAdapter(List<SearchResult> list)
        {
            mSearchResults = list;
            NotifyDataSetChanged();
        }

        public override int ItemCount => mSearchResults == null ? 0 : mSearchResults.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            throw new NotImplementedException();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            throw new NotImplementedException();
        }

        private class VH : RecyclerView.ViewHolder
        {


            public VH(View itemView) : base(itemView)
            {
                // Locate and cache view references:
                Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
                Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
            }
        }
    }
}
