using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Arkanoid
{
    public partial class FormArkanoid : Form
    {
        // мячик 
        ClassBall Ball;
        // ракетка
        ClassRacket Racket;
        // класс управления движением мячика
        ClassMoving Moving;

        bool GameOver = false;
                     
        public FormArkanoid()
        {
            InitializeComponent();
        }

        private void FormArkanoid_Load(object sender, EventArgs e)
        {
            // создание мячика и ракетки (и отрисовка на панели)
            Ball = new ClassBall(panel1);
            Ball.BallLost += new ClassBall.BallLost_event(Ball_BallLost);
            Racket = new ClassRacket(panel1);
            
            timerArkanoid.Interval = 1;
            
            Moving = new ClassMoving(Ball, Racket, panel1.Size);
            Moving.BallCrossing += new ClassMoving.BallCrossing_event(Moving_BallCrossing);
            Moving.ToNextLevel += new ClassMoving.ToNextLevel_event(Moving_ToNextLevel);
            Moving.NoLevels += new ClassMoving.NoLevels_event(Moving_NoLevels);
            
            // Новая игра: загрузка карты уровня - случайно
            NewGame("Случайно");
        }

        void Moving_NoLevels()
        {
            MessageBox.Show("Больше уровней не найдено");
            GameOver = true;
            NewGame("Случайно");
        }

        // переход на следующий уровень - очистка игрового поля
        void Moving_ToNextLevel()
        {
            timerArkanoid.Stop();
            MessageBox.Show("Ура! Вы переходите на следующий уровень!");
            if (ClassConstants.Level == 0) NewGame("Случайно");
            else
            {
                ++ClassConstants.Level;
                NewGame(ClassConstants.Level.ToString());
            }
        }

        // перерисовка и пересчет очков после соударения мяча и препятствия
        void Moving_BallCrossing()
        {
            panel1.Invalidate();
            statusPoints.Text = "Очки: " + (++ClassConstants.Count_Points).ToString();
        }

        // новая игра
        void NewGame(string Mode)
        {
            if (GameOver)
            {
                ClassConstants.Count_Points = 0;
                ClassConstants.Count_Balls = 3;
                statusBallCount.Text = "Мячей: " + ClassConstants.Count_Balls;
                statusPoints.Text = "Очки: " + ClassConstants.Count_Points;
            }
            Moving.NewGameMode(Mode);
            Ball.BallParams(panel1.ClientRectangle);
            Racket.RacketParams(panel1.ClientRectangle);
            panel1.Invalidate();
            GameOver = false;
            
        }

        // Потеря мячика: окончание игры или уменьшение количества мячей
        void Ball_BallLost()
        {
            ClassConstants.Count_Balls--;
            if (ClassConstants.Count_Balls < 0)
            {
                timerArkanoid.Stop();
                MessageBox.Show("Количество набранных очков: " + ClassConstants.Count_Points.ToString(), "Игра окончена");
                ClassCheckRecords Records = new ClassCheckRecords();
                Records.CheckRecords(ClassConstants.Count_Points);
                GameOver = true;
                return;
            }
            statusBallCount.Text = "Мячей: " + ClassConstants.Count_Balls.ToString();
            statusGame.Text = "Нажмите Enter";
            Ball.BallParams(panel1.ClientRectangle);
            Racket.RacketParams(panel1.ClientRectangle);
            timerArkanoid.Stop();
        }

        // управление ракеткой с клавиатуры
        private void FormArkanoid_KeyDown(object sender, KeyEventArgs e)
        {
            // движение ракетки
            if (e.KeyCode == Keys.Left)
            {
                Racket.RacketToLeft();
            }
            else
                if (e.KeyCode == Keys.Right)
                {
                    Racket.RacketToRight();
                }
                else
                {
                    Racket.RacketStop();
                }
            // начало игры
            if (e.KeyCode == Keys.Enter)
                    {
                    if (!GameOver)
                        timerArkanoid.Start();
                        statusGame.Text = "";
                    }
            // пауза 
            if (e.KeyCode == Keys.P)
            {
                if (timerArkanoid.Enabled == false) timerArkanoid.Start();
                else timerArkanoid.Stop();
            }
            // выход 
        }

        // движение мячика по таймеру
        private void timerArkanoid_Tick(object sender, EventArgs e)
        {
            Moving.BallMove();
        }

        // при перерисовки панели
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(panel1.BackColor);
            Moving.OnPaint(e.Graphics);
        }

        // нажатие паузы в меню
        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timerArkanoid.Enabled == false) timerArkanoid.Start();
            else timerArkanoid.Stop();
        }

        // нажатие меню "начать"
        private void начатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerArkanoid.Start();
            statusGame.Text = "";
        }

       
        private void случайноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerArkanoid.Stop();
            GameOver = true;
            ClassConstants.Level = 0;
            NewGame("Случайно");
        }

        
        private void новаяtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timerArkanoid.Enabled)
            {
                timerArkanoid.Stop();
                if (MessageBox.Show("Начать заново?", "Вы уверены?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    NewGame("Случайно");
                }
                else
                    timerArkanoid.Start();
            }
            else
            {
                NewGame("Случайно");
            }
            ClassConstants.Count_Points = 0;
        }

        private void поПорядкуtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerArkanoid.Stop();
            GameOver = true;
            ClassConstants.Level = 1;
            NewGame(ClassConstants.Level.ToString());
        }

        private void рекордыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTableRecs Ftr = new FormTableRecs();
            Ftr.ShowDialog();

        }

        private void FormArkanoid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            Racket.RacketStop();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       


        //-------------
    }
}
