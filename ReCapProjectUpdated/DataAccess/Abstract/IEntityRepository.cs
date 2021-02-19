using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository <T> where T: class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null); // Tüm listeyi istenilen filtreye göre verir. Filtre 'null' ise hepsini verir.
        T Get(Expression<Func<T, bool>> filter); // Belirli bir özelliğin detaylarını vermek için kullanılır
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        
    }
}
