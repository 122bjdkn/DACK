﻿using DACK.Models;
using Microsoft.EntityFrameworkCore;

namespace DACK.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            // return await _context.Products.ToListAsync();
            return await _context.Categories
        .ToListAsync();


        }
        public async Task<Category> GetByIdAsync(int id)
        {
            // return await _context.Products.FindAsync(id);
            // lấy thông tin kèm theo category
            return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var catagory = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(catagory);
            await _context.SaveChangesAsync();
        }

    }
}