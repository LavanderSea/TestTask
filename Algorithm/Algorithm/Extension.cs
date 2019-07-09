using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public static class Extension
    {
        public static IEnumerable<int> Quicksort(this List<int> keys, int border)
        {
            var less = new List<int>();
            var more = new List<int>();

            var leftBorder = 0;
            var rightBorder = keys.Count - 1;
            var pivot = keys[keys.Count / 2];
            do
            {
                while (keys[leftBorder] < pivot)
                {
                    if (keys[leftBorder] > border && leftBorder <= rightBorder)
                        less.Add(keys[leftBorder]);
                    leftBorder++;
                    if (leftBorder >= keys.Count)
                        break;
                }

                while (pivot < keys[rightBorder])
                {
                    if (keys[rightBorder] > border && leftBorder <= rightBorder)
                        more.Add(keys[rightBorder]);
                    rightBorder--;
                    if (rightBorder < 0)
                        break;
                }
                
                if (leftBorder <= rightBorder)
                {
                    if (leftBorder < rightBorder && keys[leftBorder] > border)
                        more.Add(keys[leftBorder]);

                    if (keys[rightBorder] > border)
                        less.Add(keys[rightBorder]);

                    leftBorder++;
                    rightBorder--;
                }
                else
                    break;
            } while (leftBorder <= rightBorder);


            if (less.Count > 1 && keys.Count > 2)
                less = less.Quicksort(border).ToList();
            else if (keys.Count == 2)
                less.Reverse();

            if (more.Count > 1 && keys.Count > 2)
                more = more.Quicksort(border).ToList();
            else if (keys.Count == 2)
                more.Reverse();

            return more.Concat(less);
        }
    }
}