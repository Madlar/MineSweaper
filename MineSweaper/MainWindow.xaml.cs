using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MineSweaper
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private int level=1;
        private int row=10;
        private int col=10;
        private int bomb=10;
        private int[] bombLocation;
        GameOption gameOption = null;

        public MainWindow()
        {
            InitializeComponent();
            GameStart();
            Content = screen;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.Title = "Minesweaper";
        }

        private void GameStart()
        {
            play_board.Children.Clear();
            SetCondition(level);

            bombLocation = new int[row * col];
            LocatingBomb locater = new LocatingBomb(row * col, bomb);
            bombLocation = locater.Locating();

            play_board.Rows = row;
            play_board.Columns = col;

            for(int i=0; i < row * col; i++)
            {
                Tile ti;
                if (bombLocation[i] == -1)
                {
                    ti = new Tile(-1);
                }
                else
                {
                    ti = new Tile(100);
                }
                ti.MouseLeftButtonDown += new MouseButtonEventHandler(ti_MouseLeftButtonDown);
                ti.MouseRightButtonDown += new MouseButtonEventHandler(ti_MouseRightButtonDown);

                play_board.Children.Add(ti);
            }
            play_board.Width = col * 20;
            play_board.Height = row * 20;
        }

        

        private void ti_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void ti_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tile ti = sender as Tile;
            int value = play_board.Children.IndexOf(ti);
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            GameStart();
        }

        private void SetUp_Click(object sender, RoutedEventArgs e)
        {
            if(gameOption == null)
            {
                //옵션 창 생성
                gameOption = new GameOption();
                //이벤트 연결
                gameOption.LevelInputEvent += new GameOption.LevelInputHandler(GameOption_LevelInputEvent);
                gameOption.ShowDialog();
            }
        }

        void GameOption_LevelInputEvent(int parameter)
        {
            level = parameter;
            SetCondition(level);
            GameStart();
            if(gameOption !=null)//옵션 창이 살아있을 경우
            {
                gameOption.Close();
                //이벤트 연결 해제
                gameOption.LevelInputEvent -= new GameOption.LevelInputHandler(GameOption_LevelInputEvent);
                gameOption = null;
            }
        }

        private void SetCondition(int level)
        {
            if (level == 1)
            {
                row = 10;
                col = 10;
                bomb = 10;
            }
            else if (level == 2)
            {
                row = 16;
                col = 16;
                bomb = 40;
            }
            else if(level==3)
            {
                row = 16;
                col = 30;
                bomb = 99;
            }
        }
    }
}
