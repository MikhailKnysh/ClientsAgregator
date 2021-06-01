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
using System.Windows.Threading;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Неизменяемая система исчисления.
        const double NumberSystem = 60;

        // Количество градусов на единицу системы исчисления.
        // Базовый угол для минут и секунд.
        const double baseAngleNumberSystem = 360 / NumberSystem;

        // Базовый угол для часов.
        const double baseAngleHour = 30;
        public MainWindow()
        {
            InitializeComponent();
            StartClock();
        }
        #region Вычисление текущего времени

        private void Timer_Tick(object sender, EventArgs e)
        {
            var rotateSecondArrow = new RotateTransform();
            var rotateMinuteArrow = new RotateTransform();
            var rotateHourArrow = new RotateTransform();


            // Данные текущего времени.
            int sec = DateTime.Now.Second;
            int min = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;



            // Вычисленный угол для секундной стрелки.
            rotateSecondArrow.Angle = baseAngleNumberSystem * sec;

            // Вращение стрелки на вычисленный угол.
            SecondArrow.RenderTransform = rotateSecondArrow;



            // Угол минутной стрелки от количества полных минут плюс
            // угол секунд приведенный к долям текущей минуты.
            rotateMinuteArrow.Angle = (min * baseAngleNumberSystem) + (rotateSecondArrow.Angle / 60.0);

            MinuteArrow.RenderTransform = rotateMinuteArrow;



            // Данные часа конвертируем в 12-часовой вид,
            // вычисляем угол полных часов плюс
            // угол минут приведенный к долям текущего часа.
            rotateHourArrow.Angle = (hour - 12) * baseAngleHour + rotateMinuteArrow.Angle / 12;

            HourArrow.RenderTransform = rotateHourArrow;



            // После вычисления всех углов и поворотов стрелок,
            // включаем видимость формы.
            this.Show();
        }


        #endregion



        #region Система перемещения окна

        bool move = false;
        Point constPosition;



        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            // Зафиксируем неизменяемую позицию.
            constPosition = e.GetPosition(this);

            // Разрешаем движение.
            move = true;

            // Чтобы мышь не теряла окно, даже если окно скрывается под тормост окнами.
            this.CaptureMouse();

        }



        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

            if (move == true)
            {
                // Вычисляем разницу между бывшим и текущим положением курсора от края окна.
                double deltaX = e.GetPosition(this).X - constPosition.X;
                double deltaY = e.GetPosition(this).Y - constPosition.Y;


                // Положение окна тут же корректируем на вычисленную величину(разницу).
                this.Left += deltaX;
                this.Top += deltaY;
            }

        }



        private void Window_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            // Запрещаем движение и отпускаем мышь.
            move = false;
            this.ReleaseMouseCapture();

        }

        #endregion



        #region Дополнительные методы

        // Запуск часов.
        void StartClock()
        {
            // Скрываем форму пока не заработали часы.
            // После первого события Timer_Tick,
            // когда стрелки скорректируют своё положение,
            // сделаем форму видимой.
            this.Hide();

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        #endregion

    }
}
