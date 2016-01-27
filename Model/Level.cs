using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraMemory.Model
{
    public class Level
    {       
        // numer poziomu
        public int No { get; set; }

        // pozycje memow w odpowiedniej kolejnosci
        public List<MemPossition> Possitions { get; set; }

        // initializu poziom
        public Level(int numer)
        {
            App.GamePage.VM.Level = numer;
            No = numer;
            Possitions = CreatePossitions();
        }

        // stworz pozycje dla poziomu
        private List<MemPossition> CreatePossitions()
        {
            List<MemPossition> pos = new List<MemPossition>() { };
            Random rnd = new Random();

            for (int i = 0; i < No+3; i++)
            {
                AddSinglePossition(ref rnd, ref pos);                              
            }
            return pos;
        }

        // referencyjnie dodaj pojedynczą pozycję
        private void AddSinglePossition(ref Random rnd, ref List<MemPossition> list)
        {
            int x = rnd.Next(0, 8);
            int y = rnd.Next(0, 8);
            MemPossition possition = new MemPossition(x, y);
            if (!DoPossitionsContainPossition(possition, ref list))
            {
                list.Add(possition);
            }
            else
            {
                AddSinglePossition(ref rnd, ref list);
            }
        }

        // sprawdz czy w wylosowanych pozycjach jest już podana pozycja
        private bool DoPossitionsContainPossition(MemPossition pos, ref List<MemPossition> list)
        {
            foreach (var item in list)
            {
                if (item.memX == pos.memX && item.memY == pos.memY)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
