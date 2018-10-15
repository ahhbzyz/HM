using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace HM.Source.payment
{
    public class PaymentAdapter : BaseExpandableListAdapter
    {
        private readonly Context mContext;
        private List<Payment> mData;

        public PaymentAdapter(Context context, List<Payment> data)
        {
            mContext = context;
            mData = data;
        }

        public override int GroupCount => mData.Count;

        public override bool HasStableIds => true;

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return mData[groupPosition];
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return 1;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return mData[groupPosition];
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                var inflater = mContext.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(Resource.Layout.Layout_item_payment_child, null);
            }

            TextView tvName = view.FindViewById<TextView>(Resource.Id.tv_name);
            TextView tvAmount = view.FindViewById<TextView>(Resource.Id.tv_amount);
            TextView tvDate = view.FindViewById<TextView>(Resource.Id.tv_date);
            TextView tvBSB = view.FindViewById<TextView>(Resource.Id.tv_bsb);
            TextView tvAccount = view.FindViewById<TextView>(Resource.Id.tv_account);

            Payment data = mData[groupPosition];

            tvName.Text = "Name: " + data.name;
            tvAmount.Text = "Payment amount: $" + data.amount;
            tvDate.Text = "Due Date: " + data.date;
            tvBSB.Text = "- BSB Number: " + data.BSBNumber;
            tvAccount.Text = "Account Number: " + data.account;

            return view;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                var inflater = mContext.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(Resource.Layout.Layout_item_payment_parent, null);
            }
            TextView tvTitle = view.FindViewById<TextView>(Resource.Id.tv_title);
            Payment data = mData[groupPosition];

            tvTitle.Text = data.getTitle();

            return view;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }
    }

}
