using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using IsimSozlugu.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace IsimSozlugu
{
    public partial class BackgroundColorSettingsPage : PhoneApplicationPage
    {
        public int artistId;

        public BackgroundColorSettingsPage()
        {
            InitializeComponent();

            lstBackgroundColor.Items.Clear();
            lstBackgroundColor.Items.Add("Black");
            lstBackgroundColor.Items.Add("Blue");
            lstBackgroundColor.Items.Add("Brown");
            lstBackgroundColor.Items.Add("Gray");
            lstBackgroundColor.Items.Add("Green");
            lstBackgroundColor.Items.Add("Orange");
            lstBackgroundColor.Items.Add("Purple");
            lstBackgroundColor.Items.Add("Red");
            lstBackgroundColor.Items.Add("Yellow");
            lstBackgroundColor.SelectedIndex = -1;

            SetBackgroundColor();
        }

        private void SetBackgroundColor()
        {
            AppSettings appSettings = new AppSettings();
            using (var context = new NameDataContext(NameDataContext.ConnectionString))
            {
                appSettings = context.AppSettings.First() as AppSettings;
            }

            if (appSettings.AppBackgroundImage != null)
            {
                MemoryStream stream = new MemoryStream(appSettings.AppBackgroundImage);
                BitmapImage image = new BitmapImage();
                image.SetSource(stream);
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = image;
                this.LayoutRoot.Background = ib;
            }
            else
            {
                switch (appSettings.AppBackgroundColor)
                {
                    case "BLA":
                        this.LayoutRoot.Background = new SolidColorBrush(Colors.Black);
                        break;
                    case "BLU":
                        this.LayoutRoot.Background = new SolidColorBrush(Colors.Blue);
                        break;
                    case "BRO":
                        this.LayoutRoot.Background = new SolidColorBrush(Colors.Brown);
                        break;
                    case "RED":
                        this.LayoutRoot.Background = new SolidColorBrush(Colors.Red);
                        break;
                    case "GRE":
                        this.LayoutRoot.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case "GRA":
                        this.LayoutRoot.Background = new SolidColorBrush(Colors.Gray);
                        break;
                    case "YEL":
                        this.LayoutRoot.Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case "ORA":
                        this.LayoutRoot.Background = new SolidColorBrush(Colors.Orange);
                        break;
                    case "PUR":
                        this.LayoutRoot.Background = new SolidColorBrush(Colors.Purple);
                        break;
                    default:
                        this.LayoutRoot.Background = new SolidColorBrush(Colors.Black);
                        break;
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //SetBackgroundColor();
            //while (NavigationService.CanGoBack)
            //NavigationService.RemoveBackEntry();

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            //while (NavigationService.CanGoBack)
            //NavigationService.RemoveBackEntry();

        }

        protected override void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            // displays "Fragment: Detail"
            //MessageBox.Show("Folder Id: " + e.Fragment);
            base.OnFragmentNavigation(e);
        }

        private void lstBackgroundColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstBackgroundColor.SelectedIndex;
            string backgroundColor = "";
            if (index == 0)
            {
                backgroundColor = "BLA";
            }
            else if (index == 1)
            {
                backgroundColor = "BLU";
            }
            else if (index == 2)
            {
                backgroundColor = "BRO";
            }
            else if (index == 3)
            {
                backgroundColor = "GRA";
            }
            else if (index == 4)
            {
                backgroundColor = "GRE";
            }
            else if (index == 5)
            {
                backgroundColor = "ORA";
            }
            else if (index == 6)
            {
                backgroundColor = "PUR";
            }
            else if (index == 7)
            {
                backgroundColor = "RED";
            }
            else if (index == 8)
            {
                backgroundColor = "YEL";
            }
            else
            {
                backgroundColor = "BLA";
            }

            using (var context = new NameDataContext(NameDataContext.ConnectionString))
            {
                var appSettings = context.AppSettings;
                foreach (var appSetting in appSettings)
                {
                    appSetting.AppBackgroundColor = backgroundColor;
                }
                context.SubmitChanges();
                //CustomMessageBox messageBox = new CustomMessageBox()
                //{
                //    Caption = "BackgroundColor,
                //    Message = "SuccessfulBackgroundColorChanged,
                //    Background = messageBackGround
                //};
                //messageBox.Show();
                MessageBox.Show("Arka Plan Rengi Başarıyla Değiştirildi");
            }
            SetBackgroundColor();
            NavigationService.Navigate(new Uri("/GeneralSettingsPage.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.Navigate(new Uri("/GeneralSettingsPage.xaml", UriKind.Relative));
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //SetBackgroundColor();
        }
    }
}