using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace randomCharacters
{
    public static class Tools
    {

        public static int sucecssCount,area;
        public static bool isCanPlay;
        public static Point currentClickPos=new Point(0,0);
        public static List<Point> arrWordsPosList=new List<Point>();
        public static Dictionary<int, Point> sortDic = new Dictionary<int, Point>();
        public static bool IsPosInBox(Point pos, Point LeftTop, Point rightBottom)
        {
            if (pos.X >= LeftTop.X && pos.X <= rightBottom.X)
            {
                if(pos.Y >= LeftTop.Y && pos.Y <= rightBottom.Y)
                {
                    return true;
                }
            }
            return false;
        }
       

        public static Point getRightBottomPos(Point cpos)
        {
            return new Point(cpos.X + Tools.area, cpos.Y + Tools.area);

        }
        public static void reset()
        {
            sucecssCount=0; 
            currentClickPos = new Point(0, 0);
            sortDic = new Dictionary<int, Point>();
            Tools.sortDic.Clear();
        }
        public static Point getCurrentRealPos(int cindex)
        {

            return Tools.sortDic.First(x => x.Key == cindex).Value;

        }

        /// <summary>
        /// 通过矩形包括判断获取 
        /// </summary>
        /// <returns></returns>
        public static (string,Point) getCurrentRealPos()
        {
            foreach (var item in sortDic)
            {
               var isinbox= IsPosInBox(currentClickPos, item.Value, getRightBottomPos(item.Value));
                if (isinbox)
                {
                    var res=(item.Key.ToString(),item.Value);
                    return res;
                }

            }
            return ("",new Point(0,0));
    

        }
    }
}
