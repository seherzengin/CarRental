using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
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

        [HttpGet("[action]/{creditCardId}")]
        public async Task<IActionResult> GetSingleCreditcardByIdWithUser(int creditCardId)
        {
            return CreateActionResult(await _creditCardService.GetSingleCreditcardByIdWithUserAsync(creditCardId));
        }
    }
}
