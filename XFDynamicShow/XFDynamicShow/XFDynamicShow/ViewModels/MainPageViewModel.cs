using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFDynamicShow.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        #region 文字1顯是否
        private bool _文字1顯是否=true;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public bool 文字1顯是否
        {
            get { return this._文字1顯是否; }
            set { this.SetProperty(ref this._文字1顯是否, value); }
        }
        #endregion

        #region 文字2顯是否
        private bool _文字2顯是否=true;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public bool 文字2顯是否
        {
            get { return this._文字2顯是否; }
            set { this.SetProperty(ref this._文字2顯是否, value); }
        }
        #endregion


        public DelegateCommand Text1Command { get; set; }
        public DelegateCommand Text2Command { get; set; }

        public MainPageViewModel()
        {
            Text1Command = new DelegateCommand(() =>
            {
                文字1顯是否 = !文字1顯是否;
            });
            Text2Command = new DelegateCommand(() =>
            {
                文字2顯是否 = !文字2顯是否;
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
