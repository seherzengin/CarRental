﻿using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandService _service;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();
            return View(_mapper.Map<List<BrandDto>>(response));
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(BrandDto brandDto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Brand>(brandDto));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var brand = await _service.GetByIdAsync(id);


            var brands = await _service.GetAllAsync();

            var brandsDto = _mapper.Map<List<BrandDto>>(brands.ToList());

            ViewBag.brands = new SelectList(brandsDto, "Id","BrandsName", brand);

            return View(_mapper.Map<BrandDto>(brand));
        }

        [HttpPost]
        public async Task<IActionResult> Update(BrandDto brandDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Brand>(brandDto));
                return RedirectToAction(nameof(Index));
            }

            var brands = await _service.GetAllAsync();

            var brandsDto = _mapper.Map<List<BrandDto>>(brands.ToList());

            ViewBag.brands = new SelectList(brandsDto, "Id", "BrandsName", brandDto);

            return View(brandDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var brand = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(brand);
            return RedirectToAction(nameof(Index));
        }
    }
}