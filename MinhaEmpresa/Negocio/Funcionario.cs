using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEmpresa.Negocio
{
    public class Funcionario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataContratacao { get; set; }
        public string Departamento { get; set; }
    }
}
