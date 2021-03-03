using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;
using System.Drawing;

namespace MedianTransform
{
    [Version(1, 1)]
    public class MedianTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Медианный фильтр";
            }
        }

        public string Author
        {
            get
            {
                return "Samoed";
            }
        }

        public Bitmap Transform(Bitmap bitmap)
        {
            byte[,] imageR = new byte[bitmap.Width, bitmap.Height];
            byte[,] imageG = new byte[bitmap.Width, bitmap.Height];
            byte[,] imageB = new byte[bitmap.Width, bitmap.Height];

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    var colour = bitmap.GetPixel(i, j);
                    imageR[i, j] = colour.R;
                    imageG[i, j] = colour.G;
                    imageB[i, j] = colour.B;
                }
            }
            Bitmap result = new Bitmap(bitmap.Width+1, bitmap.Height+1);
            for (int i = 0; i <= bitmap.Width - 3; i++)
                for (int j = 0; j <= bitmap.Height - 3; j++)
                {
                    List<List<byte>> termsList = new List<List<byte>>();
                    for (int c = 0; c < 3; c++)
                        termsList.Add(new List<byte>());
                    for (int x = i; x <= i + 2; x++)
                        for (int y = j; y <= j + 2; y++)
                        {
                            termsList[0].Add(imageR[x, y]);
                            termsList[1].Add(imageG[x, y]);
                            termsList[2].Add(imageB[x, y]);
                        }
                    byte[] colorsArr = new byte[3];
                    for(int c = 0; c < 3; c++) 
                    {
                        byte[] terms = termsList[c].ToArray();
                        Array.Sort(terms);
                        byte color = terms[5];
                        colorsArr[c] = color;
                    }
                    result.SetPixel(i + 1, j + 1, Color.FromArgb(colorsArr[0], colorsArr[1], colorsArr[2]));
                }
            return result;
        }
    }

}
