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
using System.Xml.Serialization;

namespace Map_Editor
{
    #region Cấu trúc lưu map
    // thông tin cần lưu mỗi QNode
    public struct Node
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("X")]
        public int X { get; set; }

        [XmlAttribute("Y")]
        public int Y { get; set; }

        [XmlAttribute("Width")]
        public int Width { get; set; }

        [XmlAttribute("Height")]
        public int Height { get; set; }

        public GameObject[] GameObjects;
    }

    // thông tin cần lưu mỗi đối tượng
    public struct GameObject
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Type")]
        public int Type { get; set; }

        [XmlAttribute("X")]
        public int X { get; set; }

        [XmlAttribute("Y")]
        public int Y { get; set; }
    }

    // dữ liệu các đối tượng sử dụng để lưu
    public struct SaveData
    {
        public int Width;
        public int Height;
        public Node[] Nodes;
    }
    #endregion

    public class LoadSaveData
    {
        // tạo dữ liệu cấu trúc lưu
        public static SaveData CreateSaveData(List<QGameObject> qGameObjects, Canvas cvMap, int width, int height, QMode mode)
        {
            SaveData data;

            //Vector tmpVector = Management.GetBoundOfMap(cvMap, ref width, ref height);
            //Management.TranslatePosition(cvMap, -(int)tmpVector.X, (int)tmpVector.Y);
            //width = Management.GetHorBoundOfMap(cvMap);

            int dimension;
            if (width > height)
                dimension = width;
            else
                dimension = height;

            if (dimension < 368)
                dimension = 368;

            QNode quadTree = new QNode(0, NodePosition.TOP_LEFT, new Rectangle(0, 0, dimension * 2, dimension * 2));

            int idCount = 0;
            bool isNonStatic;
            //List<QGameObject> qGameObjects = new List<QGameObject>();

            int total = 0;
            foreach (var item in cvMap.Children)
            {
                if (item is Image && ((Image)item).Opacity != 0.5f) // Không phải hình ảo
                {
                    total++;
                }
            }

            if (QNode.Mode == QMode.DRAW)
            {
                foreach (var item in cvMap.Children)
                {
                    if (item is Image && ((Image)item).Opacity != 0.5f) // Không phải hình ảo
                    {
                        Image i = item as Image;

                        //if (Factory.CheckObjectType((EObjectName)i.Tag) == ObjectType.NON_STATIC)
                        //{
                        //    isNonStatic = true;
                        //}
                        //else
                        //{
                        //    isNonStatic = false;
                        //}

                        //if (Factory.CheckObjectCollisionAbility((EObjectName)i.Tag) == false)
                        //{
                        // Add đối tượng vào Quadtree, đối với cây UPDATE chỉ add các đối tượng có thể va chạm
                        if ((EObjectName)i.Tag == EObjectName.BRICK_COIN || (EObjectName)i.Tag == EObjectName.BRICK_FLOWER || (EObjectName)i.Tag == EObjectName.BRICK_SUPPERMUSHROOM
                                || (EObjectName)i.Tag == EObjectName.BRICK_1UPMUSHROOM || (EObjectName)i.Tag == EObjectName.BRICK_STAR || (EObjectName)i.Tag == EObjectName.BRICK_QUESTION_ITEM)
                        {
                            QGameObject o1 = new QGameObject(
                                                      idCount++,
                                                      (int)EObjectName.MISC_QUESTION_BRICK,
                                                      new Rectangle((int)Canvas.GetLeft(i), (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                                                      false);
                            qGameObjects.Add(o1);
                            QGameObject o2 = null;
                            switch ((EObjectName)i.Tag)
                            {
                                case EObjectName.BRICK_COIN:
                                    o2 = new QGameObject(
                                                  idCount++,
                                                  (int)EObjectName.ITEM_COIN_ACTIVATED,
                                                  new Rectangle((int)Canvas.GetLeft(i), (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                                                  true);
                                    qGameObjects.Add(o2);
                                 break;
                                case EObjectName.BRICK_FLOWER:
                                    o2 = new QGameObject(
                                              idCount++,
                                              (int)EObjectName.ITEM_FIRE_FLOWER,
                                              new Rectangle((int)Canvas.GetLeft(i), (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                                              true);
                                 qGameObjects.Add(o2);
                                 break;
                                case EObjectName.BRICK_SUPPERMUSHROOM:
                                 o2 = new QGameObject(
                                           idCount++,
                                           (int)EObjectName.ITEM_SUPER_MUSHROOM,
                                           new Rectangle((int)Canvas.GetLeft(i), (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                                           true);
                                 qGameObjects.Add(o2);
                                 break;
                                case EObjectName.BRICK_1UPMUSHROOM:
                                 o2 = new QGameObject(
                                           idCount++,
                                           (int)EObjectName.ITEM_1UP_MUSHROOM,
                                           new Rectangle((int)Canvas.GetLeft(i), (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                                           true);
                                 qGameObjects.Add(o2);
                                 break;
                                case EObjectName.BRICK_STAR:
                                 o2 = new QGameObject(
                                           idCount++,
                                           (int)EObjectName.ITEM_STARMAN,
                                           new Rectangle((int)Canvas.GetLeft(i), (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                                           true);
                                 qGameObjects.Add(o2);
                                 break; 
                                case EObjectName.BRICK_QUESTION_ITEM:
                                 o2 = new QGameObject(
                                           idCount++,
                                           (int)EObjectName.ITEM_GROW_UP,
                                           new Rectangle((int)Canvas.GetLeft(i), (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                                           true);
                                 qGameObjects.Add(o2);
                                 break; 
                                default:
                                 break;
                            }
                        }
                        else if((EObjectName)i.Tag == EObjectName.ENEMY_GOOMBA_OW || (EObjectName)i.Tag == EObjectName.ENEMY_KOOPA_OW || (EObjectName)i.Tag == EObjectName.ENEMY_BOSS)
                        {
                            QGameObject o1 = new QGameObject(
                                                     idCount++,
                                                     (int)i.Tag,
                                                     new Rectangle((int)Canvas.GetLeft(i), (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                                                     true);
                            qGameObjects.Add(o1);
                        }
                        else
                        {
                            QGameObject o = new QGameObject(
                                idCount++,
                                (int)i.Tag,
                                //new Rectangle((int)Canvas.GetLeft(i), height - (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                                new Rectangle((int)Canvas.GetLeft(i), (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                                false);
                            qGameObjects.Add(o);
                        }
                    }
                        //else
                        //{
                        //    QGameObject o = new QGameObject(
                        //        --total,
                        //        (int)i.Tag,
                        //        //new Rectangle((int)Canvas.GetLeft(i), height - (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                        //        new Rectangle((int)Canvas.GetLeft(i), (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                        //        isNonStatic);
                        //    qGameObjects.Add(o);
                        //}
                        /*
                    else
                    {
                        if (Factory.CheckObjectCollisionAbility((EObjectName)i.Tag))
                        {
                            QGameObject o = new QGameObject(
                                idCount++,
                                (int)i.Tag,
                                new Rectangle((int)Canvas.GetLeft(i), height - (int)Canvas.GetTop(i), (int)i.Width, (int)i.Height),
                                isNonStatic);
                            qGameObjects.Add(o);
                        }
                    }*/
                    //}
                }
            }
            else
            {
                for (int i = 0; i < qGameObjects.Count;)
                {
                    if (Factory.CheckObjectCollisionAbility((EObjectName)qGameObjects[i].Type) == false)
                    {
                        qGameObjects.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            
            for (int i = 0; i < qGameObjects.Count-1; i++)
            {
                for (int j = i + 1; j < qGameObjects.Count; j++)
                {
                    if (qGameObjects[i].ID > qGameObjects[j].ID)
                    {
                        QGameObject tmp = qGameObjects[i];
                        qGameObjects[i] = qGameObjects[j];
                        qGameObjects[j] = tmp;
                    }
                }
            }
            
            foreach (var item in qGameObjects)
            {
                quadTree.Insert(item);
            }

            List<QNode> listQNodes = new List<QNode>();
            List<Node> nodes = new List<Node>();
            quadTree.GetNode(ref listQNodes);
            nodes = Factory.TransformFromQNodeToNode(listQNodes);

            data.Width = width;
            data.Height = height;
            data.Nodes = nodes.ToArray<Node>();

            return data;
        }
    }
}
