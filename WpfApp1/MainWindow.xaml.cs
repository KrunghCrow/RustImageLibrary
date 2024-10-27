using System;
using System.Collections.Generic; // Required for List<string>
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows; // Ensure this is used for WPF
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Forms; // This is for WinForms, ensure to use only where needed
using System.Windows.Shapes;
using RustImageLibrary;

namespace WelcomeApp
{
    public partial class MainWindow : Window
    {
        private readonly ImageAssetManager assetManager; // Field for the asset manager

        public MainWindow()
        {
            InitializeComponent();
            assetManager = new ImageAssetManager(); // Initialize the asset manager
            Loaded += MainWindow_Loaded;
            StateChanged += MainWindow_StateChanged;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Loaded(object sender , RoutedEventArgs e)
        {
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            var screenHeight = SystemParameters.PrimaryScreenHeight;

            var offsetWidth = screenWidth * 0.50;
            var offsetHeight = screenHeight * 0.25;

            Width = screenWidth - offsetWidth;
            Height = screenHeight - offsetHeight;

            Left = (screenWidth - Width) / 2;
            Top = (screenHeight - Height) / 2;

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            VersionTextBlock.Text = $"Version {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        private void MainWindow_StateChanged(object sender , EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                // Handle when window is maximized
            }
            else if (WindowState == WindowState.Normal)
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
            }
        }

        private void MainWindow_Closing(object sender , CancelEventArgs e)
        {
            Loaded -= MainWindow_Loaded;
            StateChanged -= MainWindow_StateChanged;
        }

        private void ExitMenuItem_Click(object sender , RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown(); // Specify namespace
        }

        private void InfoMenuItem_Click(object sender , RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.ShowDialog();
        }

        private void ToggleBorderless_Click(object sender , RoutedEventArgs e)
        {
            if (this.WindowStyle == WindowStyle.None)
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
            }
            else
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
        }

        private void ColorPickerMenuItem_Click(object sender , RoutedEventArgs e)
        {
            LoadColorPicker();
        }

        private void LoadAvatars(string type)
        {
            ColorWrapPanel.Children.Clear();
            AvatarsWrapPanel.Children.Clear();

            // Initialize ImageAssetManager to access image paths
            ImageAssetManager assetManager = new ImageAssetManager();

            string avatarsFolder = System.IO.Path.Combine(Environment.CurrentDirectory , "Resources" , type); // Fully qualify Path

            if (Directory.Exists(avatarsFolder))
            {
                string[] imageFiles = Directory.GetFiles(avatarsFolder , "*.*" , SearchOption.TopDirectoryOnly)
                    .Where(s => s.EndsWith(".png" , StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".jpg" , StringComparison.OrdinalIgnoreCase) ||
                                s.EndsWith(".jpeg" , StringComparison.OrdinalIgnoreCase))
                    .ToArray();

                foreach (string imagePath in imageFiles)
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                    ImageBrush backgroundBrush = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/Backgrounds/ItemBackground.png" , UriKind.Absolute)) ,
                        Stretch = Stretch.UniformToFill
                    };

                    string fileName = System.IO.Path.GetFileNameWithoutExtension(imagePath); // Fully qualify Path here
                    StackPanel stackPanel = new StackPanel
                    {
                        Orientation = System.Windows.Controls.Orientation.Vertical ,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Center ,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    TextBlock textBlock = new TextBlock
                    {
                        Text = fileName ,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Center ,
                        Margin = new Thickness(0 , 5 , 0 , 0) ,
                        FontSize = 12 ,
                        Foreground = Brushes.White
                    };

                    Image avatarImage = new Image
                    {
                        Source = bitmap ,
                        Width = 150 ,
                        Height = 150 ,
                        Margin = new Thickness(0)
                    };

                    // Add click event to the avatar image
                    avatarImage.MouseDown += (s , e) => OnAvatarImageClick(fileName);

                    stackPanel.Children.Add(avatarImage);
                    stackPanel.Children.Add(textBlock);

                    // Use ImageAssetManager to check if the asset path is available
                    string assetPath = assetManager.GetAssetPath(fileName);
                    bool assetPathExists = !string.IsNullOrEmpty(assetPath);

                    // Create border and set color based on asset path existence
                    Border border = new Border
                    {
                        Width = 180 ,
                        Height = 180 ,
                        Margin = new Thickness(15) ,
                        BorderBrush = assetPathExists ? Brushes.LightGreen : Brushes.Red , // Set color based on asset path availability
                        BorderThickness = new Thickness(2) ,
                        Background = backgroundBrush ,
                        Child = stackPanel
                    };

                    AvatarsWrapPanel.Children.Add(border);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("The Avatars folder does not exist." , "Error" , MessageBoxButton.OK , MessageBoxImage.Error);
            }
        }

        private void OnAvatarImageClick(string fileName)
        {
            // Get the asset path from the asset manager
            string assetPath = assetManager.GetAssetPath(fileName);
            if (!string.IsNullOrEmpty(assetPath))
            {
                // Copy the asset path to the clipboard
                System.Windows.Clipboard.SetText(assetPath);
                System.Windows.MessageBox.Show($"Asset path or skin ID for `{fileName}` was copied to the clipboard.\n\n'{assetPath}'" , "Success" , MessageBoxButton.OK , MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show($"Assetpath or skinID for `{fileName}` was not found in the dictionary.\n\nWant to help ? then you could send me the image in the correct name with the assetpath or skin id." , "Not found." , MessageBoxButton.OK , MessageBoxImage.Error);
            }
        }

        private void LoadAvatarsMenuItem_Click(object sender , RoutedEventArgs e)
        {
            LoadAvatars("Avatars");
        }

        private void LoadIconMenuItem_Click(object sender , RoutedEventArgs e)
        {
            LoadAvatars("Icons");
        }

        private void LoadBackgroundMenuItem_Click(object sender , RoutedEventArgs e)
        {
            LoadAvatars("Backgrounds");
        }

        private void LoadCustomMenuItem_Click(object sender , RoutedEventArgs e)
        {
            LoadAvatars("Custom");
        }

        private void LoadPluginMenuItem_Click(object sender , RoutedEventArgs e)
        {
            LoadAvatars("PluginIcons");
        }

        private void LoadColorPicker()
        {
            ColorWrapPanel.Children.Clear();
            AvatarsWrapPanel.Children.Clear();

            // Define some hardcoded hex color codes and their descriptions
            var colors = new Dictionary<string , string>
            {
                { "#cd4632", "Rust Logo Red" },
                { "#f8ece2", "Rust Logotext White" },
                { "#8cc83c", "Rust Button Green" },
                { "#42332d", "Rust Brown"},
                { "#27261e", "Rust Dark Brown"},
                { "#453e2e", "Rust Lighter Brown"},
                { "#da0e0b", "Rust Treemarker Red"},
                { "#7ba137", "Rust Health bar"},
                { "#b56830", "Rust Hunger bar"},
                { "#488cc0", "Rust Hydration bar" },
                { "#95d22f", "Rust Team name"},
                { "#a03104", "Rust Enemy name"},
                { "#1989df", "Rust Ally name"},
                { "#e90804", "Rust Monument block"},
                { "#e44849", "Rust Mushroom"},
                { "#e41d1a", "Rust Holosight"},
                { "#de4647", "Rust Laser detector" },
                { "#5865F2", "Discord Blue" },
                { "#57F287", "Discord Green" },
                { "#FEE75C", "Discord Yellow" },
                { "#EB459E", "Discord Fuchsia"},
                { "#ED4245", "Discord Red" },
                { "#000000", "Web Black" },
                { "#FFFFFF", "Web White"},
                { "#FF0000", "Web Red" },
                { "#008000", "Web Green" },
                { "#0000FF", "Web Blue" },
                { "#FFFF00", "Web Yellow" },
                { "#00FFFF", "Web Cyan" },
                { "#FF00FF", "Web Magenta" },
                { "#808080", "Web Gray" },
                { "#A9A9A9", "Web Dark Gray" },
                { "#D3D3D3", "Web Light Gray" },
                { "#FFA500", "Web Orange" },
                { "#800080", "Web Purple" },
                { "#A52A2A", "Web Brown" },
                { "#808000", "Web Olive" },
                { "#008080", "Web Teal" },
                { "#000080", "Web Navy" },
                { "#00FF00", "Web Lime" },
                { "#C0C0C0", "Web Silver" },
                { "#FF7F50", "Web Coral" },
                { "#4B0082", "Web Indigo" },
                { "#a90dd6", "Krungh Purple"}
            };

            foreach (var color in colors)
            {
                // Create a Grid to hold the rectangle and text
                Grid colorGrid = new Grid
                {
                    Width = 150 ,
                    Height = 150 ,
                    Margin = new Thickness(5)
                };

                // Create a color rectangle
                System.Windows.Shapes.Rectangle colorRectangle = new System.Windows.Shapes.Rectangle
                {
                    Fill = (SolidColorBrush)(new BrushConverter().ConvertFromString(color.Key)) ,
                    Stroke = Brushes.Black , // Add a border for better visibility
                    StrokeThickness = 1
                };

                // Add click event to the rectangle
                colorRectangle.MouseDown += (s , e) => OnColorClick(color.Key , color.Value);

                // Determine the text color based on the background color
                Brush textColor = (color.Key == "#FEE75C" || color.Key == "#FFFF00" || color.Key == "#FFFFFF" || color.Key == "#f8ece2" || color.Key == "#57F287") ? Brushes.Black : Brushes.White;

                // Create a TextBlock for the hex code
                TextBlock hexTextBlock = new TextBlock
                {
                    Text = color.Key ,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center ,
                    VerticalAlignment = System.Windows.VerticalAlignment.Bottom , // Position it at the bottom
                    FontSize = 12 ,
                    Foreground = textColor , // Set the text color based on the rectangle color
                    Background = Brushes.Transparent // Make background transparent
                };

                // Create a TextBlock for the color name
                TextBlock nameTextBlock = new TextBlock
                {
                    Text = color.Value ,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center ,
                    VerticalAlignment = System.Windows.VerticalAlignment.Top ,
                    FontSize = 12 ,
                    Foreground = textColor , // Set the name text color similarly
                    Margin = new Thickness(0 , 5 , 0 , 0) // Add some margin for the name
                };

                // Add the rectangle and text to the Grid
                colorGrid.Children.Add(colorRectangle);
                colorGrid.Children.Add(hexTextBlock);
                colorGrid.Children.Add(nameTextBlock);

                // Add the Grid to the ColorWrapPanel
                ColorWrapPanel.Children.Add(colorGrid);
            }
        }

        private void OnColorClick(string colorCode, string textColor)
        {
            // Copy the color code to the clipboard
            System.Windows.Clipboard.SetText(colorCode);
            System.Windows.MessageBox.Show($"Color code '{colorCode}' copied to clipboard.\n{textColor}" , "Color Copied" , MessageBoxButton.OK , MessageBoxImage.Information);
        }
    }
}
