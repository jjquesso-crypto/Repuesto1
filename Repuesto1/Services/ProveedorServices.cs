using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using System.Linq.Expressions;

namespace Repuesto1.Services;

public class ProveedorServices : IService<TblProveedore, int>
{
    private readonly RepuestoContext _context;

    public ProveedorServices(RepuestoContext context)
    {
        _context = context;
    }

    // 💾 GUARDAR / ACTUALIZAR
    public async Task<bool> Guardar(TblProveedore entidad)
    {
        var existe = entidad.Id != 0
            && await _context.TblProveedores.AsNoTracking().AnyAsync(p => p.Id == entidad.Id);

        if (!existe)
            await _context.TblProveedores.AddAsync(entidad);
        else
            _context.TblProveedores.Update(entidad);

        return await _context.SaveChangesAsync() > 0;
    }

    // 🔍 BUSCAR
    public async Task<TblProveedore?> Buscar(int id)
    {
        return await _context.TblProveedores.FindAsync(id);
    }

    // ❌ ELIMINAR (soft delete)
    public async Task<bool> Eliminar(int id)
    {
        var proveedor = await _context.TblProveedores.FindAsync(id);

        if (proveedor == null)
            return false;

        proveedor.Inactivo = true;

        _context.TblProveedores.Update(proveedor);

        return await _context.SaveChangesAsync() > 0;
    }

    // 📋 LISTAR CON FILTRO
    public async Task<List<TblProveedore>> GetList(Expression<Func<TblProveedore, bool>> criterio)
    {
        return await _context.TblProveedores
            .Where(criterio)
            .ToListAsync();
    }
}