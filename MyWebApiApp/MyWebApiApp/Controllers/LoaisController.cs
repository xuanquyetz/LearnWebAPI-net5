using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaisController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var danhsachloai = _context.Loais.ToList();
            return Ok(danhsachloai);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            var danhsachloai=_context.Loais.FirstOrDefault(q=>q.MaLoai == id);
            if(danhsachloai == null)
            {
                return NotFound();
            }
            return Ok(danhsachloai);

        }
        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
           
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, LoaiModel model)
        {
            try
            {
                var danhsachloai = _context.Loais.FirstOrDefault(q => q.MaLoai == id);
                if (danhsachloai == null)
                {
                    return NotFound();
                }
                danhsachloai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return Ok();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
           

        }
        [HttpDelete ("{id}")]
        public IActionResult Remove(int id)
        {
            var danhsachloai = _context.Loais.FirstOrDefault(q => q.MaLoai == id);
            if (danhsachloai == null)
            {
                return NotFound();
            }
            _context.Loais.Remove(danhsachloai);
            _context.SaveChanges();
            return Ok();

        }
    }
}
