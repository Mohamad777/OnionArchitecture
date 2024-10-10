using Microsoft.EntityFrameworkCore;
using OA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Infrastructure.EFCore
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly MasterContext _masterContext;

        public UnitOfWorkEF(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }

        public void BeginTran()
        {
            _masterContext.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _masterContext.SaveChanges();
            _masterContext.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _masterContext.Database.RollbackTransaction();
        }
    }
}
