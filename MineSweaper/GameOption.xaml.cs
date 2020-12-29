using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MineSweaper
{
    /// <summary>
    /// GameOption.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GameOption : Window
    {
        private int level = 1;

        public delegate void LevelInputHandler(int parameter);
        public event LevelInputHandler LevelInputEvent;

        public GameOption()
        {
            InitializeComponent();
        }

        public int LevelSet()
        {
            return level;
        }

        private void rb_lv1_Checked(object sender, RoutedEventArgs e)
        {
            level = 1;
        }

        private void rb_lv2_Checked(object sender, RoutedEventArgs e)
        {
            level = 2;
        }

        private void rb_lv3_Checked(object sender, RoutedEventArgs e)
        {
            level = 3;
        }

        private void btn_set_option_Click(object sender, RoutedEventArgs e)
        {
            if (LevelInputEvent != null)
                LevelInputEvent(level);
            this.Close();
        }
    }
}
