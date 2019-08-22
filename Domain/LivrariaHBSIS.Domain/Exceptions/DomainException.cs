using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaHBSIS.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException() : base() { }
        public DomainException(Exception inner) : base("Exceção na camada de domínio. Consultar a InnerException para mais detalhes.", inner) { }
    }
}
