using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class FindeksController : Controller
    {
        private readonly IFindekService _service;
        private readonly IMapper _mapper;

        public FindeksController(IFindekService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();
            return View(_mapper.Map<List<FindekDto>>(response));
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(FindekDto findekDto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Findek>(findekDto));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var findek = await _service.GetByIdAsync(id);


            var findeks = await _service.GetAllAsync();

            var findeksDto = _mapper.Map<List<FindekDto>>(findeks.ToList());

            ViewBag.findeks = new SelectList(findeksDto, "Id", "Score", findek);

            return View(_mapper.Map<FindekDto>(findek));
        }

        [HttpPost]
        public async Task<IActionResult> Update(FindekDto findekDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Findek>(findekDto));
                return RedirectToAction(nameof(Index));
            }

            var findeks = await _service.GetAllAsync();

            var findeksDto = _mapper.Map<List<FindekDto>>(findeks.ToList());

            ViewBag.findeks = new SelectList(findeksDto, "Id", "Score", findekDto);

            return View(findekDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var findek = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(findek);
            return RedirectToAction(nameof(Index));
        }
    }
}
