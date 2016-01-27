﻿using GraMemory.Model;
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
        public static GameType GameType { get; set; }

        public static int Points { get { return App.GamePage.VM.Points; } set { App.GamePage.VM.Points = value; } }

        static Grid MainGrid { get; set; }

        public static int ActualMem = 0;

        public static Level ActualLevel { get; set; }

        public static Color MemsColor = Colors.Red;

        //public static int LevelNo { get; set; }

        public static void ResetHandler()
        {
            GameType = new GameType();
            Points = 0;
            ActualMem = 0;
            ActualLevel = null;

        }

        public static void CreateGameHandler(Grid mainGrid)
        {
            MainGrid = mainGrid;
            ActualMem = 0;
        }

        public async static Task StartColorGame(int poziom)
        {
            ActualLevel = new Level(poziom);
            MainGrid.Children.Clear();
            for (int i = 0; i < ActualLevel.Possitions.Count; i++)
            {
                var item = ActualLevel.Possitions[i];
                Mem mem = new Mem(item, i);
                MainGrid.Children.Add(mem);
            }
            await ShowMems();
        }

        public async static Task StartMemoryGame(int poziom)
        {

            ActualLevel = new Level(poziom);
            MainGrid.Children.Clear();
            for (int i = 0; i < ActualLevel.Possitions.Count; i++)
            {
                var item = ActualLevel.Possitions[i];
                Mem mem = new Mem(item,i);
                MainGrid.Children.Add(mem);
            }
            await ShowMems();
        }

        public static void StartNumbersGame(int poziom)
        {
            ActualLevel = new Level(poziom);
            MainGrid.Children.Clear();
            for (int i = 0; i < ActualLevel.Possitions.Count; i++)
            {
                var item = ActualLevel.Possitions[i];
                Mem mem = new Mem(item, i);
                MainGrid.Children.Add(mem);
            }
            ShowMemsInstantly();
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

        private static void ShowMemsInstantly()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item.GetType() == typeof(Mem))
                {
                    Mem mem = item as Mem;
                    mem.isVisible = true;
                   
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

        public async static Task CheckOrder(MemPossition memPos)
        {
            if (memPos.memX == ActualLevel.Possitions[ActualMem].memX &&
                memPos.memY == ActualLevel.Possitions[ActualMem].memY)
            {
                Points++;
                ActualMem++;              
            }
            else
            {                
                MessageBox.Show("Koniec Gry");
                          
            }

            if (ActualMem>=ActualLevel.Possitions.Count)
            {
                ActualMem = 0;
                await StartMemoryGame((ActualLevel.No+1));
            }
        }

        public static Color[] ColorsList = new Color[43]{
            Colors.Black,
            Colors.Red,
            Colors.Yellow,
            Colors.Blue,
            Colors.BlueViolet,
            Colors.Chartreuse,
            Colors.Cornsilk,
            Colors.DarkCyan,
            Colors.DarkOrange,
            Colors.Fuchsia,
            Colors.Gold,
            Colors.Indigo,
            Colors.Lavender,
            Colors.Khaki,
            Colors.LemonChiffon,
            Colors.LightCoral,
            Colors.LightGreen,
            Colors.LightSkyBlue,
            Colors.Lime,
            Colors.Magenta,
            Colors.MediumBlue,
            Colors.MintCream,
            Colors.Navy,
            Colors.Olive,
            Colors.Orchid,
            Colors.Peru,
            Colors.Purple,
            Colors.RoyalBlue,
            Colors.SeaGreen,
            Colors.Silver,
            Colors.SlateGray,//30
            Colors.Tan,
            Colors.SteelBlue,
            Colors.Tomato,
            Colors.Violet,
            Colors.YellowGreen,
            Colors.Teal,
            Colors.Sienna,
            Colors.RosyBrown,
            Colors.PowderBlue,
            Colors.Pink,
            Colors.PeachPuff,
            Colors.OldLace
        };
    }

    public enum GameType { memory, number, colors}
}
