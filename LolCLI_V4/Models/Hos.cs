using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolCLI_V4.Models
{
    public class Hos
    {

        public Hos() { }

        public Hos(string sor)
        {
            string[] temp = sor.Split(';');
            Name = temp[0];
            Title = temp[1];
            Category = temp[2];
            Tag = temp[3];
            HP = double.Parse(temp[4]);
            Attackdamage = double.Parse(temp[5]);
            Attackdamageperlevel = double.Parse(temp[6]);
        }

        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Category { get; private set; }
        public string Tag { get; private set; }
        public double HP { get; private set; }
        public double Attackdamage { get; private set; }
        public double Attackdamageperlevel { get; private set; }

        public double ADLevel(int szint)
        {
            if (szint >= 1 && szint <= 18)
            {
                return Attackdamage + (szint - 1) * Attackdamageperlevel;
            }
            return -1;
            
        }

        
    }
}
