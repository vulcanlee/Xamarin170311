using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFCanExecute.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region Account
        private string _Account = "";
        /// <summary>
        /// Account
        /// </summary>
        public string Account
        {
            get { return this._Account; }
            set
            {
                this.SetProperty(ref this._Account, value);
                if (_Account.Length >= 6)
                {
                    CanLogin = true;
                }
                else
                {
                    CanLogin = false;
                }
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region EnterAccount
        private string _EnterAccount;
        /// <summary>
        /// EnterAccount
        /// </summary>
        public string EnterAccount
        {
            get { return this._EnterAccount; }
            set { this.SetProperty(ref this._EnterAccount, value); }
        }
        #endregion


        #region CanLogin
        private bool _CanLogin = false;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public bool CanLogin
        {
            get { return this._CanLogin; }
            set { this.SetProperty(ref this._CanLogin, value); }
        }
        #endregion

        public DelegateCommand LoginCommand { get; set; }

        public MainPageViewModel()
        {
            LoginCommand = new DelegateCommand(() =>
             {
                 EnterAccount = Account;
             }, ()=>
             {
                 return CanLogin;
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
