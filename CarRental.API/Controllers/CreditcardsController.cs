using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{

    public class CreditcardsController : CustomBaseController
    {
        private readonly ICreditcardService _creditCardService;
        private readonly IMapper _mapper;

        public CreditcardsController(ICreditcardService creditCardService, IMapper mapper)
        {
            _creditCardService = creditCardService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var creditCards = await _creditCardService.GetAllAsync();

            var creditCardsDto = _mapper.Map<List<CreditcardDto>>(creditCards.ToList());

            return CreateActionResult(CustomResponseDto<List<CreditcardDto>>.Success(200, creditCardsDto));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var creditCard = await _creditCardService.GetByIdAsync(id);
            var creditCardsDto = _mapper.Map<CreditcardDto>(creditCard);
            return CreateActionResult(CustomResponseDto<CreditcardDto>.Success(200, creditCardsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreditcardDto creditCardDto)
        {
            var creditCard = await _creditCardService.AddAsync(_mapper.Map<Creditcard>(creditCardDto));
            var creditCardsDto = _mapper.Map<CreditcardDto>(creditCard);
            return CreateActionResult(CustomResponseDto<CreditcardDto>.Success(201, creditCardsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CreditcardDto creditCardDto)
        {
            await _creditCardService.UpdateAsync(_mapper.Map<Creditcard>(creditCardDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var creditCard = await _creditCardService.GetByIdAsync(id);

            await _creditCardService.RemoveAsync(creditCard);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("[action]/{creditCardId}")]
        public async Task<IActionResult> GetSingleCreditcardByIdWithUser(int creditCardId)
        {
            return CreateActionResult(await _creditCardService.GetSingleCreditcardByIdWithUserAsync(creditCardId));
        }
    }
}
