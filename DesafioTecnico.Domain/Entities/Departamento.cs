using DesafioTecnico.Domain.Abstractions;
using System.Collections.Generic;

namespace DesafioTecnico.Domain.Entities
{
    public class Departamento 
    {
        public Departamento()
        {
            Documento = new HashSet<Documento>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Documento> Documento { get; set; }
    }
}
