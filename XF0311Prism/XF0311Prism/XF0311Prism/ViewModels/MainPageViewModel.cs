using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF0311Prism.ViewModels
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
        /// <summary>
        /// UserInput
        /// </summary>
        public string UserInput
        {
            get { return this._UserInput; }
            set { this.SetProperty(ref this._UserInput, value); }
        }
        #endregion


        public DelegateCommand NextPageCommand { get; set; }


        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;

            NextPageCommand = new DelegateCommand(async () =>
            {
                string foo = "NextPage?UserInput=" + UserInput;
                await _navigationService.NavigateAsync(foo);
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
