using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using System.Linq.Expressions;

namespace Repuesto1.Services;

public class VentasServices : IService<TblVentas, int>
{
    private readonly RepuestoContext _context;

    public VentasServices(RepuestoContext context)
    {
        _context = context;
    }

    // 💾 GUARDAR / ACTUALIZAR
    public async Task<bool> Guardar(TblVentas entidad)
    {
        if (entidad.Id == 0)
            await _context.TblVentas.AddAsync(entidad);
        else
            _context.TblVentas.Update(entidad);

        return await _context.SaveChangesAsync() > 0;
    }

    // 🔍 BUSCAR
    public async Task<TblVentas?> Buscar(int id)
    {
        return await _context.TblVentas.FindAsync(id);
    }

    // ❌ ELIMINAR
    public async Task<bool> Eliminar(int id)
    {
        var venta = await _context.TblVentas.FindAsync(id);

        if (venta == null)
            return false;

        _context.TblVentas.Remove(venta);

        return await _context.SaveChangesAsync() > 0;
    }

    // 📋 LISTAR
    public async Task<List<TblVentas>> GetList(Expression<Func<TblVentas, bool>> criterio)
    {
        return await _context.TblVentas
            .Where(criterio)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }
}