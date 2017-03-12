using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using XFdep.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(SayHello))]
namespace XFdep.iOS
{
    public class SayHello : ISayHello
    {
        public string Hello()
        {
           return "iOS";
        }
    }
}