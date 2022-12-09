using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Imcs.Models
{
    public class Usuario
    {
        //Data Annotations
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Nascimento { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}