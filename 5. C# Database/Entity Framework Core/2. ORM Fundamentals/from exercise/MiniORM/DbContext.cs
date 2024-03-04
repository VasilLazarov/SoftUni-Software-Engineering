using Microsoft.Data.SqlClient;
using System.Collections;
using System.Reflection;

namespace MiniORM
{
    public class DbContext
    {
        private readonly DatabaseConnection _connection;
        private readonly IDictionary<Type, PropertyInfo> _dbSetProperties;

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string), //VARCHAR, NVARCHAR, CHAR, NCHAR
            typeof(int),  // INT
            typeof(uint), // INT
            typeof(long), // BIGINT
            typeof(ulong), // BIGINT
            typeof(decimal), // DECIMAL
            typeof(bool), // BIT
            typeof(DateTime), // DATETIME, DATETIME2
        };

        protected DbContext(string connectionString)
        {
            _connection = new DatabaseConnection(connectionString);
            _dbSetProperties = DiscoverDbSets();
            using (new ConnectionManager(_connection))
            {
                InitializeDbSets();
            }
            MapAllRelations();
        }

        #region SaveChanges
        //Save changes function and hers subfunctions
        public void SaveChanges()
        {
            object[] dbSets = _dbSetProperties
                .Select(dbSetInfo => dbSetInfo.Value.GetValue(this))
                .ToArray();

            foreach(IEnumerable<object> dbSet in dbSets)
            {
                IEnumerable<object> invalidEntities = dbSet
                    .Where(e => !IsObjectValid(e))
                    .ToArray();
                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidEntitiesFound, invalidEntities.Count(), dbSet.GetType().Name));
                }
            }
            using (new ConnectionManager(_connection))
            {
                using (SqlTransaction transaction = _connection.StartTransaction())
                {
                    foreach (IEnumerable<object> dbSet in dbSets)
                    {
                        Type dbSetType = dbSet.GetType().GetGenericArguments().First();
                        MethodInfo persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                            .MakeGenericMethod(dbSetType);

                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie)
                        {
                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        private bool IsObjectValid(object e)
        {
            throw new NotImplementedException();
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            string tableName = GetTableName(typeof(TEntity));
            string[] columns = _connection
                .FetchColumnNames(tableName)
                .ToArray();
            if (dbSet.ChangeTrackerProp.Added.Any())
            {
                _connection.InsertEntities(dbSet.ChangeTrackerProp.Added, tableName, columns);
            }

            TEntity[] modifiedEntities = dbSet.ChangeTrackerProp
                .GetModifiedEntities(dbSet)
                .ToArray();
            if (modifiedEntities.Any())
            {
                _connection.UpdateEntities(modifiedEntities, tableName, columns);
            }

            if (dbSet.ChangeTrackerProp.Removed.Any())
            {
                _connection.DeleteEntities(dbSet.ChangeTrackerProp.Removed, tableName, columns);
            }

        }

        #endregion


        private string GetTableName(Type type)
        {
            throw new NotImplementedException();
        }


        private IDictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            throw new NotImplementedException();
        }

        #region InitializeDbSets
        private void InitializeDbSets()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSetInfo in _dbSetProperties)
            {
                Type dbSetType = dbSetInfo.Key;
                PropertyInfo dbSetProperty = dbSetInfo.Value;

                MethodInfo populateDbSetGeneric = typeof(DbContext)
                    .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);
                populateDbSetGeneric.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {
            IEnumerable<TEntity> entities = LoadTableEntities<TEntity>();
            DbSet<TEntity> dbSetInstance = new(entities);

            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>() 
            where TEntity : class, new()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region MapAllRelations
        private void MapAllRelations()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSetProperty in _dbSetProperties)
            {
                Type dbSetType = dbSetProperty.Key;
                var dbSetInstance = dbSetProperty.Value.GetValue(this);

                MethodInfo mapRelationsGeneric = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);

                mapRelationsGeneric.Invoke(this, new[] { dbSetInstance });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);
            MapNavigationProperties(dbSet);
            PropertyInfo[] collections = entityType
                .GetProperties()
                .Where(pi =>
                        pi.PropertyType.IsGenericType &&
                        pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection))
                .ToArray();

            foreach (PropertyInfo collection in collections)
            {
                Type collectionEntityType = collection.PropertyType
                    .GenericTypeArguments.First();
                MethodInfo mapCollectionMethod = typeof(DbContext)
                    .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(entityType, collectionEntityType);
                mapCollectionMethod.Invoke(this, new object[] { dbSet, collection });
            }
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet) 
            where TEntity : class, new()
        {
            throw new NotImplementedException();
        }

        private void MapCollection<TEntity, TCollecyion>(DbSet<TEntity> dbSet, PropertyInfo collection)
            where TEntity : class, new()
            where TCollecyion : class, new()
        {

        }


        #endregion
    }
}
