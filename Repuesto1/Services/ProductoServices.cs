using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using System.Linq.Expressions;

namespace Repuesto1.Services;

public class ProductoServices : IService<TblProducto, int>
{
    private readonly RepuestoContext _context;

    public ProductoServices(RepuestoContext context)
    {
        _context = context;
    }

    // 💾 GUARDAR / ACTUALIZAR
    public async Task<bool> Guardar(TblProducto entidad)
    {
        var existe = entidad.Id != 0
            && await _context.TblProveedores.AsNoTracking().AnyAsync(p => p.Id == entidad.Id);

        if (!existe)
            await _context.TblProductos.AddAsync(entidad);
        else
            _context.TblProductos.Update(entidad);

        return await _context.SaveChangesAsync() > 0;
    }

    // 🔍 BUSCAR
    public async Task<TblProducto?> Buscar(int id)
    {
        return await _context.TblProductos.FindAsync(id);
    }

    // ❌ ELIMINAR (soft delete)
    public async Task<bool> Eliminar(int id)
    {
        var producto = await _context.TblProductos.FindAsync(id);

        if (producto == null)
            return false;

        producto.Inactivo = true;

        _context.TblProductos.Update(producto);

        return await _context.SaveChangesAsync() > 0;
    }

    // 📋 LISTAR CON FILTRO
    public async Task<List<TblProducto>> GetList(Expression<Func<TblProducto, bool>> criterio)
    {
        return await _context.TblProductos
            .Where(criterio)
            .ToListAsync();
    }
}