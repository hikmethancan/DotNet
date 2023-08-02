using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    // Generic Constraint where T : class diyerek T'nin class olması gerekir diyerek kısıtlıyoruz. , IEntity diyerek bu T'nin IEntity classına ait bir referans verilmesi şartını koyarız. Bu sayede yanlış referans vermesini engellemiş oluruz.
    // new() : new'lenebilir referans verilmeli. Çünkü IEntity referenası verirsek te yanlış olur. Category Product gibi IEntity'i implemente eden bir class'ı referans olabilme şartını burada vermiş olduk.
    public interface IEntityRepository<T> where T : class,IEntity, new()
    {

        /*
         Expression Yapısı ile şöyle bir fayda sağlanabilir.
        GetAll() Metoduna koşul verebiliriz. Mesela product.GetAll(p=>p.CategoryId == 2) olanları getir gibi birşey diyebiliriz.
        Daha Generic bir yazım olur ve çok fayda sağlar.
        GetAllByCategoryId Metoduna bu sayede gerek kalmaz ve daha Clean bir kod sağlamış oluruz.
        */

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get();

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
