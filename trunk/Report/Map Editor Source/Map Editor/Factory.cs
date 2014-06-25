using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Map_Editor
{
    public enum EObjectName
    {
        NONE,
        SMALL_MARIO,
        SUPER_MARIO,

        ENEMY_GOOMBA_OW,
        ENEMY_KOOPA_OW,

        MISC_BASE_BRICK,
        MISC_QUESTION_BRICK,
        MISC_IRON_BRICK,
        MISC_SOFT_BRICK,
        MISC_PIECE,
        MISC_STOCK_PIPE,
        MISC_GATE_PIPE,
        MISC_UP_PIPE,
        MISC_SMALL_GRASS,
        MISC_MEDIUM_GRASS,
        MISC_BIG_GRASS,
        MISC_BIG_MOUNTAIN,
        MISC_MEDIUM_MOUNTAIN,
        MISC_HARD_BRICK,
        MISC_CASTLE,

        ITEM_COIN_ACTIVATED, // coin nằmg trong gạch
        ITEM_COIN_NORMAL, // coin nằm ở ngoài
        ITEM_FIRE_FLOWER,
        ITEM_SUPER_MUSHROOM,
        ITEM_1UP_MUSHROOM,
        ITEM_STARMAN,

        BRICK_COIN,
        BRICK_FLOWER,
        BRICK_1UPMUSHROOM,
        BRICK_SUPPERMUSHROOM,
        BRICK_STAR,
        BRICK_QUESTION_ITEM,

        FIRE_MARIO,
        MISC_STAR_FLAG_CASTLE,
        BULLET,
        MISC_FLAG,
        MISC_GOAL_POLE,
        ITEM_GROW_UP,

        MISC_SMALL_CLOUND,
        MISC_MEDIUM_CLOUND,
        MISC_BIG_CLOUND,
        ENEMY_BOSS_BULLET,
        ENEMY_BOSS,
    }

    public enum ObjectType
    {
        STATIC,
        NON_STATIC
    }

    public class Factory
    {
        // chuyển tới kích thước chuẩn trong game
        public static void ConvertToStandardImage(System.Windows.Controls.Image image, out int width, out int height)
        {
            int id = (int)image.Tag;

            switch ((EObjectName)id)
            {
                case EObjectName.SMALL_MARIO:
                    width = MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_GOAL_POLE:
                    width = MainWindow.OBJECT_WIDTH;
                    height = 136;
                    break;
                case EObjectName.MISC_FLAG:
                    width = MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_SMALL_CLOUND:
                    width = MainWindow.OBJECT_WIDTH * 2;
                    height = 24;
                    break;
                case EObjectName.MISC_MEDIUM_CLOUND:
                    width = MainWindow.OBJECT_WIDTH * 3;
                    height = 24;
                    break;
                case EObjectName.MISC_BIG_CLOUND:
                    width = MainWindow.OBJECT_WIDTH * 4;
                    height = 24;
                    break;
                case EObjectName.SUPER_MARIO:
                    width = MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.ENEMY_GOOMBA_OW:
                    width = MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.ENEMY_BOSS:
                    width = MainWindow.OBJECT_WIDTH * 2;
                    height = MainWindow.OBJECT_HEIGHT * 2;
                    break;
                case EObjectName.ENEMY_KOOPA_OW:
                    width = MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT + MainWindow.OBJECT_HEIGHT / 2;
                    break;
                case EObjectName.MISC_BASE_BRICK:
                    width = MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_QUESTION_BRICK:
                    width = MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_IRON_BRICK:
                    width = MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_SOFT_BRICK:
                    width = MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_CASTLE:
                    width = MainWindow.OBJECT_WIDTH * 5;
                    height = MainWindow.OBJECT_HEIGHT * 5;
                    break;
                case EObjectName.MISC_PIECE:
                    width = MainWindow.OBJECT_WIDTH * 4;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_STOCK_PIPE:
                    width = MainWindow.OBJECT_WIDTH * 2;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_GATE_PIPE:
                    width = MainWindow.OBJECT_WIDTH * 2;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_UP_PIPE:
                    width = MainWindow.OBJECT_WIDTH * 4;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_SMALL_GRASS:
                    width = MainWindow.OBJECT_WIDTH * 3;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_MEDIUM_GRASS:
                    width = MainWindow.OBJECT_WIDTH * 3;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_BIG_GRASS:
                    width = MainWindow.OBJECT_WIDTH * 4;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_BIG_MOUNTAIN:
                    width = MainWindow.OBJECT_WIDTH * 5;
                    height = MainWindow.OBJECT_HEIGHT * 2;
                    break;
                case EObjectName.MISC_MEDIUM_MOUNTAIN:
                    width = MainWindow.OBJECT_WIDTH * 3;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.MISC_HARD_BRICK:
                    width = 3 * MainWindow.OBJECT_WIDTH;
                    height = 2 * MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.ITEM_COIN_ACTIVATED:
                    width =  MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.ITEM_COIN_NORMAL:
                    width = 4 * MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.ITEM_FIRE_FLOWER:
                    width = 4 * MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.ITEM_SUPER_MUSHROOM:
                    width = 4 * MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.ITEM_1UP_MUSHROOM:
                    width = MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
                case EObjectName.ITEM_STARMAN:
                    width = 2 * MainWindow.OBJECT_WIDTH;
                    height = 3 * MainWindow.OBJECT_HEIGHT;
                    break;
                default:
                    width = MainWindow.OBJECT_WIDTH;
                    height = MainWindow.OBJECT_HEIGHT;
                    break;
            }
        }

        public static BitmapImage GetBitmapImage(EObjectName type)
        {
            BitmapImage bitmap = null;
            switch (type)
            {
                case EObjectName.SMALL_MARIO:
                    bitmap = new BitmapImage(new Uri(@"\Images\Mario\MarioIcon-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.SUPER_MARIO:
                    bitmap = new BitmapImage(new Uri(@"\Images\Mario\MarioIcon-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.ENEMY_GOOMBA_OW:
                    bitmap = new BitmapImage(new Uri(@"\Images\Enemy\MushroomBrown-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.ENEMY_KOOPA_OW:
                    bitmap = new BitmapImage(new Uri(@"\Images\Enemy\TurtleGreen-16-24.png", UriKind.Relative));
                    break;
                case EObjectName.ENEMY_BOSS:
                    bitmap = new BitmapImage(new Uri(@"\Images\Enemy\BossGreen-32-32.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_BASE_BRICK:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\BrickHard-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_QUESTION_BRICK:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\BrickSoft-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_IRON_BRICK:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\HardBrick-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_SOFT_BRICK:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\BrickSoft-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_PIECE:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\PipeUp-62-32.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_STOCK_PIPE:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\PipeStock-32-16.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_SMALL_CLOUND:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\SmallClound-32-24.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_MEDIUM_CLOUND:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\MediumClound-48-24.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_BIG_CLOUND:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\BigClound-64-24.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_GATE_PIPE:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\PipeGate-32-16.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_SMALL_GRASS:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\SmallGrass-48-16.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_MEDIUM_GRASS:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\MediumGrass-48-16.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_BIG_GRASS:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\BigGrass-64-16.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_BIG_MOUNTAIN:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\BigMountain-80-35.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_MEDIUM_MOUNTAIN:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\MediumMountain-48-24.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_HARD_BRICK:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\HardBrick-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_CASTLE:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\Castle-80-80.png", UriKind.Relative));
                    break;
                case EObjectName.ITEM_COIN_ACTIVATED:
                    bitmap = new BitmapImage(new Uri(@"\Images\Item\BrickCoin-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.ITEM_COIN_NORMAL:
                    bitmap = new BitmapImage(new Uri(@"\Images\Item\Coin-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.ITEM_FIRE_FLOWER:
                    bitmap = new BitmapImage(new Uri(@"\Images\Item\BrickFlower-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.ITEM_SUPER_MUSHROOM:
                    bitmap = new BitmapImage(new Uri(@"\Images\Item\BrickMushroom-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.ITEM_1UP_MUSHROOM: // đây làm một item để gắn
                    bitmap = new BitmapImage(new Uri(@"\Images\Item\BrickMushroomGreen.png", UriKind.Relative));
                    break;
                case EObjectName.BRICK_COIN:
                    bitmap = new BitmapImage(new Uri(@"\Images\Item\BrickCoin-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.BRICK_FLOWER:
                    bitmap = new BitmapImage(new Uri(@"\Images\Item\BrickFlower-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.BRICK_SUPPERMUSHROOM:
                    bitmap = new BitmapImage(new Uri(@"\Images\Item\BrickMushroom-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.BRICK_1UPMUSHROOM:
                    bitmap = new BitmapImage(new Uri(@"\Images\Item\BrickMushroomGreen.png", UriKind.Relative));
                    break;
                case EObjectName.BRICK_STAR:
                    bitmap = new BitmapImage(new Uri(@"\Images\Item\BrickStarman-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.BRICK_QUESTION_ITEM:
                    bitmap = new BitmapImage(new Uri(@"\Images\Item\BrickQuestion-16-16.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_GOAL_POLE:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\GoalPole-16-136.png", UriKind.Relative));
                    break;
                case EObjectName.MISC_FLAG:
                    bitmap = new BitmapImage(new Uri(@"\Images\Misc\Flag-16-16.png", UriKind.Relative));
                    break;
                default:
                    break;
            }

            return bitmap;
        }

        // Chuyển từ QNode -> Node để lưu
        public static List<Node> TransformFromQNodeToNode(List<QNode> listQNodes)
        {
            List<Node> nodes = new List<Node>();

            if (listQNodes.Count == null || listQNodes.Count == 0)
                return null;

            foreach (var item in listQNodes)
            {
                Node tmpNode = new Node();

                // lấy thông tin QNode
                tmpNode.ID = item.ID;
                tmpNode.X = item.Bound.X;
                tmpNode.Y = item.Bound.Y;
                tmpNode.Width = item.Bound.Width;
                tmpNode.Height = item.Bound.Height;

                // lấy thông tin các đối tượng trong QNode
                tmpNode.GameObjects = new GameObject[item.ListObjects.Count];
                if (item.ListObjects.Count > 0)
                {
                    for (int i = 0; i < item.ListObjects.Count; i++)
                    {
                        GameObject go = new GameObject();

                        go.ID = item.ListObjects[i].ID;
                        go.Type = item.ListObjects[i].Type;
                        go.X = item.ListObjects[i].Bound.X; // chuyển tọa độ vào tâm
                        go.Y = item.ListObjects[i].Bound.Y; // chuyển tọa độ vào tâm

                        tmpNode.GameObjects[i] = go;
                    }
                }

                nodes.Add(tmpNode);
            }

            return nodes;
        }

        // kiểm tra 1 đối tượng là động hay tĩnh <có thể di chuyển được>
        public static ObjectType CheckObjectType(EObjectName obj)
        {
            switch (obj)
            {
                //case EObjectName.SMALL_MARIO:
                //case EObjectName.SUPER_MARIO:
                //case EObjectName.ENEMY_GOOMBA_OW:
                //case EObjectName.ENEMY_KOOPA_OW:
                //case EObjectName.ITEM_SUPER_MUSHROOM:
                //case EObjectName.ITEM_1UP_MUSHROOM:
                //    return ObjectType.NON_STATIC;
                default:
                    return ObjectType.STATIC;
            }
        }

        // kiểm tra xem đối tượng có thể xét va chạm đc k
        public static bool CheckObjectCollisionAbility(EObjectName obj)
        {
            switch (obj)
            {
                default:
                    return true;
            }
        }
    }
}
