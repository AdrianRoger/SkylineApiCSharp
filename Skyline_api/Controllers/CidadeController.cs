﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skyline.Context;
using Skyline_api.Models;

namespace Skyline_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly DataContext _context;

        public CidadeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Cidade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidade>>> GetCidade()
        {
          if (_context.Cidade == null)
          {
              return NotFound();
          }
            return await _context.Cidade.ToListAsync();
        }

        // GET: api/Cidade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cidade>> GetCidade(int id)
        {
          if (_context.Cidade == null)
          {
              return NotFound();
          }
            var cidade = await _context.Cidade.FindAsync(id);

            if (cidade == null)
            {
                return NotFound();
            }

            return cidade;
        }

        // PUT: api/Cidade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCidade(int id, Cidade cidade)
        {
            if (id != cidade.id)
            {
                return BadRequest();
            }

            _context.Entry(cidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cidade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cidade>> PostCidade(Cidade cidade)
        {
          if (_context.Cidade == null)
          {
              return Problem("Entity set 'DataContext.Cidade'  is null.");
          }
            _context.Cidade.Add(cidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCidade", new { id = cidade.id }, cidade);
        }

        // DELETE: api/Cidade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCidade(int id)
        {
            if (_context.Cidade == null)
            {
                return NotFound();
            }
            var cidade = await _context.Cidade.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }

            _context.Cidade.Remove(cidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CidadeExists(int id)
        {
            return (_context.Cidade?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
