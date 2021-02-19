using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarServices
    {
        ICarDal _carDal;   // Burada bir constructor tanımlıyoruz. Bu sayede programımıza fonksiyonellik kazandırdık.

       

        // Başka bir sistem kullandığımızda business katmanında değişiklik yapmamıza gerek kalmayacak
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }

        public void Add(Car car)
        {

            if(car.Description.Length >=2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Hata! Araba tanımınız en az 2 karakterden oluşmalıdır veya günlük fiyat 0'dan büyük olmalıdır.");
            }

            

            
        }


        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Hata! Araba tanımınız en az 2 karakterden oluşmalıdır veya günlük fiyat 0'dan büyük olmalıdır.");
            }
        }
    }
}
