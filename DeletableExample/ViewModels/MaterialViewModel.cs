using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeletableExample.Contracts;
using DeletableExample.Dtos;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace DeletableExample
{
    public class MaterialViewModel: ViewModelBase
    {
        private MaterialDto _material;
        private readonly INavigationService _navigationService;
        private readonly IMaterialClient _client;
        public RelayCommand NavigateCommand { get; private set; }


        public MaterialViewModel(INavigationService navigationService, IMaterialClient client)
        {
            _navigationService = navigationService;
            _client = client;
            NavigateCommand = new RelayCommand(NavigateCommandAction);
            InitializeAsync();
        }

        public MaterialDto Material
        {
            get
            {
                return _material;
            }
            set
            {
                if (value != null)
                {
                    _material = value;
                    RaisePropertyChanged();
                }
            }
        }

        public async void InitializeAsync()
        {
            Material = await _client.GetByIdAsync();
        }

        private void NavigateCommandAction()
        {
            _navigationService.NavigateTo(nameof(MaterialsPage));
        }
    }
}
