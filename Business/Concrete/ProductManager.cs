using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Logger;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        readonly IProductDal _productDal;


        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        //Cross Cutting Concers Validation, Cache, Log, Performance, Auth, Transaction
        //AOP - Aspect Oriented Programing(yazılım geliştirme yaklaşımıdır.)

        [ValidationAspect(typeof(ProductValidator), Priortiy = 1)]
        //[CacheRemoveAspect("IProductService.Get")]//kontrol edilmesi gerekiyor çalışmıyor 
        //[CacheRemoveAspect("ICategoryService.Get")]

        //[ValidationAspect(typeof(ProductValidator), Priortiy = 2)]

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> GetById(int productId)
        {

            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
        }
        [PerformanceAspect(5)]
        public IDataResult<List<Product>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }
        //[SecuredOperation("Product.List,Admim")]
        [LogAspect(typeof(FileLogger))] 
        [CacheAspect(duration:10)]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().Where(p => p.CategoryID == categoryId).ToList());
        }
       
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            //burada yapılma amaç işlem hata alındığın database aktarılan veriyi geri alınsın.
            _productDal.Update(product);
            //_productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
