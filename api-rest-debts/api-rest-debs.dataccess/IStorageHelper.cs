using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using apirestdebs.dataccess.Entities;

namespace apirestdebs.dataccess
{
    /// <summary>
    /// This is an interface for Storage communication
    /// </summary>
    public interface IStorageHelper
    {
        /// <summary>
        /// Retrieves a Debt Entity from the Storage by a given identifier
        /// </summary>
        /// <param name="id">the Debt's identifier</param>
        /// <returns>a Debt</returns>
        Task<DebtEntity> GetItemByIdAsync(Guid id);

        /// <summary>
        /// Retrieves Debts entities from the storage
        /// </summary>
        /// <returns>a list of entities</returns>
        Task<IEnumerable<DebtEntity>> GetItemsAsync();
    }
}