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
    public partial class SearchPage : PhoneApplicationPage
    {
        public SearchPage()
        {
            InitializeComponent();
            SetBackgroundColor();

            txtSearchResult.Text = "Arama Sonuçları";
            //txtSearchResult.Text = AppResources.SearchResults;
            //lblSearch.Text = AppResources.Search;
            //btnSearch.Content = AppResources.Search;
            //lstSearch.SelectedIndex = -1;
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            lstSearch.Items.Clear();
            if (txtSearch.Text.TrimStart().Length < 1)
            {
                MessageBox.Show("Arama Alanına En Az Bir Harf Yazmak Zorundasınız");
            }
            else
            {
                using (var context = new NameDataContext(NameDataContext.ConnectionString))
                {
                    var nameList =
                        context.AllNames.Where(j => j.AllNameMeaning.ToLower().Contains(txtSearch.Text.ToLower())).ToList() as List<All>;
                    //var noteList = context.Notes.ToList() as List<Note>;

                    if (nameList != null)
                    {
                        txtSearchResult.Text = "Arama Sonuçları" + " (" + nameList.Count() + ")";
                    }

                    //List<All> allNames = nameList.OrderBy(j => j.AllName).ToList() as List<All>;
                    //List<AlphaKeyGroup<All>> DataSource = AlphaKeyGroup<All>.CreateGroups(allNames,
                    //    System.Threading.Thread.CurrentThread.CurrentUICulture,
                    //    (All a) => { return a.AllName; }, true);
                    //llsAllNames.ItemsSource = DataSource;

                    var nameList2 = nameList.OrderBy(j => j.AllName).ToList() as List<All>;
                    //lstSearch.ItemsSource = nameList;
                    for (int i = 0; i < nameList2.Count; i++)
                    {
                        lstSearch.Items.Add(nameList2[i] as All);
                    }
                    //lstSearch.ItemTemplate.
                    //lstSearch.DisplayMemberPath = "NoteName" + " (" + "CreationDate" + ")";
                    lstSearch.DisplayMemberPath = "AllName";
                    MessageBox.Show("Arama Tamamlandı");
                }
            }
        }

        private void lstSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lstSearch.SelectedIndex != -1)
                {
                    All selectedName = lstSearch.SelectedItem as All;
                    NavigationService.Navigate(new Uri("/NameDetailPage.xaml#" + selectedName.AllName, UriKind.Relative));
                    lstSearch.SelectedIndex = -1;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Sistemde Bir Hata Oluştur. Lütfen Sonra Tekrar Deneyin");
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private void txtSearch_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (txtSearch.Text.TrimStart().Length < 1)
                {
                    MessageBox.Show("Arama Alanına En Az Bir Harf Yazmak Zorundasınız");
                }
                else
                {
                    lstSearch.Items.Clear();
                    using (var context = new NameDataContext(NameDataContext.ConnectionString))
                    {
                        var nameList =
                            context.AllNames.Where(j => j.AllNameMeaning.ToLower().Contains(txtSearch.Text.ToLower())).ToList() as List<All>;
                        //var noteList = context.Notes.ToList() as List<Note>;

                        if (nameList != null)
                        {
                            txtSearchResult.Text = "Arama Sonuçları" + " (" + nameList.Count() + ")";
                        }

                        //List<All> allNames = nameList.OrderBy(j => j.AllName).ToList() as List<All>;
                        //List<AlphaKeyGroup<All>> DataSource = AlphaKeyGroup<All>.CreateGroups(allNames,
                        //    System.Threading.Thread.CurrentThread.CurrentUICulture,
                        //    (All a) => { return a.AllName; }, true);
                        //llsAllNames.ItemsSource = DataSource;

                        var nameList2 = nameList.OrderBy(j => j.AllName).ToList() as List<All>;
                        //lstSearch.ItemsSource = noteList;
                        for (int i = 0; i < nameList2.Count; i++)
                        {
                        //    if (nameList2[i].NameDescriptionWithoutNewline.ToLower(Thread.CurrentThread.CurrentCulture).IndexOf(txtSearch.Text.ToLower(Thread.CurrentThread.CurrentCulture)) != -1)
                        //    {
                            lstSearch.Items.Add(nameList2[i] as All);
                        //    }
                        }
                        //lstSearch.ItemTemplate.
                        //lstSearch.DisplayMemberPath = "NoteName" + " (" + "CreationDate" + ")";
                        lstSearch.DisplayMemberPath = "AllName";
                        MessageBox.Show("Arama Tamamlandı");
                    }
                }
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            txtSearch.Focus();
        }
    }
}