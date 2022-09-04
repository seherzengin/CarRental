using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Repositories;
using CarRental.Core.Services;
using CarRental.Core.UnitOfWorks;
using CarRental.Repository.Models;

namespace CarRental.Service.Services
{
    public class ColorService : Service<Color>,IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        public ColorService(IGenericRepository<Color> repository, IUnitOfWork unitOfWork, IColorRepository colorRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<ColorWithCarsDto>> GetSingleColorByIdWithCarAsync(int colorId)
        {
            var color = await _colorRepository.GetSingleColorByIdWithCarAsync(colorId);
            var colorDto = _mapper.Map<ColorWithCarsDto>(color);
            return CustomResponseDto<ColorWithCarsDto>.Success(200, colorDto);
        }

        
    }
}
