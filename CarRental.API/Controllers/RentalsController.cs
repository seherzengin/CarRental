﻿using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    public class RentalsController : CustomBaseController
    {
        private readonly IRentalService _rentalService;
        private readonly IMapper _mapper;

        public RentalsController(IRentalService rentalService, IMapper mapper)
        {
            _rentalService = rentalService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var rentals = await _rentalService.GetAllAsync();

            var rentalsDto = _mapper.Map<List<RentalDto>>(rentals.ToList());

            return CreateActionResult(CustomResponseDto<List<RentalDto>>.Success(200, rentalsDto));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rental = await _rentalService.GetByIdAsync(id);
            var rentalDto = _mapper.Map<RentalDto>(rental);
            return CreateActionResult(CustomResponseDto<RentalDto>.Success(200, rentalDto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRentalByIdWithCustomer(int rentalId)
        {
            return CreateActionResult(await _rentalService.GetRentalByIdWithCustomerAsync(rentalId));
        }

    }
}
