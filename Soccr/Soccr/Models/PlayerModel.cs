using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccr.Models
{
    internal class PlayerModel
    {
        public PlayerModel(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public override string ToString()
        {
            return $"{this.Number} {this.Name}";
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public bool IsHomePlayer { get; set; } = true;
    }
}
