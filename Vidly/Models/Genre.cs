﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        [Key]
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}