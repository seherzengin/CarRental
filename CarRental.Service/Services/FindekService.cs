using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Repositories;
using CarRental.Core.Services;
using CarRental.Core.UnitOfWorks;
using CarRental.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Services
{
    public class FindekService : Service<Findek>, IFindekService
    {
        private readonly IFindekRepository _findekRepository;
        private readonly IMapper _mapper;
        public FindekService(IGenericRepository<Findek> repository, IUnitOfWork unitOfWork, IFindekRepository findekRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _findekRepository = findekRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<FindekWithCustomerDto>> GetSingleFindekByIdWithCustomerAsync(int findekId)
        {
            var findek = await _findekRepository.GetSingleFindekByIdWithCustomerAsync(findekId);
            var findekDto = _mapper.Map<FindekWithCustomerDto>(findek);
            return CustomResponseDto<FindekWithCustomerDto>.Success(200, findekDto);
        }
    }
}
