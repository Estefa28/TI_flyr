﻿using System.ComponentModel.DataAnnotations;

namespace Newshore.EF.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
