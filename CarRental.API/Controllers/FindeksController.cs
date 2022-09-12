using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var findek = await _findekService.GetByIdAsync(id);
            var findeksDto = _mapper.Map<FindekDto>(findek);
            return CreateActionResult(CustomResponseDto<FindekDto>.Success(200, findeksDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(FindekDto findekDto)
        {
            var findek = await _findekService.AddAsync(_mapper.Map<Findek>(findekDto));
            var findeksDto = _mapper.Map<FindekDto>(findek);
            return CreateActionResult(CustomResponseDto<FindekDto>.Success(201, findeksDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(FindekDto findekDto)
        {
            await _findekService.UpdateAsync(_mapper.Map<Findek>(findekDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var findek = await _findekService.GetByIdAsync(id);

            await _findekService.RemoveAsync(findek);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("[action]/{findekId}")]
        public async Task<IActionResult> GetSingleFindekByIdWithCustomer(int findekId)
        {
            return CreateActionResult(await _findekService.GetSingleFindekByIdWithCustomerAsync(findekId));
        }
    }
}
