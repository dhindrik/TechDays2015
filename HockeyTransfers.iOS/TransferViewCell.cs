using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace HockeyTransfers.iOS
{
	partial class TransferViewCell : UITableViewCell
	{
		public TransferViewCell (IntPtr handle) : base (handle)
		{
		}

        //public TransferViewCell(string identifier) : base(UITableViewCellStyle.Default, identifier)
        //{
        //}

        public void SetData(Models.Transfer transfer)
        {
            PlayerLabel.Text = transfer.Player;
            FromLabel.Text = transfer.FromTeam;
            ToLabel.Text = transfer.ToTeam;
        }
	}
}