using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace Arkanoid
{
    class ClassMoving
    {
        ClassRacket Racket;
        ClassBall Ball;
        // размер площадки, на которой все это будет отрисовано
        Size Size;

        public List<ClassBlock> blocks = new List<ClassBlock>();

        public delegate void BallCrossing_event();
        // событие пересечения мяча с блоком
        public event BallCrossing_event BallCrossing;

        public delegate void ToNextLevel_event();
        // событие очистки поля и перехода на новый уровень 
        public event ToNextLevel_event ToNextLevel;

        public delegate void NoLevels_event();
        // событие очистки поля и перехода на новый уровень 
        public event NoLevels_event NoLevels;
    
        public ClassMoving(ClassBall Ball, ClassRacket Racket, Size Size)
        {
            this.Ball = Ball;
            this.Racket = Racket;
            this.Size = Size;
            LoadMap(RandomMap());
        }

        // преобразование считанной из файла строки в массив символов без пробелов
        public static string[] ToWords(string st, int count_words)
        {
            string[] ar = new string[count_words];
            int i = 0;
            foreach (char ch in st)
            {
                if (ch != ' ')
                {
                    ar[i] += ch;
                }
                else i++;
            }
            return ar;
        }

        // чтение карты уровня из файла
        private string[][] ReadMap(string filename)
        {
            string[][] map;
            // считывание из файла по строчке
            StreamReader sr = File.OpenText(filename);
            string input = null;
            int ind = 0;
            map = new string[ClassConstants.countStrings][];
            while ((input = sr.ReadLine()) != null)
            {
                // преобразование строчки в символы
                map[ind] = new string[ClassConstants.countBlocks];
                map[ind] = ToWords(input, ClassConstants.countBlocks);
                ind++;
            }
            sr.Close();
            // в итоге возвращается карта уровня
            return map;
        }

        // случайный уровень
        private string[][] RandomMap()
        {
            Random Rand = new Random();
            string[][] map;
            map = new string[ClassConstants.countStrings][];
            for (int i = 0; i < ClassConstants.countStrings; i++)
            {
                map[i] = new string[ClassConstants.countBlocks];
                for (int j = 0; j < ClassConstants.countBlocks; j++)
                {
                    map[i][j] = Rand.Next(ClassConstants.Count_Block_Types).ToString();
                }
            }
            return map;
        }

        // загрузить выбранную карту уровня
        public void LoadMap(string[][] Map)
        {
            blocks.Clear();

            // рассчитать размер блока-препятствия пропорционально размерам формы
            int SizeX = Size.Width / 8;
            int LocY = 0;
            int SizeY = Size.Height / 10;
            int LocX = 0;
            Size size; // размер блока
            Point point; // точка положения блока

            // просматриваем карту
            for (int i = 0; i < ClassConstants.countStrings; i++)
            {
                for (int j = 0; j < ClassConstants.countBlocks; j++)
                {
                    // в зависимости от значения карты
                    switch (Map[i][j])
                    {
                        case "0": // пустое место
                            break;
                        case "1": 
                            size = new Size(SizeX, SizeY);
                            point = new Point(LocX, LocY);
                            ClassBlockLifes block = new ClassBlockLifes(size, point, 0);
                            blocks.Add(block); // добавляем в список блоков уровня
                            break;
                        case "2": 
                            size = new Size(SizeX, SizeY);
                            point = new Point(LocX, LocY);
                            ClassBlockLifes block1 = new ClassBlockLifes(size, point, 1);
                            blocks.Add(block1); // добавляем в список блоков уровня
                            break;
                        case "3":
                            size = new Size(SizeX, SizeY);
                            point = new Point(LocX, LocY);
                            ClassBlockLifes block2 = new ClassBlockLifes(size, point, 2);
                            blocks.Add(block2); // добавляем в список блоков уровня
                            break;
                        case "4":
                            size = new Size(SizeX, SizeY);
                            point = new Point(LocX, LocY);
                            ClassBlockSpeed block4 = new ClassBlockSpeed(size, point);
                            block4.BallSpeedLower += new ClassBlockSpeed.BallSpeedEventHandler(block4_BallSpeedLower);
                            blocks.Add(block4); // добавляем в список блоков уровня
                            break;
                        case "5":
                            size = new Size(SizeX, SizeY);
                            point = new Point(LocX, LocY);
                            ClassBlockLength block5 = new ClassBlockLength(size, point);
                            block5.RacketLength += new ClassBlockLength.RacketEventHandler(block5_RacketLength);
                            blocks.Add(block5);
                            break;
                        default:
                            break;
                    }
                    LocX += SizeX;
                }
                LocY += SizeY;
                LocX = 0;
            }
        }

        // при столкновении с блоком типа-5 - ракетка увеличивается на несколько секунд
        void block5_RacketLength()
        {
            Racket.Large();
        }

        // уменьшение скорости мячика и изменение направления движения при столкновении с блоком типа-4 (блок-ветер)
        void block4_BallSpeedLower()
        {
            Ball.Lower();
        }


        // пересечение объектов: шарика и блоков
        private bool ObjectCrossing(Rectangle BlockRec, Rectangle BallRec)
        {
            Point[] P = new Point[4];
            /*Point[] P1 = new Point[4];
            P[0] = new Point(BallRec.Left, BallRec.Top);
            P[1] = new Point(BallRec.Left, BallRec.Bottom);
            P[2] = new Point(BallRec.Right, BallRec.Top);
            P[3] = new Point(BallRec.Right, BallRec.Bottom);
            */
            P[0] = new Point(BallRec.Left + BallRec.Width / 2, BallRec.Top);
            P[1] = new Point(BallRec.Right, BallRec.Top + BallRec.Height / 2);
            P[2] = new Point(BallRec.Left + BallRec.Width / 2, BallRec.Bottom);
            P[3] = new Point(BallRec.Left, BallRec.Top + BallRec.Height / 2);
            
          

            foreach (Point p in P)
            {
                // если содержит хотя бы одну точку общую
                if (BlockRec.Contains(p))
                {
                    // скорость мячика может быть равна 1 или 2
                    if ((BlockRec.Bottom - 2 == BallRec.Top || BlockRec.Top - 2 == BallRec.Bottom
                        || BlockRec.Bottom == BallRec.Top || BlockRec.Top == BallRec.Bottom
                        || BlockRec.Bottom == BallRec.Top + 1 || BlockRec.Top == BallRec.Bottom + 1
                        ))
                        Ball.ReverceY();
                    else
                        Ball.ReverseX();
                    return true;
                }
            }
            return false;
        }

        // пересечение шарика и ракетки
        private bool RacketCrossing(Rectangle RacketRec, Rectangle BallRec)
        {
            Point[] P = new Point[4];
            P[0] = new Point(BallRec.Left, BallRec.Top);
            P[1] = new Point(BallRec.Left, BallRec.Bottom);
            P[2] = new Point(BallRec.Right, BallRec.Top);
            P[3] = new Point(BallRec.Right, BallRec.Bottom);

            foreach (Point p in P)
            {
                // если содержит хотя бы одну точку общую
                if (RacketRec.Contains(p))
                {
                    // в зависимости от движения ракетки: скорости и направления
                    if (Racket.RacketIsStoped)
                    {
                        Ball.ReverceY();
                    }
                    else
                    {
                        // если ракетка и мячик двигались в одном направлении
                        if ((Racket.RacketIsToRight && (Ball.BallSpeedX < 0)))
                        {
                            Ball.BallSpeedX = -2;
                            Ball.BallSpeedY = -1;
                        }
                        else
                        if (!Racket.RacketIsToRight && (Ball.BallSpeedX > 0))
                        {
                            Ball.BallSpeedX = 2;
                            Ball.BallSpeedY = -1;
                        }
                        // если в разных
                        else
                        {
                            if (Ball.BallSpeedX < 0)
                            {
                                Ball.BallSpeedX = -1;
                                Ball.BallSpeedY = -2;
                            }
                            else
                            {
                                Ball.BallSpeedX = 1;
                                Ball.BallSpeedY = -2;
                            }
                        }

                    }
                    return true;
                }
            }
            return false;
        }

        // функция движения мяча
        public void BallMove()
        {
            Rectangle BallRect = Ball.CountNextLocation();
            Rectangle RacketRect = Racket.CountNextLocation();
            if (blocks.Count != 0)
            {
                for (int i = blocks.Count - 1; i >= 0; i--)
                {
                    // если шарик пересекается с препятствием
                    if (ObjectCrossing(blocks[i].Bounds, BallRect))
                    {
                        // если препятствие готово исчезнуть
                        if (blocks[i].Crossing())
                        {
                            blocks.Remove(blocks[i]);
                        }
                        // перерисовать панель, так как блок изменил свое состояние
                        BallCrossing();
                    }
                }
                RacketCrossing(RacketRect, BallRect);
            }
            else
            {
                ToNextLevel();
            }
        }

        // загрузка карты с выбором режима игры
        public void NewGameMode(string Mode)
        {       
            switch (Mode)
            {
                case "Случайно":
                    LoadMap(RandomMap());
                    break;
                default:
                    try
                    {
                        LoadMap(ReadMap(Mode.ToString() + ".txt"));
                    }
                    catch
                    {
                        NoLevels();
                    }
                    break;
            }
        }
        // перерисовка элементов
        public void OnPaint(Graphics g)
        {
            foreach (ClassBlock b in blocks)
            {
                b.Draw(g);
            }
        }
       
        //---------------------------
    }
}
