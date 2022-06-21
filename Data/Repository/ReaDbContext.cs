using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy.Internal;
using Data.Entities.Abstract;
using Data.Entities.Concrete;
using Data.Mapping.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ReaDbContext : DbContext
    {
        public ReaDbContext(DbContextOptions<ReaDbContext> options) : base(options)
        {
            SetDb();
        }
        
        
        private  const string EntitiesNameSpace = "Data.Entities.Concrete";
        private const string EntityMapsNameSpace = "Data.Mapping.Concrete";
        private IEnumerable<Type> _entities;
        private void SetDb()
        {
            // BaseEntity TYPE ında olan ayrıca entities.concrete içerisinde IENtity interfacesine sahip olan entityleri getir. Aslında burada 
            // yaptığımın dışında daha kısa olabilecek versiyonu aşağıdaki gibi olabilir aynı sonucu verir.
            
            /* _entities = from t in (Assembly.GetAssembly(typeof(IEntity))?.GetTypes())
            where t.IsClass && t.Namespace == EntitiesNameSpace
            select t;
             */
            
            // Gibi yapabilirdik.
            
            _entities = from t in (Assembly.GetAssembly(typeof(IEntity))?.GetTypes())
                where t.IsClass && t.Namespace == EntitiesNameSpace
                                && t.GetAllInterfaces().Select(x => x.ToString()).Contains(typeof(IEntity).ToString())
                select t;
            Console.WriteLine("SetDb Çalıştı");
            foreach (var Entity in _entities)
            {
                Console.WriteLine(Entity.Name);
                MethodInfo method = this.GetType().GetMethod("Set",new Type[]{});
                MethodInfo generic = method.MakeGenericMethod(Entity);
                generic.Invoke(this, null);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Burada da BaseEntityMapping den türeyen tüm mapping sınıflarını getirip configuration yapılıyor.
            base.OnModelCreating(modelBuilder);
            var map = Assembly.GetAssembly(typeof(BaseEntityMapping<>))?.GetTypes().FirstOrDefault(x => x.Namespace==EntityMapsNameSpace);
            if(map!= null)
                modelBuilder.ApplyConfigurationsFromAssembly(map.Assembly);
        }
    }
}