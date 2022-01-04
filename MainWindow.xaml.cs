using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Virsta_Roxana_Proiect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private int mNikeSneakers = 0;
        private int mPumaSneakers = 0;
        private int mVansSneakers = 0;
        private int mAdidasSneakers = 0;
        private double Total = 0;
        private SneakerType selectedSneaker;

        private void NikeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mNikeSneakers++;
            txtNikeSneakers.Text = mNikeSneakers.ToString();
        }

        private void PumaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mPumaSneakers++;
            txtPumaSneakers.Text = mPumaSneakers.ToString();
        }

        private void VansMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mVansSneakers++;
            txtVansSneakers.Text = mVansSneakers.ToString();
        }

        private void AdidasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mAdidasSneakers++;
            txtAdidasSneakers.Text = mAdidasSneakers.ToString();
        }
        
        private void SneakersItemsShow_Click(object sender, RoutedEventArgs e)
        {
            string mesaj;
            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            mesaj = SelectedItem.Header.ToString() + " The order is being processed!";
            this.Title = mesaj;

        }

        KeyValuePair<SneakerType, double>[] PriceList = {
            new KeyValuePair<SneakerType, double>(SneakerType.Nike,100),
            new KeyValuePair<SneakerType, double>(SneakerType.Puma,80),
            new KeyValuePair<SneakerType, double>(SneakerType.Vans,200),
            new KeyValuePair<SneakerType, double>(SneakerType.Adidas,150)

        };

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            cmbType.ItemsSource = PriceList;
            cmbType.DisplayMemberPath = "Key";
            cmbType.SelectedValuePath = "Value";
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPrice.Text = cmbType.SelectedValue.ToString();
            KeyValuePair<SneakerType, double> selectedEntry =
             (KeyValuePair<SneakerType, double>)cmbType.SelectedItem;
            selectedSneaker = selectedEntry.Key;
        
        }
        
        private int ValidateQuantity(SneakerType selectedSneaker)
        {
            int q = int.Parse(txtQuantity.Text);
            int r = 1;
            
            switch (selectedSneaker)
            {
                case SneakerType.Nike:
                    if (q > mNikeSneakers)
                        r = 0;
                    break;
                case SneakerType.Puma:
                    if (q > mPumaSneakers)
                        r = 0;
                    break;
                case SneakerType.Vans:
                    if (q > mVansSneakers)
                        r = 0;
                    break;
                case SneakerType.Adidas:
                    if (q > mAdidasSneakers)
                        r = 0;
                    break;
            }
            return r;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuantity(selectedSneaker) > 0)
            {
                lstSale.Items.Add(txtQuantity.Text + " " + selectedSneaker.ToString() +
":" + txtPrice.Text + " " + double.Parse(txtQuantity.Text) *
double.Parse(txtPrice.Text));
                Total = Total + double.Parse(txtQuantity.Text) * double.Parse(txtPrice.Text);
                txtTotal.Text = Total.ToString();
            }
            else
            {
                MessageBox.Show("Cantitatea introdusa nu este disponibila in stoc!");

            }
        }
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            lstSale.Items.Remove(lstSale.SelectedItem);
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            txtTotal.Text = "0";
            foreach (string s in lstSale.Items)
            {
                switch (s.Substring(s.IndexOf(" ") + 1, s.IndexOf(":") - s.IndexOf(" ") -
               1))
                {
                    case "Nike":
                        mNikeSneakers = mNikeSneakers - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtNikeSneakers.Text = mNikeSneakers.ToString();
                        break;
                    case "Puma":
                        mPumaSneakers = mPumaSneakers - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtPumaSneakers.Text = mPumaSneakers.ToString();
                        break;
                    case "Vans":
                        mVansSneakers = mVansSneakers - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtVansSneakers.Text = mVansSneakers.ToString();
                        break;
                    case "Adidas":
                        mAdidasSneakers = mAdidasSneakers - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtAdidasSneakers.Text = mAdidasSneakers.ToString();
                        break;
                    
                }
            }
            lstSale.Items.Clear();
        }
        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }
    }

}
