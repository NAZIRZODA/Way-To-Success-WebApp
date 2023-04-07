﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTSuccess.Domain.Models
{
    public class Topic : EntityBase
    {
        public string Name { get; set; }
        public string Teory { get; set; }
        public virtual Chapter? Chapter { get; set; }
        public ulong ChapterId { get; set; }
    }
}
