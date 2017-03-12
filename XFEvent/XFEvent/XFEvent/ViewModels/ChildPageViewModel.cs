using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFEvent.ViewModels
{
    public class ChildPageViewModel : BindableBase
    {

        #region 子頁面文字
        private string _子頁面文字;
        /// <summary>
        /// 子頁面文字
        /// </summary>
        public string 子頁面文字
        {
            get { return this._子頁面文字; }
            set { this.SetProperty(ref this._子頁面文字, value); }
        }
        #endregion

        public DelegateCommand 送訊息為主頁面Command { get; set; }

        private readonly IEventAggregator _eventAggregator;
        public ChildPageViewModel(IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;
            送訊息為主頁面Command = new DelegateCommand(() =>
            {
                _eventAggregator.GetEvent<SayHelloEvent>().Publish(子頁面文字);
            });
        }
    }
}
