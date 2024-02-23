using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    //Tile is the cell that has possible mine in it and can be revealed. It has same features than button besides a few added custom ones
    internal class Tile : Button
    {
        public bool isMine { get; set; }
        public bool isMarked { get; set; }
        public int minesAroud { get; set; }
        public bool isEmpty { get; set; }

        public Tile() 
        {
            this.TabStop = false;
            this.Text = string.Empty;
            this.isMine = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderColor = SystemColors.ControlDark;
            this.BackColor = SystemColors.ControlLight;
            this.Size = new Size(35, 35);
        }
        

    }
}
