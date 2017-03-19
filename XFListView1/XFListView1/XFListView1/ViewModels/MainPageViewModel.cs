using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace XFListView1.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region 學生s
        private ObservableCollection<學生> _學生s = new ObservableCollection<學生>();
        /// <summary>
        /// 學生s
        /// </summary>
        public ObservableCollection<學生> 學生s
        {
            get { return _學生s; }
            set { SetProperty(ref _學生s, value); }
        }
        #endregion


        #region 已選擇的學生紀錄
        private 學生 _已選擇的學生紀錄;
        /// <summary>
        /// 已選擇的學生紀錄
        /// </summary>
        public 學生 已選擇的學生紀錄
        {
            get { return this._已選擇的學生紀錄; }
            set { this.SetProperty(ref this._已選擇的學生紀錄, value); }
        }
        #endregion


        public DelegateCommand 點選項目Command { get; set; }

        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            點選項目Command = new DelegateCommand(async () =>
            {
                NavigationParameters fooPara = new NavigationParameters();
                fooPara.Add("Stud", 已選擇的學生紀錄);
                await _navigationService.NavigateAsync("DetailPage", fooPara);
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";

            for (int i = 0; i < 100; i++)
            {
                學生s.Add(new 學生
                {
                    姓名 = $"學生 {i}",
                });
            }
        }
    }
}
