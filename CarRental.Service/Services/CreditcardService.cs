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
    public class CreditcardService : Service<Creditcard>, ICreditcardService
    {
        private readonly ICreditcardRepository _creditCardRepository;
        private readonly IMapper _mapper;
        public CreditcardService(IGenericRepository<Creditcard> repository, IUnitOfWork unitOfWork, ICreditcardRepository creditCardRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CreditcardWithUserDto>> GetSingleCreditcardByIdWithUserAsync(int creditCardId)
        {
            var creditCard = await _creditCardRepository.GetSingleCreditcardByIdWithUserAsync(creditCardId);
            var creditCardDto = _mapper.Map<CreditcardWithUserDto>(creditCard);
            return CustomResponseDto<CreditcardWithUserDto>.Success(200, creditCardDto);
        }
    }
      
    
}
