using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebMappApplication.Interfaces;
using WebMappApplication.Model;

namespace WebMappApplication.Services
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        //private readonly EFDataContext _context;
        //DbSet<T>? _object = null;
        //public GenericRepository(EFDataContext context)
        //{
        //    _context = context; 
        //    _object = context.Set<T>();
        //}

        private readonly IUnitOfWork _unitOfWork;
        DbSet<T> _object = null;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _object = unitOfWork.Set<T>();
        }
        public T Add(T p)
        {
            _object.Add(p);
            //id random nasıl gelecek burada bilemiyorum
            _unitOfWork.Save();
            return p;
        }

        public List<T> Delete (int id)
        {
            _object.Remove(Get(id));
            _unitOfWork.Save();
            return GetAll();
        }

        public T Get(int id)
        {
            return _object.Find(id);
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public List<T> Update(T p)
        {
            _object.Update(p);
            _unitOfWork.Save();
            return GetAll();
        }
    }
}
