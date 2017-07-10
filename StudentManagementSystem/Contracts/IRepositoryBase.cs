using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models.Application;

namespace StudentManagementSystem.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets the Entity with the id
        /// </summary>
        /// <param name="id">ID of the entity to query</param>
        /// <returns>Returns entity with the id provided</returns>
        Task<TEntity> GetById(int? id);

        /// <summary>
        /// Gets all the entity in the database
        /// </summary>
        /// <returns>IEnumerable of the entity</returns>
        Task<List<TEntity>> GetAll();

        /// <summary>
        /// Insert a new entity into the database
        /// </summary>
        /// <param name="entity">entity data to save</param>
        /// <returns>True if saved successfully, false if not</returns>
        Task<int> Insert(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">new entity to update with</param>
        /// <param name="id">id of the entity to update</param>
        /// <returns>True if Updated successfully, false if not</returns>
        Task<int> Update(TEntity entity, int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>        
        Task<int> Delete(TEntity entity);
    }
}
