﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Core.Domain.Entities
{
    public class ProjetoEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}