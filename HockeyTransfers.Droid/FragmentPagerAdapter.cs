using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace HockeyTransfers.Droid
{
    public class FragmentPagerAdapter : Android.Support.V4.App.FragmentPagerAdapter
    {

        private List<Android.Support.V4.App.Fragment> _fragmentList = new List<Android.Support.V4.App.Fragment>();
        public FragmentPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm) {} 

        public override int Count
        {
            get
            {
                return _fragmentList.Count;
            }
        }

        public void Add(Android.Support.V4.App.Fragment fragment)
        {
            _fragmentList.Add(fragment);
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return _fragmentList[position];
        }
    }
}