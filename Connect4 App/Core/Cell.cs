﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4_App.Core
{
    public class Cell
    {
        public String colour { get; set; }

        public Cell(String colour)
        {
            this.colour = colour;
            
        }

    }
}