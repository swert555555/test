using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Потоки
{
    public class Top_Polsovatelei
    {
        public static string? Name = "Топ пользователей";
        public static List<Polsovatel>? Vse_polsovateli;
    }

    public class Polsovatel
    {
        public string? Name;
        public int Vsego_Simvol = 0;
        public double Simvol_Sekund;

        public Polsovatel(string Name, double Simvol_Sekund, int Vsego_Simvol)
        {
            this.Name = Name;
            this.Vsego_Simvol = Vsego_Simvol;
            this.Simvol_Sekund = Simvol_Sekund;
        }
    }



}
