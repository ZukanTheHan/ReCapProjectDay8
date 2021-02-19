using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq; // Linq kullanımı için gerekli, unutmayalım.
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; // Veri tabanı.Burada ise bir araba listesi oluşturuyoruz, tüm operasyonların üstünde olmasının nedeni ise bu listenin global olmasını istememiz.
        public InMemoryCarDal() // Constructor yapısı ile veri tabanımızda bir ürün listesi oluşturuyoruz.
        {
            _cars = new List<Car>() {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2019,DailyPrice=200,Description="Opel Astra Sedan - Siyah"},
                new Car{Id=2,BrandId=2,ColorId=2,ModelYear=2020,DailyPrice=210,Description="Ford Focus Otomatik- Beyaz"},
                new Car{Id=3,BrandId=3,ColorId=3,ModelYear=2020,DailyPrice=280,Description="Audi A3 - Metalik Mavi"},
                new Car{Id=4,BrandId=4,ColorId=4,ModelYear=2019,DailyPrice=325,Description="Volkswagen Tiguan SUV - Kırmızı"},
                new Car{Id=5,BrandId=5,ColorId=5,ModelYear=2020,DailyPrice=1250,Description="Mercedes Benz E200 Exclusive Command - Gri"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car); // Business'dan gelen Car parametreli nesnemiz veri tabanımıza ekliyoruz. 
        }                   // Veri tabanımız liste biçiminde olduğu için Add fonksiyonunu kullanıyoruz.

        public void Delete(Car car)
        {
            //_cars.Remove(car); // Bu gösterim burada işe yaramaz. Çünkü, referanslarla çalışıyoruz.Bizim için önemli olan değeri tutan adres.
            //Car carToDelete = null;  // Şuan adresi boş. Adresi,veri tabanında silinecek adrese eşitleyeceğiz.
            //*********************************//
            //Linq Kullanmadan Algoritmik Çözüm
            //*********************************//
            //foreach (var c in _cars) 
            //{
            //    if(c.Id == car.Id) // Parametreyle gelen car ID'sini veri tabanında bulunan diğer car ID'leri ile kıyasılıyoruz.
            //    {
            //        carToDelete = c; // Eşit olanı bulduğumuzda onu silinecek olan carToDelet'e atıyoruz.
            //    }
            //}
            //*********************************//
            //Linq Kullanımı
            //*********************************//
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);  
            
            _cars.Remove(carToDelete); // Silme işlemini gerçekleştiriyoruz.
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars; // Burada veri tabanının tümünü gösteren/veren bir operasyon için return komutunu kullanıyoruz.
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int iD)
        {
            return _cars.Where(c => c.Id == iD).ToList();
        }

        public void Update(Car car)
        {
            // Güncellemek istediğimiz arabımızın ID'sini listeden bulup bilgilerini güncelliyoruz.
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
