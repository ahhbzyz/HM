using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Runtime;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace HM.Source.search
{
    [Activity(Name = "com.companyname.HM.Source.search.SearchActivity")]
    public class SearchActivity : Activity, ISearchView
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        SearchPresenter mPresenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity_search);

            // Get title
            string categoryTitle = Intent.GetStringExtra("categoryTitle");
            if (categoryTitle == null) {
                return;
            }
            // Set toolbar
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = categoryTitle;
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetDisplayShowHomeEnabled(true);

            // Init recycler view
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mPresenter = new SearchPresenter(this);
            mPresenter.search();
        }

        public void updateSearchResults(List<SearchResult> list)
        {
            SearchAdapter adapter = new SearchAdapter(list);
        }
    }
}
