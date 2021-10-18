using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Tasks;
using IsimSozlugu.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace IsimSozlugu
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();

            SetBackgroundColor();

            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton button2 = new ApplicationBarIconButton();
            button2.IconUri = new Uri("/Assets/SendWithMail.png", UriKind.Relative);
            button2.Text = "İletişime Geç";
            ApplicationBar.Buttons.Add(button2);
            button2.Click += new EventHandler(SendMailButton_Click);

            ApplicationBarIconButton button3 = new ApplicationBarIconButton();
            button3.IconUri = new Uri("/Assets/Rate.png", UriKind.Relative);
            button3.Text = "Puanla";
            ApplicationBar.Buttons.Add(button3);
            button3.Click += new EventHandler(RateButton_Click);

            //lblAboutTheApp.Text = AppResources.AboutTheApp;
            //txtAbout2.Text = AppResources.AboutTheAppText;
            //var paragraph = new Paragraph();
            //paragraph.Inlines.Add(AppResources.AboutTheAppText);
            //txtAbout.Blocks.Add(paragraph);
            txtAbout.Text = "Herkes kendi isminin ne anlama geldiğini merak eder. Bu uygulama ile sadece kendi" +
                " isminizin değil aynı zamanda pek çok ismin de anlamını öğrenebileceksiniz." + 
                " Yeni baba veya anne olacak insanların (benim gibi) aklında çocuğuna ne isim koyacağı gibi" +
                " bir soru olmaması için (yani aslında biraz da kendim için) bu uygulamayı geliştirdim." +
                " Ancak bu uygulamayı hep beraber geliştirebiliriz. Program vasıtasıyla bana göndereceğiniz " +
                " kelimeler incelendikten sonra bu havuza atılacak ve herkesin yararlanabileceği güzel bir " +
                " kaynak ortaya çıkacak. Şimdiden iyi günler.";
            //txtAbout.IsEnabled = false;
            txtAbout.IsReadOnly = true;
            //this.LayoutRoot.Background = new SolidColorBrush(Colors.Green);
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private void SendMailButton_Click(object sender, EventArgs e)
        {
            // burada birden fazla e-posta hesabı varsa birini seçmesi söyleniyor
            //EmailAddressChooserTask emailAddressChooserTask;
            //emailAddressChooserTask = new EmailAddressChooserTask();
            //emailAddressChooserTask.Completed += new EventHandler<EmailResult>(emailAddressChooserTask_Completed);
            //emailAddressChooserTask.Show();
            StringBuilder sb = new StringBuilder();
            EmailComposeTask emailComposeTask = new EmailComposeTask();


            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("İsim Sözlüğü Uygulaması İle Gönderildi");

            emailComposeTask.Subject = "İsim Sözlüğü Uygulaması Hakkında";
            emailComposeTask.Body = sb.ToString();
            emailComposeTask.To = "coderserdar@outlook.com";
            emailComposeTask.Cc = "";
            emailComposeTask.Bcc = "";

            emailComposeTask.Show();
            //MessageBox.Show(AppResources.SuccessfulSendWithMail);
        }

        private void RateButton_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
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
    }
}