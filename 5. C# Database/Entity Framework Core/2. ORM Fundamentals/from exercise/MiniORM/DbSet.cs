using System.Collections;

namespace MiniORM
{
    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        
        internal ChangeTracker<TEntity> ChangeTrackerProp { get; set; }
        internal IList<TEntity> Entities { get; set; }
        //public IEnumerable<T> Entities { get; set; } //- same as upper

        internal DbSet(IEnumerable<TEntity> entities)
        {
            Entities = entities.ToList();
            ChangeTrackerProp = new ChangeTracker<TEntity>(entities);
        }

        public int Count => Entities.Count;

        public bool IsReadOnly => Entities.IsReadOnly;



        public void Add(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity), ExceptionMessages.EntityCanNotBeNull);
            }
            Entities.Add(entity);
            ChangeTrackerProp.Add(entity);

        }

        public bool Remove(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity), ExceptionMessages.EntityCanNotBeNull);
            }
            bool isRemoved = Entities.Remove(entity);
            if (isRemoved)
            {
                ChangeTrackerProp.Remove(entity);
            }
            return isRemoved;

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Remove(entity);
            }
        }

        public void Clear()
        {
            while (Entities.Any())
            {
                TEntity entityToRemove = Entities.First();
                Remove(entityToRemove);
            }
        }

        public bool Contains(TEntity item)
            => Entities.Contains(item);

        public void CopyTo(TEntity[] array, int arrayIndex)
            => Entities.CopyTo(array, arrayIndex);

        //This will allow our DbSet<TEntity> to work with Foreach loop
        public IEnumerator<TEntity> GetEnumerator()
            => Entities.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
        
        

    }
}
