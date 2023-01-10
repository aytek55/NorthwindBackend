using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Cashing
{
    public interface ICacheService
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object data, int duration);

        /// <summary>
        /// Getireceğim veri Cash de var mı yok mu onun kontrolünü yaparak Cash ekleme ya da Cash silme yapacağım.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsAdded(string key);
        void Remove(string key);


        /// <summary>
        /// Örnegin tüm liste verilerimi silmek istiyorum Buraya GetList yazarsam GetList Methodu ile Cashlenmiş verilerim cash den silinir.
        /// Burada öndemli olan GetList isimlendirme standartına dikkat etmek. GetAll kullanmıyorum.
        /// </summary>
        /// <param name="pattern"></param>
        void RemoveByPattern(string pattern); 
    }
}
