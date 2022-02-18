using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMWApp
{
    public partial class MainPage : ContentPage
    {
        private readonly Models.MonsterViewModel _vm = new Models.MonsterViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _vm;
        }


    }
}
