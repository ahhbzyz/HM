using Android.App;
using Android.OS;
using System;
using Android.Runtime;
using System.Collections.Generic;
using Android.Views;
using Com.Applandeo.Materialcalendarview;
using Android.Widget;
using CalendarView = Com.Applandeo.Materialcalendarview.CalendarView;
using Android.Support.Constraints;
using Java.Util;
using Android.Graphics.Drawables;
using HM.Source.calendar;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;

namespace HM.Source.login
{
    [Activity(Name = "com.companyname.HM.Source.calendar.CalendarActivity")]
    public class CalendarActivity : Activity
    {
        private Dictionary<Calendar, List<HMEvent>> mDict = HMEventFactory.produceEvents();

        private CalendarView mCalendarView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity_calendar);

            // Set toolbar
            Android.Widget.Toolbar toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Calendar";
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetDisplayShowHomeEnabled(true);

            mCalendarView = FindViewById<CalendarView>(Resource.Id.calendar);
            initCalendar();
            mCalendarView.DayClick += (o, e) => {
                foreach (KeyValuePair<Calendar, List<HMEvent>> entry in mDict) {
                    if (entry.Key.TimeInMillis == e.P0.Calendar.TimeInMillis) {
                        List<HMEvent> events = entry.Value;
                        RecyclerView recyclerView = new RecyclerView(this);
                        recyclerView.SetLayoutManager(new LinearLayoutManager(this));
                        CalendarAdapter adapter = new CalendarAdapter(events);
                        recyclerView.SetAdapter(adapter);
                        BottomSheetDialog dialog = new BottomSheetDialog(this);
                        dialog.SetContentView(recyclerView);
                        dialog.Show();
                        break;
                    }
                }
            };
        }

        private void initCalendar()
        {
            List<EventDay> events = new List<EventDay>();
            foreach (KeyValuePair<Calendar, List<HMEvent>> entry in mDict)
            {
                EventDay eventDay = new EventDay(entry.Key, Resource.Mipmap.cleaning);
                events.Add(eventDay);
            }
            mCalendarView.SetEvents(events);
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
