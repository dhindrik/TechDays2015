using HockeyTransfers.Core.ServiceAgents;
using HockeyTransfers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTransfers.Core.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private ITransfersServiceAgent _transfersServiceAgent;

        private ObservableCollection<Transfer> _shl;
        public ObservableCollection<Transfer> Shl {
            get
            {
                return _shl;
            }
            set
            {
                _shl = value;
                RaisePropertyChanged("Shl");
            }
        }

        private ObservableCollection<Transfer> _allsvenskan;
        public ObservableCollection<Transfer> Allsvenskan
        {
            get
            {
                return _allsvenskan;
            }
            set
            {
                _allsvenskan = value;
                RaisePropertyChanged("Allsvenskan");
            }
        }

        public MainViewModel(ITransfersServiceAgent transfersServiceAgent)
        {
            _transfersServiceAgent = transfersServiceAgent;
        }

        public async Task Initialize()
        {
            var transfers = await _transfersServiceAgent.GetShlAsync();
            Shl = new ObservableCollection<Transfer>(transfers);

            transfers = await _transfersServiceAgent.GetAllsvenskanAsync();
            Allsvenskan = new ObservableCollection<Transfer>(transfers);
        }
    }
}
