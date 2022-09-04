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
    public class CarImageServiceWithCaching:ICarImageService
    {
        private const string CacheCarimageKey = "carimagesCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly ICarImageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CarImageServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, ICarImageRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memoryCache.TryGetValue(CacheCarimageKey, out _))
            {
                _memoryCache.Set(CacheCarimageKey, _repository.GetAll().ToList());
            }
        }

        public async Task<Carimage> AddAsync(Carimage entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCarimagesAsync();
            return entity;
        }

        public async Task<IEnumerable<Carimage>> AddRangeAsync(IEnumerable<Carimage> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCarimagesAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Carimage, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Carimage>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Carimage>>(CacheCarimageKey));
        }

        public Task<Carimage> GetByIdAsync(int id)
        {
            var carimage = _memoryCache.Get<List<Carimage>>(CacheCarimageKey).FirstOrDefault(x => x.Id == id);

            return Task.FromResult(carimage);
        }

        public Task<CustomResponseDto<CarImageWithCarsDto>> GetSingleCarimageByIdWithCarAsync(int carimageId)
        {
            var carimages = _memoryCache.Get<IEnumerable<Carimage>>(CacheCarimageKey);

            var carImagesWithCarDto = _mapper.Map<CarImageWithCarsDto>(carimages);

            return Task.FromResult(CustomResponseDto<CarImageWithCarsDto>.Success(200, carImagesWithCarDto));
        }

        public async Task RemoveAsync(Carimage entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCarimagesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Carimage> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCarimagesAsync();
        }

        public async Task UpdateAsync(Carimage entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCarimagesAsync();
        }

        public IQueryable<Carimage> Where(Expression<Func<Carimage, bool>> expression)
        {
            return _memoryCache.Get<List<Carimage>>(CacheCarimageKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllCarimagesAsync()
        {
            _memoryCache.Set(CacheCarimageKey, await _repository.GetAll().ToListAsync());

        }
    }
}
