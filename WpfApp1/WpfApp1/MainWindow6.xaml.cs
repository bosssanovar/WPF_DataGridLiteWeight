using Reactive.Bindings;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow6 : Window
    {
        public Collection<Detail> Items { get; } = new Collection<Detail>();

        public MainWindow6()
        {
            for (int i = 0; i < 200; i++)
            {
                Items.Add(new Detail());
            }

            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            Cursor = Cursors.Wait;

            grid.Visibility = Visibility.Visible;

            Dispatcher.InvokeAsync(new Action(() =>
            {
                Cursor = null;
            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow2();
            window.Show();

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow3();
            window.Show();

            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow4();
            window.Show();

            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow5();
            window.Show();

            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();

            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow7();
            window.Show();

            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow8();
            window.Show();

            this.Close();
        }
    }
}