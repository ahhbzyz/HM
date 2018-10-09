using System;
using System.Collections.Generic;

namespace HM.Source.search
{
    public class SearchResultFactory
    {
        public SearchResultFactory()
        {
        }

        internal static List<SearchResult> getSearchResults()
        {
            List<SearchResult> results = new List<SearchResult>();
            SearchResult a = new SearchResult
            {
                imgResId = Resource.Mipmap.pay,
                title = "Brisbane",
                address = "Brisbane",
                phone = "1385789008",
                distance = "200m",
                isFav = false,
            };
            results.Add(a);
            SearchResult b = new SearchResult
            {
                imgResId = Resource.Mipmap.pay,
                title = "Brisbane",
                address = "Brisbane",
                phone = "1385789008",
                distance = "200m",
                isFav = false,
            };
            results.Add(b);
            SearchResult c = new SearchResult
            {
                imgResId = Resource.Mipmap.pay,
                title = "Brisbane",
                address = "Brisbane",
                phone = "1385789008",
                distance = "200m",
                isFav = false,
            };
            results.Add(c);
            SearchResult d = new SearchResult
            {
                imgResId = Resource.Mipmap.pay,
                title = "Brisbane",
                address = "Brisbane",
                phone = "1385789008",
                distance = "200m",
                isFav = false,
            };
            results.Add(d);
            return results;
        }
    }
}
