using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestdebs.dataccess.Entities;

namespace apirestdebs.dataccess
{
    public class StorageHelper : IStorageHelper
    {
        private readonly string connectionString;

        public StorageHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<DebtEntity>> GetItemsAsync()
        {

            return GetDebtsEntityMock();
        }

        public async Task<DebtEntity> GetItemByIdAsync(Guid id)
        {
            DebtEntity item = GetDebtsEntityMock().FirstOrDefault(debt => debt.Id == id);
            return item;
        }

        private IEnumerable<DebtEntity> GetDebtsEntityMock()
        {
            return new List<DebtEntity>()
            {
                new DebtEntity
                {
                    Id = new Guid("2e27870c-8030-43a5-89b9-4774f4bea075"),
                    IdUser = Guid.NewGuid(),
                    Amount = 2000,
                    CreatedAt = DateTimeOffset.Now.AddMonths(-1),
                    ExpiredAt = DateTimeOffset.Now,
                    Dues = 12
                },
                new DebtEntity
                {
                    Id = Guid.NewGuid(),
                    IdUser = Guid.NewGuid(),
                    Amount = 2000,
                    CreatedAt = DateTimeOffset.Now.AddMonths(-1),
                    ExpiredAt = DateTimeOffset.Now,
                    Dues = 12
                }
            };
        }
    }
}
