using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
   
    public class FindeksController : CustomBaseController
    {
        private readonly IFindekService _findekService;
        private readonly IMapper _mapper;

        public FindeksController(IFindekService findekService, IMapper mapper)
        {
            _findekService = findekService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var findeks = await _findekService.GetAllAsync();

            var findeksDto = _mapper.Map<List<FindekDto>>(findeks.ToList());

            return CreateActionResult(CustomResponseDto<List<FindekDto>>.Success(200, findeksDto));

        }

        [HttpGet("[action]/{findekId}")]
        public async Task<IActionResult> GetSingleFindekByIdWithCustomer(int findekId)
        {
            return CreateActionResult(await _findekService.GetSingleFindekByIdWithCustomerAsync(findekId));
        }
    }
}
