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
        if(obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }
        
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public async Task<T> Delete(int id)
    {

        var entity = await _context.Set<T>().FindAsync(id);

        if (entity is null) 
        {
            throw new InvalidOperationException("Object not found");
        }
        _context.Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> Update(T obj)
    {
        if(obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }
        
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return obj;
    }

    public async Task<T> Get(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);

        return entity;

    }
}
