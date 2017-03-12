using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFDialog.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand 選擇項目Command { get; set; }

        public DelegateCommand 警告Command { get; set; }

        public readonly IPageDialogService _dialogService;
        public MainPageViewModel(IPageDialogService dialogService)
        {

            _dialogService = dialogService; 
            選擇項目Command = new DelegateCommand(async () =>
            {
              string fooResult =  await _dialogService.DisplayActionSheetAsync("Information", "取消", null, new string[] { "選擇1", "選擇2", "選擇3" });
                if(string.IsNullOrEmpty(fooResult) == false)
                {
                    Title = fooResult;
                }
            });
            警告Command = new DelegateCommand(async () =>
             {
                 await _dialogService.DisplayAlertAsync("請注意", "你的帳號已經被監管", "OK", "取消");
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
