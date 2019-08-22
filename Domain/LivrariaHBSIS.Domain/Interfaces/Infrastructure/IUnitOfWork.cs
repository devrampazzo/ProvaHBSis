using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaHBSIS.Domain.Interfaces.Infrastructure
{
    public interface IUnitOfWork
    {
        void Persist();
    }
}
