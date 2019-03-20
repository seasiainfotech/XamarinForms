using System;
using System.ComponentModel;
using System.Windows.Input;
using FormsPOC.Model;
using Plugin.Connectivity;
using Plugin.DeviceInfo;
using Xamarin.Forms;

namespace FormsPOC.ViewModel
{
    /// <summary>
    /// Main page view model.This class use to set data to UI
    /// </summary>
    public class MainPageViewModel:INotifyPropertyChanged
    {
        public ICommand CheckCommand { get; set; }
        #region Model class property
        private DeviceInfoModel _deviceInfo;
        public DeviceInfoModel DeviceInfo
        {
            get
            {
                return _deviceInfo;
            }
            set
            {
                _deviceInfo = value;
                if (PropertyChanged != null)
                    OnPropertyChanged(nameof(DeviceInfo));

            }
        }
        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FormsPOC.ViewModel.MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel() 
        {

            CheckCommand = new Command(InternetCheck);
            //call method to set data to model 
            SetInfo();
        }
        /// <summary>
        /// Sets the info of device and app to model class
        /// </summary>
        public void SetInfo() 
        {
            _deviceInfo = new DeviceInfoModel()
            {
                ApplicationVersion= CrossDeviceInfo.Current.AppVersion,
                DeviceModel = CrossDeviceInfo.Current.Model,
                Platform = Convert.ToString(CrossDeviceInfo.Current.Platform),
                Version = CrossDeviceInfo.Current.Version,
                Manufacturer = CrossDeviceInfo.Current.Manufacturer,
                AppPackage = DependencyService.Get<IPackageName>().PackageName
        };
        }
        /// <summary>
        /// Internets the check.
        /// </summary>
        private void InternetCheck()
        {
            if (CrossConnectivity.Current.IsConnected)
                Application.Current.MainPage.DisplayAlert("Connectivity", "You are connected with internet", null, "OK");
            else
                Application.Current.MainPage.DisplayAlert("Connectivity", "You are not connected with internet", null, "OK");
        }
        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
