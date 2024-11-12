﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonApp.Models
{
    public class NurseRequest
    {
        public int Id { get; set; }
        public string PokemonName { get; set; }
        public string Description { get; set; }
        public string AssignedNurse { get; set; }
        public bool IsAttended { get; set; }
    }
}