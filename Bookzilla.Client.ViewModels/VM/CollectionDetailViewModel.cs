using Bookzilla.Client.Services.Interface;
using Bookzilla.Client.ViewModels.ObsObj;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.ViewModels.VM
{
    public class CollectionDetailViewModel : BaseViewModel
    {
        private CollectionObjObs _item;
        public CollectionObjObs Item
        {
            get => _item;
            set
            {
                SetProperty(ref _item, value);
            }
        }
        public CollectionDetailViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
            : base(settingsService, navigationService, synchroService, repository)
        {
            TitlePage = Item.Name;
        }
        public override void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            base.ApplyQueryAttributes(query);

            if (query.ValueAsInt("ItemId") > 0)
            {
                InitializeItemAsync(query.ValueAsInt("ItemId"));
            }
        }

        private async void InitializeItemAsync(int id)
        {
            Item = new CollectionObjObs(await _repository.Collections.Get(id));
            TitlePage = Item.Name;
        }
    }
}
