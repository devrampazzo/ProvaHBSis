using LivrariaHBSIS.Domain.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaHBSIS.Domain.Services
{
    public class BaseDomainService
    {
        private IUnitOfWork _unitOfWork;

        public BaseDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual void PersistTransaction() =>
            _unitOfWork.Persist();
    }
}
