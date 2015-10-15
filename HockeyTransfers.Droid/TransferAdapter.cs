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
using Java.Lang;
using HockeyTransfers.Models;

namespace HockeyTransfers.Droid
{
    public class TransferAdapter : BaseAdapter
    {
        private List<Transfer> _transfers;
        private Activity _activity;

        public TransferAdapter(List<Transfer> transfers, Activity activity)
        {
            _transfers = transfers;
            _activity = activity;
        }

        public override int Count
        {
            get
            {
                return _transfers.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = _activity.LayoutInflater.Inflate(Resource.Layout.transfer_item, null);

            var player = view.FindViewById<TextView>(Resource.Id.player);
            var toTeam = view.FindViewById<TextView>(Resource.Id.to_team);
            var fromTeam = view.FindViewById<TextView>(Resource.Id.from_team);
            
            player.Text = _transfers[position].Player;
            toTeam.Text = _transfers[position].ToTeam;
            fromTeam.Text = _transfers[position].FromTeam;

            return view;
        }
    }
}