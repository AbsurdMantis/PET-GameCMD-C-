using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePET.NET
{
    class Class1
    {
        string[,] GameMap = new string[20, 20];
        string [,] MapGenerator()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    GameMap[j, i] = "0";
                }
            }

            GameMap[0, 0] = "H";
            GameMap[19, 19] = "D";
            return GameMap;
        }
    }
}
