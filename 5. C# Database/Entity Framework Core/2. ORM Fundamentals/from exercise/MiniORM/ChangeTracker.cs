using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MiniORM;
internal class ChangeTracker<T>
    where T : class, new()
{
    private readonly IList<T> allEntities;
    private readonly IList<T> added;
    private readonly IList<T> removed;

    private ChangeTracker()
    {
        this.added = new List<T>();
        this.removed = new List<T>();
    }
    public ChangeTracker(IEnumerable<T> allEntities)
        : this()
    {
        this.allEntities = this.CloneEntities(allEntities);
    }
    public IReadOnlyCollection<T> AllEntities 
        => (IReadOnlyCollection<T>)allEntities;
    public IReadOnlyCollection<T> Added
        => (IReadOnlyCollection<T>)added;
    public IReadOnlyCollection<T> Removed
        => (IReadOnlyCollection<T>)removed;

    public void Add(T item) => added.Add(item);
    public void Remove(T item) => removed.Add(item);

    public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
    {
        IList<T> modifiedEntities = new List<T>();
        PropertyInfo[] primaryKeys = typeof(T)
            .GetProperties()
            .Where(pi => pi.HasAttribute<KeyAttribute>())
            .ToArray();

        foreach (T proxyEntity in AllEntities)
        {
            object[] primaryKeyValues = this.GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray(); // ?
            T originalEntity = dbSet.Entities
                .Single(e => this.GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));

            bool isModified = this.IsModified(proxyEntity, originalEntity);
            if (isModified)
            {
                modifiedEntities.Add(proxyEntity);
            }
        }
        return modifiedEntities;
    }

    private IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T proxyEntity)
    {
        return primaryKeys.Select(pk => pk.GetValue(proxyEntity)); // ?
    }

    private bool IsModified(T proxyEntity, T originalEntity)
    {
        PropertyInfo[] monitoredProperties = typeof(T)
            .GetProperties()
            .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType)) //???
            .ToArray();
        PropertyInfo[] modifiedProperties = monitoredProperties
            .Where(pi => !Equals(pi.GetValue(originalEntity), pi.GetValue(proxyEntity)))
            .ToArray();
        //bool isMogified = modifiedProperties.Any();
        //return isMogified;
        return modifiedProperties.Any();
    }

    private IList<T> CloneEntities(IEnumerable<T> originaEntities)
    {
        IList<T> clonedEntities = new List<T>();
        PropertyInfo[] propertiesToClone = typeof(T)
            .GetProperties()
            .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))// ???
            .ToArray();

        foreach (T originalEntity in originaEntities)
        {
            T entityClone = Activator.CreateInstance<T>();
            foreach (PropertyInfo property in propertiesToClone)
            {
                object originalValue = property.GetValue(originalEntity);
                property.SetValue(entityClone, originalValue);
            }
            clonedEntities.Add(entityClone);

        }
        return clonedEntities;
    }
}