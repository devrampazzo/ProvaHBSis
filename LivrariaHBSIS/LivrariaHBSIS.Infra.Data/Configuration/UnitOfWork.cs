using LivrariaHBSIS.Domain.Interfaces.Infrastructure;
using LivrariaHBSIS.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaHBSIS.Infra.Data.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private ContextoAplicacao _contexto;

        public UnitOfWork(ContextoAplicacao contexto)
        {
            _contexto = contexto;
        }

        public void Persist()
        {
            _contexto.SaveChanges();
        }
    }
}
