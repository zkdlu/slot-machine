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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScollLoop
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private Border CreateScrollingImage(string path)
        {
            var anim = new RectAnimation() { To = new Rect(0, 0, 1, 1), RepeatBehavior = RepeatBehavior.Forever };
            Storyboard.SetTargetProperty(anim, new PropertyPath("Background.(ImageBrush.Viewport)"));
            var imageConverter = new ImageSourceConverter();

            return new Border()
            {
                Width = 300,
                Height = 300,
                Style = new Style()
                {
                    TargetType = typeof(Border),
                    Triggers =
            {
                new System.Windows.EventTrigger()
                {
                    RoutedEvent = FrameworkElement.LoadedEvent,
                    Actions =
                    {
                        new BeginStoryboard()
                        {
                            Storyboard = new Storyboard()
                            {
                                Children =
                                {
                                    anim
                                }
                            }
                        }
                    }
                }
            }
                },
                Background = new ImageBrush()
                {
                    ImageSource = (ImageSource)imageConverter.ConvertFromString(path),
                    Viewport = new Rect(0, 1, 1, 1),
                    TileMode = TileMode.Tile
                }
            };
        }
    }
}
