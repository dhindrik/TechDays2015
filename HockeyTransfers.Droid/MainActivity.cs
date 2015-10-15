using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;

namespace HockeyTransfers.Droid
{
    [Activity(Label = "Transfers", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity, ViewPager.IOnPageChangeListener
    {
        private ViewPager _viewPager;

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
           
        }

        public void OnPageScrollStateChanged(int state)
        {
           
        }

        public void OnPageSelected(int position)
        {
            ActionBar.SetSelectedNavigationItem(position);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            _viewPager = FindViewById<ViewPager>(Resource.Id.pager);

            var adapter = new FragmentPagerAdapter(SupportFragmentManager);


            adapter.Add(new ViewPagerFragment(((i, v, b) =>
            {
                var text = new TextView(this);
                text.Text = "Test";

                var layout = new LinearLayout(this);
                layout.AddView(text);

                return layout;
            }
)));

            adapter.Add(new ViewPagerFragment(((i, v, b) =>
            {
                var text = new TextView(this);
                text.Text = "Test2";

                var layout = new LinearLayout(this);
                layout.AddView(text);

                return layout;
            }
)));

            _viewPager.Adapter = adapter;
            _viewPager.AddOnPageChangeListener(this);

            var tab1 = ActionBar.NewTab();
            tab1.SetText("SHL");
            tab1.TabSelected += Tab_TabSelected;

            var tab2 = ActionBar.NewTab();
            tab2.SetText("Hockeyallsvenskan");
            tab2.TabSelected += Tab_TabSelected;

            ActionBar.AddTab(tab1);
            ActionBar.AddTab(tab2);
        }

        private void Tab_TabSelected(object sender, ActionBar.TabEventArgs e)
        {
            _viewPager.CurrentItem = ((ActionBar.Tab)sender).Position;
        }
    }
}

