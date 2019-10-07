namespace GAPEvaluation.Common.Repository
{
    using System;
    using GAPEvaluation.Domain.Models;

    public class BaseRepository: IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Database Context
        /// </summary>
        protected readonly DataContext Context = new DataContext();

        /// <summary>
        /// Save Entity Changes
        /// </summary>
        public void Save()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Create new Entity
        /// </summary>
        /// <param name="entity"></param>
        public void Create(object entity)
        {
            var set = Context.Set(entity.GetType());
            set.Add(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete an Entity
        /// </summary>
        /// <param name="entiyy"></param>
        public void Delete(object entiyy)
        {
            var set = Context.Set(entiyy.GetType());
            set.Remove(entiyy);
            Context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                Context.Dispose();

            _disposed = true;
        }
    }
}
