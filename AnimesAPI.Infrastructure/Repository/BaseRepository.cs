using AnimesAPI.Domain.Interfaces.Repositories;
using AnimesAPI.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AnimesAPI.Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AnimesDBContext _context;

    public BaseRepository(AnimesDBContext context)
    {
        _context = context;
    }
    public async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public async Task Delete(T obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> Update(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return obj;
    }
}
