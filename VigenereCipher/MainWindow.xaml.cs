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
using System.Windows.Media.Animation;

namespace VigenereCipher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cipherText_GotFocus(object sender, RoutedEventArgs e)
        {
            if (cipherText.Text.Length == 0)
                return;

            try
            {
                Clipboard.SetText(cipherText.Text);
                showNotify();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                System.Threading.Thread.Sleep(0);
                try
                {
                    Clipboard.SetText(cipherText.Text);
                    showNotify();
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("Can't Access Clipboard");
                }
            }
        }

        private void showNotify()
        {
            var cak = new ColorAnimationUsingKeyFrames();
            cak.KeyFrames.Add(new DiscreteColorKeyFrame()
            {
                Value = Colors.White,
                KeyTime = TimeSpan.FromSeconds(0),
            });
            cak.KeyFrames.Add(new EasingColorKeyFrame()
            {
                Value = Colors.Green,
                KeyTime = TimeSpan.FromSeconds(0.2),
                EasingFunction = new QuarticEase() { EasingMode = EasingMode.EaseOut }
            });
            cak.KeyFrames.Add(new EasingColorKeyFrame()
            {
                Value = Colors.White,
                KeyTime = TimeSpan.FromSeconds(1.7),
                EasingFunction = new ExponentialEase() { EasingMode = EasingMode.EaseInOut }
            });
            this.Background = new SolidColorBrush(Colors.White);
            this.Background.BeginAnimation(SolidColorBrush.ColorProperty, cak);
        }
    }
}
