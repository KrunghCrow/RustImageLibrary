using System.Reflection; // Make sure this line is present
using System.Windows;

namespace RustImageLibrary
{
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();

            // Set the version text dynamically
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            VersionTextBlock.Text = $"Version: {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        // Event handler for the custom Close button
        private void CloseButton_Click(object sender , RoutedEventArgs e)
        {
            this.Close(); // Close the window
        }

    }
}
