using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YandexTranslate.Commands;

namespace YandexTranslate.ViewModels
{
    class MainViewModel : BaseViewModel
    {
   
        private string _password;

        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(password));
            }
        }
        private string _login;

        public string login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(login));
            }
        }


        private ICommand _login_;

        public ICommand Login
        {
            get
            {
                if (_login_ == null)
                {
                    _login_ = new DelegateCommand(() => { });
                }
                return _login_;
            }

        }
        

    }
}
