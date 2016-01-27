using GraMemory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

namespace GraMemory
{
    public static class GameHandler
    {
        static Grid MainGrid { get; set; }

        static int ActualMem { get; set; }

        public static Level ActualLevel { get; set; }

        public static Color MemsColor = Colors.Red;

        //public static int LevelNo { get; set; }

        public static void CreateGameHandler(Grid mainGrid)
        {
            MainGrid = mainGrid;
            //LevelNo = 1;
            ActualMem = 0;
        }

        public async static Task StartGame()
        {
            ActualLevel = new Level(1);

            foreach (var item in ActualLevel.Possitions)
            {
                Mem mem = new Mem(item);
                MainGrid.Children.Add(mem);
            }
             await ShowMems();
        }

        private async static Task ShowMems()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item.GetType() == typeof(Mem))
                {
                    Mem mem = item as Mem;
                    mem.isVisible = true;                    
                    await Task.Delay(500);
                }
            }
            foreach (var item in MainGrid.Children)
            {
                if (item.GetType() == typeof(Mem))
                {
                    Mem mem = item as Mem;
                    mem.isActive = true;
                }
            }
        }

        public static void CheckOrder(MemPossition memPos)
        {
            if (memPos.memX == ActualLevel.Possitions[ActualMem].memX &&
                memPos.memY == ActualLevel.Possitions[ActualMem].memY)
            {                
                ActualMem++;
                if (ActualMem >= ActualLevel.Possitions.Count - 1)
                {
                    ActualMem = 0;
                    ActualLevel = new Level(ActualLevel.No++);
                }                
            }
            else
            {
                MessageBox.Show("Porażka");
            }
        }
    }
}
