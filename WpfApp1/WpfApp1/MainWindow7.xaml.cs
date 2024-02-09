using Reactive.Bindings;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow7 : Window
    {
        public ObservableCollection<Detail> Items { get; } = new ObservableCollection<Detail>();

        public MainWindow7()
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

            for (int columnIndex = 0; columnIndex < 200; ++columnIndex)
            {
                var rectangle = new FrameworkElementFactory(typeof(Rectangle));
                rectangle.SetValue(Rectangle.HeightProperty, 10.0);
                rectangle.SetValue(Rectangle.WidthProperty, 10.0);

                if (columnIndex % 5 == 0)
                {
                    rectangle.SetValue(Rectangle.FillProperty, Brushes.LightSkyBlue);
                }
                else
                {
                    rectangle.SetValue(Rectangle.FillProperty, Brushes.Blue);
                }

                rectangle.SetValue(Rectangle.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                rectangle.SetValue(Rectangle.VerticalAlignmentProperty, VerticalAlignment.Center);

                var cellTemplate = new DataTemplate(typeof(DataGridTemplateColumn));
                cellTemplate.VisualTree = rectangle;

                var column = new DataGridTemplateColumn();
                column.CellTemplate = cellTemplate;

                grid.Columns.Add(column);
            }

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
            var window = new MainWindow6();
            window.Show();

            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();

            this.Close();
        }
    }
}