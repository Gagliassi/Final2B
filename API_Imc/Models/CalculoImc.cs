using System;
using System.ComponentModel.DataAnnotations;

namespace API_Imcs.Models
{
    public class CalculoImc
    {
        public CalculoImc() => CriadoEm = DateTime.Now;

        [Key]
        public int Id { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Imc { get; set; }
        public int UsuarioId { get; set; }
        public string ClassificacaoImc { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}