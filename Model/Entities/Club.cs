﻿using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Club
    {
        public int Id { get; set; }

        // Nombre del Club
        public string Name { get; set; }

        // Listado de Jugadores
        public List<Player> Players { get; set; }
    }
}