using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class ColorsController : Controller
    {
        private readonly ColorApiService _colorApiService;

        public ColorsController(ColorApiService colorApiService)
        {
            _colorApiService = colorApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _colorApiService.GetAllAsync());
        }
       
    }
}
