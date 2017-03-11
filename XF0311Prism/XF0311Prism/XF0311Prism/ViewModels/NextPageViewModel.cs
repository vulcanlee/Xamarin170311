using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace XF0311Prism.ViewModels
{
    public class NextPageViewModel : BindableBase,INavigationAware
    {

        private readonly INavigationService _navigationService;
        public NextPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            GoHomeCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("xf:///NaviPage/HomePage");
            });
        }


        #region UserInput
        private string _UserInput;
        /// <summary>
        /// UserInput
        /// </summary>
        public string UserInput
        {
            get { return this._UserInput; }
            set { this.SetProperty(ref this._UserInput, value); }
        }
        #endregion


        public DelegateCommand GoHomeCommand { get; set; }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if(parameters.ContainsKey("UserInput"))
            {
                UserInput = parameters["UserInput"] as string;
            }
        }
    }
}
