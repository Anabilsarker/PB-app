using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;

namespace Prize_Bond_Checker
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        RelativeLayout relativeLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            relativeLayout = FindViewById<RelativeLayout>(Resource.Id.parent_container);
            relativeLayout.FindViewById(Resource.Id.child_container_home).Visibility = ViewStates.Visible;
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    relativeLayout.FindViewById(Resource.Id.child_container_prizebonds).Visibility = ViewStates.Gone;
                    relativeLayout.FindViewById(Resource.Id.child_container_home).Visibility = ViewStates.Visible;
                    return true;
                case Resource.Id.navigation_prizebond:
                    relativeLayout.FindViewById(Resource.Id.child_container_home).Visibility = ViewStates.Gone;
                    relativeLayout.FindViewById(Resource.Id.child_container_prizebonds).Visibility = ViewStates.Visible;
                    return true;
                case Resource.Id.navigation_notifications:
                    return true;
            }
            return false;
        }
    }
}

