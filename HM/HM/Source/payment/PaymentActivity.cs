using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Runtime;
using System.Collections.Generic;
using Android.Views;

namespace HM.Source.payment
{
    [Activity(Name = "com.companyname.HM.Source.payment.PaymentAcitivity")]
    public class PaymentAcitivity : Activity
    {
        private ExpandableListView mListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity_payment);

            // Set toolbar
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Home Payments";
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetDisplayShowHomeEnabled(true);

            mListView = FindViewById<ExpandableListView>(Resource.Id.expandable_list);
            PaymentAdapter adapter = new PaymentAdapter(this, PaymentFactory.producePayments());
            mListView.SetAdapter(adapter);

            TextView add = FindViewById<TextView>(Resource.Id.tv_add);
            add.Click += (o, e) =>
            {
             
            };

            TextView edit = FindViewById<TextView>(Resource.Id.tv_edit);
            edit.Click += (o, e) =>
            {
                Finish();
            };

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}
