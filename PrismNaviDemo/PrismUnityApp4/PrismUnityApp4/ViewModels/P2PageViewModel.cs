using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace PrismUnityApp4.ViewModels
{
    public class P2PageViewModel : BindableBase,INavigationAware
    {

        #region Title
        private string _Title;
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return this._Title; }
            set { this.SetProperty(ref this._Title, value); }
        }
        #endregion

        public P2PageViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("UserInput"))
            {
                var foo = parameters["UserInput"] as string;
                Title = foo;
            }
        }
    }
}
