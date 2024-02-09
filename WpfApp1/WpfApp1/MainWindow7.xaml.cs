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

            for (int i = 0; i < 200; ++i)
            {
                var column = new DataGridTextColumn();
                column.Header = $"{i}";
                column.Width = new DataGridLength(18);
                grid.Columns.Add(column);
            }

            grid.Visibility = Visibility.Visible;

            Dispatcher.InvokeAsync(new Action(() =>
            {
                Cursor = null;

                SetScrollEvent();
            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }

        private void EditDataGrid(object sender, RoutedEventArgs e)
        {
            // 行列数
            int rowCount = grid.Items.Count;
            int columnCount = grid.Columns.Count;

            for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
            {
                // データグリッドの行オブジェクトを取得します。
                var row = grid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                // 行オブジェクトが取得できない場合
                if (row is null)
                {
                    // 画面に表示されていないセルはnullとなる
                    continue;
                }

                for (int columnIndex = 0; columnIndex < columnCount; ++columnIndex)
                {
                    var cell = GetCell(columnIndex, row);
                    if( cell is null)
                    {
                        // 画面に表示されていないセルはnullとなる
                        continue;
                    }

                    if (rowIndex % 5 == 0 && columnIndex % 5 == 0)
                    {
                        cell.Background = Brushes.Blue;
                    }
                    else
                    {
                        cell.Background = Brushes.Transparent;
                    }
                }
            }
        }

        private DataGridCell? GetCell(int columnIndex, DataGridRow row)
        {
            // データグリッドのセルオブジェクトを取得します。
            var content = grid.Columns[columnIndex].GetCellContent(row);
            if (content is null)
            {
                // 画面に表示されていないセルはnullとなる
                return null;
            }
            var cell = content.Parent as DataGridCell;
            // データグリッドのセルオブジェクトが取得できない場合
            if (cell is null)
            {
                // 画面に表示されていないセルはnullとなる
                return null;
            }

            return cell;
        }

        private void SetScrollEvent()
        {
            Decorator? child = VisualTreeHelper.GetChild(this.grid, 0) as Decorator;
            if (child is null) return;

            ScrollViewer? sc = child.Child as ScrollViewer;
            if (sc is null) return;

            sc.ScrollChanged += new ScrollChangedEventHandler(EditDataGrid);
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