using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Devices.AllJoyn;
using Windows.Web.Http;
using DeletableExample.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;

namespace DeletableExample
{
    public class MaterialsViewModel : ViewModelBase
    {
        private ObservableCollection<MaterialMiniDto> _materials;

     //   private MaterialMiniDto _selected;
        private readonly INavigationService _navigationService;
        private readonly IMaterialClient _client;
        public RelayCommand NavigateCommand { get; private set; }

    //    public RelayCommand<MaterialMiniDto> NavigateCommand2 { get; private set; }
        private RelayCommand<MaterialMiniDto> _navigateCommand2;
        public RelayCommand<MaterialMiniDto> NavigateCommand2
        {
            get
            {
                if (_navigateCommand2 == null)
                {
                    _navigateCommand2 = new RelayCommand<MaterialMiniDto>((item) =>
                    {
                        
                    });
                }
                return _navigateCommand2;
            } //;
         //   private set;
        }

        public MaterialsViewModel(INavigationService navigationService, IMaterialClient client)
        {
            _navigationService = navigationService;
            _client = client;
            NavigateCommand = new RelayCommand(NavigateCommandAction);
        //    NavigateCommand2 = new RelayCommand<MaterialMiniDto>(NavigateCommandAction2);

            InitializeAsync();
            //   Title = "First Page";
        }

        private async void InitializeAsync()
        {
            var result = await _client.GetListAsync();
            Materials = new ObservableCollection<MaterialMiniDto>(result.List);
        }

        private void NavigateCommandAction()
        {
            _navigationService.NavigateTo(nameof(MainPage));
        }

        private void NavigateCommandAction2(MaterialMiniDto materialMiniDto)
        {
            _navigationService.NavigateTo(nameof(MaterialPage), materialMiniDto.Id);
        }

        public ObservableCollection<MaterialMiniDto> Materials
        {
            get { return _materials; }
            set
            {
                Set(nameof(Materials), ref _materials, value);
                Materials.CollectionChanged += (sender, args) => RaisePropertyChanged();
            }
        }

        //public MaterialMiniDto Selected
        //{
        //    get
        //    {
        //        return _selected;
        //    }
        //    set
        //    {
        //        _selected = value;
        //        _navigationService.NavigateTo(nameof(MaterialPage));
        //        RaisePropertyChanged("Selected");
        //    }
        //}

    }
}
