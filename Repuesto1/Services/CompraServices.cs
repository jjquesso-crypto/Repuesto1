using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using System.Linq.Expressions;

namespace Repuesto1.Services;

public class CompraServices : IService<TblCompra, int>
{
    private readonly RepuestoContext _context;

    public CompraServices(RepuestoContext context)
    {
        _context = context;
    }

    // 💾 GUARDAR (INSERT / UPDATE)
    public async Task<bool> Guardar(TblCompra entidad)
    {
        var existe = entidad.Id != 0
            && await _context.TblProveedores.AsNoTracking().AnyAsync(p => p.Id == entidad.Id);

        if (!existe)
            await _context.TblCompras.AddAsync(entidad);
        else
            _context.TblCompras.Update(entidad);

        return await _context.SaveChangesAsync() > 0;
    }

    // 🔍 BUSCAR POR ID
    public async Task<TblCompra?> Buscar(int id)
    {
        return await _context.TblCompras
            .Include(c => c.TblDetalleCompras)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    // ❌ ELIMINAR (SOFT DELETE OPCIONAL)
    public async Task<bool> Eliminar(int id)
    {
        var compra = await _context.TblCompras.FindAsync(id);

        if (compra == null)
            return false;

        _context.TblCompras.Remove(compra);

        return await _context.SaveChangesAsync() > 0;
    }

    // 📋 LISTADO FILTRADO
    public async Task<List<TblCompra>> GetList(Expression<Func<TblCompra, bool>> criterio)
    {
        return await _context.TblCompras
            .Where(criterio)
            .ToListAsync();
    }

    // 📦 LISTADO COMPLETO CON DETALLES
    public async Task<List<TblCompra>> GetAll()
    {
        return await _context.TblCompras
            .Include(c => c.TblDetalleCompras)
            .OrderByDescending(c => c.Fecha)
            .ToListAsync();
    }
}