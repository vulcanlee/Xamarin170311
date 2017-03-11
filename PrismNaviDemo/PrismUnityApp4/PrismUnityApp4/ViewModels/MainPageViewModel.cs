using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUnityApp4.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region UserInput
        private string _UserInput;
        /// <summaryUserInput           
        /// PropertyDescription
        /// </summary>
        public string UserInput
        {
            get { return this._UserInput; }
            set { this.SetProperty(ref this._UserInput, value); }
        }
        #endregion


        public DelegateCommand GotoP2Command { get; set; }

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            GotoP2Command = new DelegateCommand(async () =>
            {
                Title = "我已經按下按鈕了";
                await _navigationService.NavigateAsync($"xf:///P2Page?UserInput={UserInput}");
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
