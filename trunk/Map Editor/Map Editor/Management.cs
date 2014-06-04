using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Map_Editor
{
    public class Management
    {
        // load các đối tượng lên các listbox
        public static void InitializeListObjectImages(
            ListBox lbMarioPlayer, ListBox lbEnemyObjects,
            ListBox lbBonusObjects, ListBox lbStaticObjects)
        {
            // mario object
            OImage marioImage = new OImage(EObjectName.SMALL_MARIO, @"\Images\Mario\MarioIcon-16-16.png");
            lbMarioPlayer.Items.Add(marioImage.Bitmap);

            // enemy objects
            lbEnemyObjects.Items.Add((new OImage(EObjectName.ENEMY_GOOMBA_OW, @"\Images\Enemy\MushroomBrown-16-16.png")).Bitmap);
            lbEnemyObjects.Items.Add((new OImage(EObjectName.ENEMY_KOOPA_OW, @"\Images\Enemy\TurtleGreen-16-24.png")).Bitmap);

            // bonus objects
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_BASE_BRICK, @"\Images\Misc\BrickHard-16-16.png")).Bitmap);
            //lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_QUESTION_BRICK, @"\Images\Misc\BrickSoft-16-16.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_IRON_BRICK, @"\Images\Misc\HardBrick-16-16.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_SOFT_BRICK, @"\Images\Misc\BrickSoft-16-16.png")).Bitmap);
            //lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_PIECE, @"\Images\Misc\PipeUp-62-32.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_STOCK_PIPE, @"\Images\Misc\PipeGate-32-16.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_GATE_PIPE, @"\Images\Misc\PipeStock-32-16.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_SMALL_GRASS, @"\Images\Misc\SmallGrass-48-16.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_MEDIUM_GRASS, @"\Images\Misc\MediumGrass-48-16.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_BIG_GRASS, @"\Images\Misc\BigGrass-64-16.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_BIG_MOUNTAIN, @"\Images\Misc\BigMountain-80-35.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_CASTLE, @"\Images\Misc\Castle-80-80.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_GOAL_POLE, @"\Images\Misc\GoalPole-16-136.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_SMALL_CLOUND, @"\Images\Misc\SmallClound-32-24.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_MEDIUM_CLOUND, @"\Images\Misc\MediumClound-48-24.png")).Bitmap);
            lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_BIG_CLOUND, @"\Images\Misc\BigClound-64-24.png")).Bitmap);
            //lbBonusObjects.Items.Add((new OImage(EObjectName.MISC_FLAG, @"\Images\Misc\Flag-16-16.png")).Bitmap);

            //lbStaticObjects.Items.Add((new OImage(EObjectName.MISC_MEDIUM_MOUNTAIN, @"\Images\Misc\MediumMountain-48-24.png")).Bitmap);
            //lbStaticObjects.Items.Add((new OImage(EObjectName.MISC_HARD_BRICK, @"\Images\Misc\HardBrick-16-16.png")).Bitmap);
            lbStaticObjects.Items.Add((new OImage(EObjectName.ITEM_COIN_NORMAL, @"\Images\Item\Coin-16-16.png")).Bitmap);
            lbStaticObjects.Items.Add((new OImage(EObjectName.BRICK_COIN, @"\Images\Item\BrickCoin-16-16.png")).Bitmap);
            lbStaticObjects.Items.Add((new OImage(EObjectName.BRICK_FLOWER, @"\Images\Item\BrickFlower-16-16.png")).Bitmap);
            lbStaticObjects.Items.Add((new OImage(EObjectName.BRICK_SUPPERMUSHROOM, @"\Images\Item\BrickMushroom-16-16.png")).Bitmap);
            lbStaticObjects.Items.Add((new OImage(EObjectName.BRICK_1UPMUSHROOM, @"\Images\Item\BrickMushroomGreen.png")).Bitmap);
            lbStaticObjects.Items.Add((new OImage(EObjectName.BRICK_STAR, @"\Images\Item\BrickStarman-16-16.png")).Bitmap);
            lbStaticObjects.Items.Add((new OImage(EObjectName.BRICK_QUESTION_ITEM, @"\Images\Item\BrickQuestion-16-16.png")).Bitmap);
        }

        // tạo lưới map
        public static void CreateMapGrid(Canvas cvMap)
        {
            int nHorizontalLine, nVerticalLine;

            nHorizontalLine = (int)cvMap.Height / MainWindow.OBJECT_HEIGHT + 1;
            nVerticalLine = (int)cvMap.Width / MainWindow.OBJECT_WIDTH + 1;

            // vẽ hàng chiều ngang
            for (int i = 0; i < nHorizontalLine; i++)
            {
                Line l = new Line();

                l.X1 = 0;
                l.X2 = cvMap.Width;
                l.Y1 = l.Y2 = i * MainWindow.OBJECT_HEIGHT;
                l.Stroke = new SolidColorBrush(Colors.White);
                l.StrokeThickness = 2;

                cvMap.Children.Insert(0, l); //cvMap.Children.Add(l);
            }

            // vẽ hàng dọc
            for (int i = 0; i < nVerticalLine; i++)
            {
                Line l = new Line();

                l.X1 = l.X2 = i * MainWindow.OBJECT_WIDTH;
                l.Y1 = 0;
                l.Y2 = cvMap.Height;
                l.Stroke = new SolidColorBrush(Colors.White);
                l.StrokeThickness = 2;

                cvMap.Children.Insert(0, l); //cvMap.Children.Add(l);
            }
        }

        // xóa lưới map
        public static void RemoveMapGrid(Canvas cvMap)
        {
            if (cvMap.Children != null && cvMap.Children.Count > 0)
            {
                List<UIElement> removeItems = new List<UIElement>(); // lưu các item sẽ xóa
                foreach (var item in cvMap.Children)
                {
                    if (item is Line)
                    {
                        removeItems.Add((Line)item);
                    }
                }

                foreach (UIElement item in removeItems) // xóa các item
                {
                    cvMap.Children.Remove(item);
                }
            }
        }

        // thêm đối tượng vào canvas
        public static void AddObjectToCanvas(
            Canvas cvMap,
            Image image,
            int X, int Y,
            MouseButtonEventHandler mouseDown, MouseButtonEventHandler mouseUp,
            bool canOverlap)
        {
            if (image != null)
            {
                #region Kiểm tra đảm bảo chỉ có duy nhất một nhân vật Mario trong map
                
                if ((EObjectName)(int)image.Tag == EObjectName.SMALL_MARIO)
                {
                    if (HasMarioAdded(cvMap))
                    {
                        MessageBox.Show("Mario Object has already been added into map!");
                        return;
                    }
                }
                //else if ((EObjectName)(int)image.Tag == EObjectName.CREEP_UP_PIPE_1)
                //{
                //    //if (HasCreepUp(cvMap, 0))
                //    //{
                //    //    MessageBox.Show("Creep Up Pipe 1 Object has already been added into map!");
                //    //    return;
                //    //}
                //}
                //else if ((EObjectName)(int)image.Tag == EObjectName.CREEP_UP_PIPE_2)
                //{
                //    //if (HasCreepUp(cvMap, 1))
                //    //{
                //    //    MessageBox.Show("Creep Up Pipe 2 Object has already been added into map!");
                //    //    return;
                //    //}
                //}
                #endregion

                #region Thêm image vào canvas
                Image i = new Image();
                int w, h;

                Factory.ConvertToStandardImage(image, out w, out h);
                i.Width = w;
                i.Height = h;
                i.Source = image.Source;
                i.Tag = image.Tag;
                i.MouseLeftButtonDown += mouseDown;
                i.MouseLeftButtonUp += mouseUp;

                if (!canOverlap) 
                {
                    if (cvMap.Children.Count > 0)
                    {
                        foreach (var item in cvMap.Children)
                        {
                            // nếu đã tồn tại đối tượng tại vị trí (X, Y) thì k add vào canvas, return khỏi hàm
                            if (item is Image && ((Image)item).Opacity != 0.5f) 
                            {
                                if ((int)Canvas.GetLeft((Image)item) == X && (int)Canvas.GetTop((Image)item) == Y)
                                {
                                    MessageBox.Show("This coordinate has a object!");
                                    return;
                                }
                            }
                        }
                    }
                }

                Image rel_X, rel_Y;
                Alignment.Direction dir;
                Point p = Alignment.GetAutoAlignOffset(cvMap, X, Y, w, h, 3, 3, out rel_X, out rel_Y, out dir);

                if (p != (new Point(0, 0)))
                {
                    X += (int)p.X;
                    Y += (int)p.Y;
                }

                Canvas.SetLeft(i, X);
                Canvas.SetTop(i, Y);

                if (Factory.CheckObjectCollisionAbility((EObjectName)i.Tag) == false)
                {
                    //if ((EObjectName)i.Tag == EObjectName.FLAG_POSITION)
                    //{
                    //    cvMap.Children.Add(i);
                    //}
                    //else
                    //{
                        cvMap.Children.Insert(0, i);
                    //}
                }
                else
                {
                    if ((EObjectName)i.Tag == EObjectName.MISC_CASTLE)
                    {
                        cvMap.Children.Insert(0, i);
                    }
                    else
                    {
                        cvMap.Children.Add(i);
                    }
                }
                #endregion
            }
        }

        // Xóa 1 object tại tọa độ tương ứng
        public static void DeleteOneObject(Canvas cvMap, int X, int Y)
        {
            int w, h;
            int left, top;
            if (cvMap.Children.Count > 0)
            {
                foreach (var item in cvMap.Children)
                {
                    if (item is Image && ((Image)item).Opacity != 0.5f)
                    {
                        Factory.ConvertToStandardImage((Image)item, out w, out h);
                        left = (int)Canvas.GetLeft((Image)item);
                        top = (int)Canvas.GetTop((Image)item);

                        if (left <= X && X < (left + w) && top <= Y && Y < (top + h))  // đúng cho cả trường hợp tương đối và tuyệt đối (nếu có dấu = thì chỉ đúng với trường hợp tuyệt đối)
                        {
                            cvMap.Children.Remove((Image)item);
                            return;
                        }
                    }
                }
            }
        }

        // Kiểm tra xem đã thêm mario vào map hay chưa
        public static bool HasMarioAdded(Canvas cvMap)
        {
            if (cvMap.Children != null && cvMap.Children.Count > 0)
            {
                foreach (var item in cvMap.Children)
                {
                    if ((item is Image) && ((Image)item).Opacity != 0.5f && (EObjectName)(int)((Image)item).Tag == EObjectName.SMALL_MARIO)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // kiểm tra xem ống đã thêm creepUp1 và creepUp2 vào chưa
        //public static bool HasCreepUp(Canvas cvMap, int indexPipe)
        //{
        //    if (indexPipe < 0)
        //        indexPipe = 0;
        //    else if (indexPipe > 1)
        //        indexPipe = 1;

        //    EObjectName obj = (EObjectName)((int)EObjectName.CREEP_UP_PIPE_1 + indexPipe);
        //    if (cvMap.Children != null && cvMap.Children.Count > 0)
        //    {
        //        foreach (var item in cvMap.Children)
        //        {
        //            if ((item is Image) && ((Image)item).Opacity != 0.5f 
        //                && (EObjectName)(int)((Image)item).Tag == obj)
        //            {
        //                return true;
        //            }   
        //        }
        //    }

        //    return false;
        //}

        public static bool HasAlreadyOverLap(Canvas cvMap, int X, int Y)
        {
            // kiểm tra tại offset đó có đối tượng hay chưa
            if (cvMap.Children.Count > 0)
            {
                foreach (var item in cvMap.Children)
                {
                    // nếu đã tồn tại đối tượng tại vị trí (X, Y) thì k add vào canvas, return khỏi hàm
                    if (item is Image && ((Image)item).Opacity != 0.5f) // Opacity == 0.5 là hình vẽ tạm thời
                    {
                        if ((int)Canvas.GetLeft((Image)item) == X && (int)Canvas.GetTop((Image)item) == Y)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static void TranslatePosition(Canvas cvMap, int dx, int dy)
        {
            if (cvMap.Children.Count > 0)
            {
                int x, y;
                foreach (UIElement item in cvMap.Children)
                {
                    x = (int)Canvas.GetLeft(item);
                    y = (int)Canvas.GetTop(item);

                    Canvas.SetLeft(item, x + dx);
                    Canvas.SetTop(item, y + dy);
                   // Canvas.SetTop(item, y + dy);
                }
            }
        }

        public static Vector GetBoundOfMap(Canvas cvMap, ref int width, ref int height)
        {
            int min_X, min_Y, max_X, max_Y;
            Vector delta = new Vector(0, 0);

            if (cvMap.Children.Count > 0)
            {
                min_X = min_Y = int.MaxValue;
                max_X = max_Y = int.MinValue;

                int X, Y;
                foreach (var item in cvMap.Children)
                {
                    if (item is Image && ((Image)item).Opacity != 0.5f)
                    {
                        X = (int)Canvas.GetLeft((Image)item);
                        Y = (int)Canvas.GetTop((Image)item);

                        if (min_X > X)
                            min_X = X;

                        if (min_Y > Y)
                            min_Y = Y;

                        if (max_X < X)
                            max_X = X;

                        int w, h;
                        Factory.ConvertToStandardImage((Image)item, out w, out h);
                        int _bot_Y = Y + h;
                        if (max_Y < _bot_Y)
                            max_Y = _bot_Y;
                    }
                }

                delta = new Vector(min_X, height - max_Y);

                width = max_X - min_X;
                height = max_Y - min_Y;

                if (width < 368)
                    width = 368;
                if (height < 224)
                    height = 224;
            }

            return delta;
        }

        public static int GetHorBoundOfMap(Canvas cvMap)
        {
            int max_X = 368;

            if (cvMap.Children.Count > 0)
            {
                max_X = int.MinValue;

                int X;
                foreach (var item in cvMap.Children)
                {
                    if (item is Image && ((Image)item).Opacity != 0.5f)
                    {
                        X = (int)Canvas.GetLeft((Image)item);

                        int w, h;
                        Factory.ConvertToStandardImage((Image)item, out w, out h);

                        if (max_X < X + w)
                        {
                            max_X = X + w;
                        }
                    }
                }

                if (max_X < 368)
                    max_X =  368;
            }

            int i = 1;
            while (368 * Math.Pow(2, i) < max_X)
            {
                i++;
            }
            max_X = 368 * (int)Math.Pow(2, i);

            return max_X;
        }

        public static int GetVerBoundOfMap(Canvas cvMap)
        {
            int max_Y = 224;

            if (cvMap.Children.Count > 0)
            {
                max_Y = int.MinValue;

                int Y;
                foreach (var item in cvMap.Children)
                {
                    if (item is Image && ((Image)item).Opacity != 0.5f)
                    {
                        Y = (int)Canvas.GetTop((Image)item);

                        int w, h;
                        Factory.ConvertToStandardImage((Image)item, out w, out h);

                        if (max_Y < Y + h)
                        {
                            max_Y = Y + w;
                        }
                    }
                }

                if (max_Y < 224)
                    max_Y = 224;
            }

            int i = 1;
            while (224 * Math.Pow(2, i) < max_Y)
            {
                i++;
            }
            max_Y = 224 * (int)Math.Pow(2, i);

            return max_Y;
        }
    }
}
