using AppNinja.Wpf.Binding;
using System.Windows.Input;
using System.Data;
using System;
using System.Windows;

namespace AppNinja.Wpf.ViewModel
{
    class LoginVM : ViewModelBase
    {
        #region Propiedades
        private string _userName;
        private Visibility _userErrorVisibility;
        private Style _userStyle;
        private string _passwordName;
        private Visibility _passwordErrorVisibility;
        private Style _passwordStyle;
        private bool _enableButton;
        #endregion

        #region Constructor
        public LoginVM()
        {
            EnableButton = true;
            resetUser();
            resetPassword();
        }
        #endregion

        #region Notificadores
        public string UserName
        {
            get { return _userName; }
            set
            {
                resetUser();
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public Visibility UserErrorVisibility
        {
            get { return _userErrorVisibility; }
            set
            {
                _userErrorVisibility = value;
                OnPropertyChanged("UserErrorVisibility");
            }
        }

        public Style UserStyle
        {
            get { return _userStyle; }
            set
            {
                _userStyle = value;
                OnPropertyChanged("UserStyle");
            }
        }

        public string PasswordName
        {
            get { return _passwordName; }
            set
            {
                resetPassword();
                _passwordName = value;
                OnPropertyChanged("PasswordName");
            }
        }

        public Visibility PasswordErrorVisibility
        {
            get { return _passwordErrorVisibility; }
            set
            {
                _passwordErrorVisibility = value;
                OnPropertyChanged("PasswordErrorVisibility");
            }
        }

        public Style PasswordStyle
        {
            get { return _passwordStyle; }
            set
            {
                _passwordStyle = value;
                OnPropertyChanged("PasswordStyle");
            }
        }

        public bool EnableButton
        {
            get { return _enableButton; }
            set
            {
                _enableButton = value;
                OnPropertyChanged("EnableButton");
            }
        }
        #endregion

        #region ICommand
        public ICommand LoginCommand
        {
            get { return new DelegateCommand(param => loginCheck()); }
        }
        #endregion

        #region Metodos
        private void resetUser()
        {
            UserErrorVisibility = Visibility.Collapsed;
            UserStyle = (Style)Application.Current.Resources["NormalStyle"];
        }

        private void resetPassword()
        {
            PasswordErrorVisibility = Visibility.Collapsed;
            PasswordStyle = (Style)Application.Current.Resources["NormalPasswordStyle"];
        }

        private void loginCheck()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                UserErrorVisibility = Visibility.Visible;
                UserStyle = (Style)Application.Current.Resources["ErrorStyle"];
            }
            if (string.IsNullOrEmpty(PasswordName))
            {
                
                PasswordErrorVisibility = Visibility.Visible;
                PasswordStyle = (Style)Application.Current.Resources["ErrorPasswordStyle"];
            }
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(PasswordName))
            {
                MessageBox.Show("Consultar al modelo");
                EnableButton = false;
            }
        }
        #endregion
    }
}
