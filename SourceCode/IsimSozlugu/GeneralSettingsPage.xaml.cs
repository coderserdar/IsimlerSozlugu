using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using IsimSozlugu.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace IsimSozlugu
{
    public partial class GeneralSettingsPage : PhoneApplicationPage
    {

        public GeneralSettingsPage()
        {
            InitializeComponent();
            SetBackgroundColor();

            using (var context = new NameDataContext(NameDataContext.ConnectionString))
            {
                var appSettings = context.AppSettings.First() as AppSettings;
                if (appSettings.AppBackgroundColor == "BLA")
                {
                    lblBackgroundColor.Text = "Arka Plan Rengi (Seçilen: Siyah)";
                }
                if (appSettings.AppBackgroundColor == "BLU")
                {
                    lblBackgroundColor.Text = "Arka Plan Rengi (Seçilen: Mavi)";
                }
                if (appSettings.AppBackgroundColor == "BRO")
                {
                    lblBackgroundColor.Text = "Arka Plan Rengi (Seçilen: Kahverengi)";
                }
                if (appSettings.AppBackgroundColor == "RED")
                {
                    lblBackgroundColor.Text = "Arka Plan Rengi (Seçilen: Kırmızı)";
                }
                if (appSettings.AppBackgroundColor == "GRE")
                {
                    lblBackgroundColor.Text = "Arka Plan Rengi (Seçilen: Yeşil)";
                }
                if (appSettings.AppBackgroundColor == "YEL")
                {
                    lblBackgroundColor.Text = "Arka Plan Rengi (Seçilen: Sarı)";
                }
                if (appSettings.AppBackgroundColor == "GRA")
                {
                    lblBackgroundColor.Text = "Arka Plan Rengi (Seçilen: Gri)";
                }
                if (appSettings.AppBackgroundColor == "ORA")
                {
                    lblBackgroundColor.Text = "Arka Plan Rengi (Seçilen: Turuncu)";
                }
                if (appSettings.AppBackgroundColor == "PUR")
                {
                    lblBackgroundColor.Text = "Arka Plan Rengi (Seçilen: Mor)";
                }

                lblFontFamily.Text = "Font Ailesi (Seçilen: " + appSettings.FontFamily + ")";
                lblFontSize.Text = "Font Boyutu (Seçilen: " + appSettings.FontSize + ")";

            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SetBackgroundColor();
            //while (NavigationService.CanGoBack)
            //NavigationService.RemoveBackEntry();

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            //while (NavigationService.CanGoBack)
            //NavigationService.RemoveBackEntry();

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

        private void btnBackgroundColor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BackgroundColorSettingsPage.xaml", UriKind.Relative));
        }

        private void btnBackgroundImage_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask objPhotoChooser = new PhotoChooserTask();
            objPhotoChooser.Completed += new EventHandler<PhotoResult>(PhotoChooseCall);
            objPhotoChooser.Show();
        }

        private void PhotoChooseCall(object sender, PhotoResult e)
        {
            switch (e.TaskResult)
            {
                case TaskResult.OK:
                    using (var context = new NameDataContext(NameDataContext.ConnectionString))
                    {
                        var appSettings = context.AppSettings;
                        foreach (var appSetting in appSettings)
                        {
                            appSetting.AppBackgroundImage = new byte[e.ChosenPhoto.Length];
                            e.ChosenPhoto.Position = 0;
                            e.ChosenPhoto.Read(appSetting.AppBackgroundImage, 0, appSetting.AppBackgroundImage.Length);
                            //noteFolder.NoteFolderPassword = "";
                        }
                        context.SubmitChanges();
                        MessageBox.Show("Arka Plan Resmi Başarıyla Değiştirildi");
                    }
                    break;
                case TaskResult.Cancel:
                    //MessageBox.Show("Cancelled");
                    break;
                case TaskResult.None:
                    //MessageBox.Show("Nothing Entered");
                    break;
            }
            SetBackgroundColor();
        }

        private void btnRemoveBackgroundImage_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new NameDataContext(NameDataContext.ConnectionString))
            {
                var appSettings = context.AppSettings;
                foreach (var appSetting in appSettings)
                {
                    appSetting.AppBackgroundImage = null;
                }
                context.SubmitChanges();
                MessageBox.Show("Arka Plan Resmi Başarıyla Kaldırıldı");
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            //pvGeneralSettings.Title = AppResources.GeneralSettings;

            //piLanguage.Header = AppResources.Language;
            //piSync.Header = AppResources.Sync;
            //piOtherSettings.Header = AppResources.OtherSettings;
            //piBackground.Header = AppResources.Background;

            ////lblOneDrive.Text = AppResources.OneDrive;

            //btnCategoryOrder.Content = AppResources.Select;
            //btnCategoryOrderStyle.Content = AppResources.Select;
            //btnLanguage.Content = AppResources.Select;
            //btnBackgroundColor.Content = AppResources.Select;
            ////btnOneDrive.Content = AppResources.Login;
            ////btnOneDrive.SignInText = AppResources.SignIn;
            ////btnOneDrive.SignOutText = AppResources.SignOut;
            //btnOneDriveSync.Content = AppResources.Sync;
            //lblOneDrive.Text = AppResources.OneDrive;
            //txtSyncronizing.Text = AppResources.Synchronizing;

            //pbSync.Visibility = Visibility.Collapsed;
            //txtSyncronizing.Visibility = Visibility.Collapsed;
            //txtSyncronizing.BorderBrush = this.LayoutRoot.Background;

            //btnRemoveBackgroundImage.Content = AppResources.RemoveBackgroundImage;
            //lblBackgroundImage.Text = AppResources.BackgroundImage;
            //btnBackgroundImage.Content = AppResources.Select;
            //btnResetSettings.Content = AppResources.ResetSettings;

            //btnOneDriveSync.IsEnabled = false;
            //cbSync.Content = AppResources.SyncOnOneFile;
            //cbSync.IsEnabled = false;
            //btnOneDrive.Content = "Sign In";

            //SetBackgroundColor();
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private void btnResetSettings_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new NameDataContext(NameDataContext.ConnectionString))
            {
                var appSettings = context.AppSettings;
                foreach (var appSetting in appSettings)
                {
                    appSetting.AppBackgroundImage = null;
                    appSetting.AppBackgroundColor = "BLA";
                }
                context.SubmitChanges();
                this.LayoutRoot.Background = new SolidColorBrush(Colors.Black);
                MessageBox.Show("Arka PLan Ayarları Başarıyla Sıfırlandı");
            }
        }

        private void btnFontSize_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/FontSizeSettingsPage.xaml", UriKind.Relative));
        }

        private void btnFontFamily_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/FontFamilySettingsPage.xaml", UriKind.Relative));
        }
    }
}