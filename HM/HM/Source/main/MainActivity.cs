using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace HM
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource


            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);
            ImageView drawer = FindViewById<ImageView>(Resource.Id.img_drawer);
            drawer.Click += (o, e) => {
                spinner.PerformClick();
            };
            String[] say = new string[] { };
            var adapter = new SpinnerAdapter(CategoryFactory.produceAvailableCategories(), this);
            spinner.DropDownVerticalOffset = 100;
            spinner.Adapter = adapter;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }

}

