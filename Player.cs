using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_do_Velho
{
    public class Player
    {
        public short Num { get; set; }
        public string Marca { get; set; }
        public bool Ult { get; set; } = true;
        public Player(short num, string marca)
        {
            this.Num = num;
            this.Marca = marca;
        }
    }
}