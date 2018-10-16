using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using HM.Source.login;

namespace HM
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private ImageView login;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource


            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);
            login = FindViewById<ImageView>(Resource.Id.img_login);
            login.Click += (o, e) =>
            {
                Intent intent = new Intent(this, typeof(LoginAcitivity));
                StartActivityForResult(intent, 1);
            };
            ImageView drawer = FindViewById<ImageView>(Resource.Id.img_drawer);
            drawer.Click += (o, e) => {
                spinner.PerformClick();
            };
            String[] say = new string[] { };
            var adapter = new SpinnerAdapter(CategoryFactory.produceAvailableCategories(), this);
            spinner.DropDownVerticalOffset = 100;
            spinner.Adapter = adapter;
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 1)
            {
                if (resultCode == Result.Ok) {
                    login.Visibility = Android.Views.ViewStates.Gone;
                }
            }
        }
    }

}

