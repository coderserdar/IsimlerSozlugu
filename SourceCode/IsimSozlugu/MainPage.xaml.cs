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
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton button1 = new ApplicationBarIconButton();
            button1.IconUri = new Uri("/Assets/Add.png", UriKind.Relative);
            button1.Text = "İsim Ekle";
            ApplicationBar.Buttons.Add(button1);
            button1.Click += new EventHandler(AddNameButton_Click);

            ApplicationBarIconButton button2 = new ApplicationBarIconButton();
            button2.IconUri = new Uri("/Assets/Search.png", UriKind.Relative);
            button2.Text = "Ara";
            ApplicationBar.Buttons.Add(button2);
            button2.Click += new EventHandler(SearchButton_Click);

            ApplicationBarIconButton button3 = new ApplicationBarIconButton();
            button3.IconUri = new Uri("/Assets/Settings.png", UriKind.Relative);
            button3.Text = "Ayarlar";
            ApplicationBar.Buttons.Add(button3);
            button3.Click += new EventHandler(SettingsButton_Click);

            ApplicationBarIconButton button4 = new ApplicationBarIconButton();
            button4.IconUri = new Uri("/Assets/Statistics.png", UriKind.Relative);
            button4.Text = "İstatistikler";
            ApplicationBar.Buttons.Add(button4);
            button4.Click += new EventHandler(StatisticsButton_Click);

            ApplicationBarMenuItem menuItem1 = new ApplicationBarMenuItem();
            menuItem1.Text = "Hakkında";
            ApplicationBar.MenuItems.Add(menuItem1);
            menuItem1.Click += new EventHandler(AboutMenuItem_Click);

            SetBackgroundColor();

        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Uygulamadan Çıkmak İstediğinize Emin Misiniz?",
                "Uygulamadan Çık", MessageBoxButton.OKCancel)
                != MessageBoxResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Current.Terminate();
            }
        }

        private void pNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var context = new NameDataContext(NameDataContext.ConnectionString);
            if (pNames.SelectedIndex == 0)
            {
                List<Male> maleNames = context.MaleNames.OrderBy(j => j.MaleName).ToList() as List<Male>;
                List<AlphaKeyGroup<Male>> DataSource = AlphaKeyGroup<Male>.CreateGroups(maleNames,
                    System.Threading.Thread.CurrentThread.CurrentUICulture,
                    (Male a) => { return a.MaleName; }, true);
                llsMaleNames.ItemsSource = DataSource;
            }
            else if (pNames.SelectedIndex == 1)
            {
                List<Female> femaleNames = context.FemaleNames.OrderBy(j => j.FemaleName).ToList() as List<Female>;
                List<AlphaKeyGroup<Female>> DataSource = AlphaKeyGroup<Female>.CreateGroups(femaleNames,
                    System.Threading.Thread.CurrentThread.CurrentUICulture,
                    (Female a) => { return a.FemaleName; }, true);
                llsFemaleNames.ItemsSource = DataSource;
            }
            else if (pNames.SelectedIndex == 2)
            {
                List<Unisex> unisexNames = context.UnisexNames.OrderBy(j => j.UnisexName).ToList() as List<Unisex>;
                List<AlphaKeyGroup<Unisex>> DataSource = AlphaKeyGroup<Unisex>.CreateGroups(unisexNames,
                    System.Threading.Thread.CurrentThread.CurrentUICulture,
                    (Unisex a) => { return a.UnisexName; }, true);
                llsUnisexNames.ItemsSource = DataSource;
            }
            else if (pNames.SelectedIndex == 3)
            {
                List<All> allNames = context.AllNames.OrderBy(j => j.AllName).ToList() as List<All>;
                List<AlphaKeyGroup<All>> DataSource = AlphaKeyGroup<All>.CreateGroups(allNames,
                    System.Threading.Thread.CurrentThread.CurrentUICulture,
                    (All a) => { return a.AllName; }, true);
                llsAllNames.ItemsSource = DataSource;
            }
            else if (pNames.SelectedIndex == 4)
            {
                List<MyUpdate> myUpdates = context.MyUpdates.OrderBy(j => j.MyUpdateName).ToList() as List<MyUpdate>;
                List<All> allNames = new List<All>();
                for (int i = 0; i < myUpdates.Count; i++)
                {
                    var allName = context.AllNames.Where(j => j.AllName.Equals(myUpdates[i].MyUpdateName)).SingleOrDefault() as All;
                    allNames.Add(allName);
                }
                List<AlphaKeyGroup<All>> DataSource = AlphaKeyGroup<All>.CreateGroups(allNames,
                   System.Threading.Thread.CurrentThread.CurrentUICulture,
                   (All a) => { return a.AllName; }, true);
                llsMyUpdates.ItemsSource = DataSource;
            }
            else
            {
                List<Favourite> favourites = context.Favourites.OrderBy(j => j.FavouriteName).ToList() as List<Favourite>;
                List<All> allNames = new List<All>();
                for (int i = 0; i < favourites.Count; i++)
                {
                    var allName = context.AllNames.Where(j => j.AllName.Equals(favourites[i].FavouriteName)).SingleOrDefault() as All;
                    allNames.Add(allName);
                }
                List<AlphaKeyGroup<All>> DataSource = AlphaKeyGroup<All>.CreateGroups(allNames,
                   System.Threading.Thread.CurrentThread.CurrentUICulture,
                   (All a) => { return a.AllName; }, true);
                llsFavourites.ItemsSource = DataSource;
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/GeneralSettingsPage.xaml", UriKind.Relative));
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SearchPage.xaml", UriKind.Relative));
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }
        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/StatisticsPage.xaml", UriKind.Relative));
        }

        private void AddNameButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NameDetailPage.xaml", UriKind.Relative));
            //PhoneApplicationPage_Loaded(this, new RoutedEventArgs());
        }

        private void llsMaleNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var maleName = llsMaleNames.SelectedItem as Male;
            NavigationService.Navigate(new Uri("/NameDetailPage.xaml#" + maleName.MaleName, UriKind.Relative));
        }

        private void llsFemaleNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var femaleName = llsFemaleNames.SelectedItem as Female;
            NavigationService.Navigate(new Uri("/NameDetailPage.xaml#" + femaleName.FemaleName, UriKind.Relative));
        }

        private void llsUnisexNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var unisexName = llsUnisexNames.SelectedItem as Unisex;
            NavigationService.Navigate(new Uri("/NameDetailPage.xaml#" + unisexName.UnisexName, UriKind.Relative));
        }

        private void llsAllNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var allName = llsAllNames.SelectedItem as All;
            NavigationService.Navigate(new Uri("/NameDetailPage.xaml#" + allName.AllName, UriKind.Relative));
        }

        private void llsFavourites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var favourite = llsFavourites.SelectedItem as Favourite;
            var favourite = llsFavourites.SelectedItem as All;
            NavigationService.Navigate(new Uri("/NameDetailPage.xaml#" + favourite.AllName, UriKind.Relative));
        }

        private void llsMyUpdates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //var myUpdate = llsMyUpdates.SelectedItem as MyUpdate;
            var myUpdate = llsMyUpdates.SelectedItem as All;
            NavigationService.Navigate(new Uri("/NameDetailPage.xaml#" + myUpdate.AllName, UriKind.Relative));
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

        private void llsFavourites_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
        }

        private void RemoveMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}