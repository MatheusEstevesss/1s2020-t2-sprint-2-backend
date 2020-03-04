using System;
using System.Collections.Generic;

namespace senai.InLock.WebApi.DataBaseFirst.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }// a ? faz com que possa aceitar valores números pois no banco o IdTipoUsuario não é obrigatório

        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
