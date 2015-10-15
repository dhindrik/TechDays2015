using Foundation;
using HockeyTransfers.Core.IoC;
using HockeyTransfers.Core.ViewModels;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace HockeyTransfers.iOS
{
	partial class ShlViewController : UITableViewController
	{
        private MainViewModel _mainViewModel;
        private string cellIdentifier = "transferCell";

		public ShlViewController (IntPtr handle) : base (handle)
		{
		}

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _mainViewModel = Resolver.Resolve<MainViewModel>();
            await _mainViewModel.Initialize();

            TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            if(_mainViewModel?.Shl == null)
            {
                return 0;
            }

            return _mainViewModel.Shl.Count;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 90;
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return 30;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier) as TransferViewCell;
            cell.SetData(_mainViewModel.Shl[indexPath.Row]);

            return cell;
        }
    }
}
