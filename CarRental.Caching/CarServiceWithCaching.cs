using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Repositories;
using CarRental.Core.Services;
using CarRental.Core.UnitOfWorks;
using CarRental.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace CarRental.Caching
{
    public class CarServiceWithCaching : ICarService
    {
        private const string CacheCarKey = "carsCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly ICarRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CarServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, ICarRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memoryCache.TryGetValue(CacheCarKey, out _))
            {
                _memoryCache.Set(CacheCarKey, _repository.GetAll().ToList());
            }
        }

        public async Task<Car> AddAsync(Car entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCarsAsync();
            return entity;
        }

        public async Task<IEnumerable<Car>> AddRangeAsync(IEnumerable<Car> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCarsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Car, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Car>>(CacheCarKey));
        }

        public  Task<CustomResponseDto<CarDto>> GetCarByIdAsync(int Id)
        {
            var cars = _memoryCache.Get<IEnumerable<Car>>(CacheCarKey);

            var carsDto = _mapper.Map<List<CarDto>>(cars);

            return Task.FromResult(_memoryCache.Get<CustomResponseDto<CarDto>>(CacheCarKey) );
        }

        

        public Task<CustomResponseDto<List<CarWithCarImageDto>>> GetCarWithCarImage()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Car entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCarsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Car> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCarsAsync();
        }

        public async Task UpdateAsync(Car entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCarsAsync();
        }

        public IQueryable<Car> Where(Expression<Func<Car, bool>> expression)
        {
            return _memoryCache.Get<List<Car>>(CacheCarKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllCarsAsync()
        {
            _memoryCache.Set(CacheCarKey, await _repository.GetAll().ToListAsync());

        }

        public Task<Car> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
