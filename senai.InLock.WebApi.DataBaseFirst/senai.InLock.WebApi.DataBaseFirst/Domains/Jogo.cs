﻿using System;
using System.Collections.Generic;

namespace senai.InLock.WebApi.DataBaseFirst.Domains
{
    public partial class Jogo
    {
        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataLancamento { get; set; }
        public double? Valor { get; set; }
        public int? IdEstudio { get; set; }

        public Estudio IdEstudioNavigation { get; set; }
    }
}
