using System.Windows;

namespace Matrix
{
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
