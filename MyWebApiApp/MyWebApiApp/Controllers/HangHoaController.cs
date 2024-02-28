using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using HangHoa = MyWebApiApp.Data.HangHoa;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly MyDbContext _context;

        //public static List<HangHoa> hangHoas = new List<HangHoa>();
        public HangHoaController(MyDbContext context) 
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var hanghoa = _context.HangHoas.ToList();
            return Ok(hanghoa);
        }
        [HttpGet ("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = _context.HangHoas.FirstOrDefault(q => q.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }
        [HttpPost]
        public IActionResult Greate(HangHoaVM hangHoaVM)
        {
            try
            {
                var hanghoa = new HangHoa
                {
                    MaHangHoa = System.Guid.NewGuid(),
                    TenHangHoa = hangHoaVM.TenHangHoa,
                    MoTa=hangHoaVM.MoTa,
                    Gia = hangHoaVM.Gia,
                    GiamGia=hangHoaVM.GiaGiam,
                    MaLoai=hangHoaVM.MaLoai,
                };
                _context.HangHoas.Add(hanghoa);
                _context.SaveChanges();
                return Ok(new
                {
                    Seccess = true,
                    Data = hanghoa
                });
            }
            catch (Exception)
            {

                return BadRequest();
            }
           
        }
        [HttpPut ("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                var hangHoa = _context.HangHoas.FirstOrDefault(q => q.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.Gia=hangHoaEdit.Gia;
                hangHoa.MoTa=hangHoaEdit.MoTa;
                hangHoa.MaLoai=hangHoaEdit.MaLoai;
                hangHoa.GiamGia = hangHoaEdit.GiamGia;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete ("{id}")]
        public IActionResult Remove (string id)
        {
            try
            {
                var hangHoa = _context.HangHoas.FirstOrDefault(q => q.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                _context.HangHoas.Remove(hangHoa);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
