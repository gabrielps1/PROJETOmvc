using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace CodeFirst.Models

{
    public class Convidado
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public bool comparecimento { get; set; }
    }
}
