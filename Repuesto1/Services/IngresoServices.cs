using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using System.Linq.Expressions;

namespace Repuesto1.Services;

public class IngresoServices : IService<TblIngreso, int>
{
    private readonly RepuestoContext _context;

    public IngresoServices(RepuestoContext context)
    {
        _context = context;
    }

    // 💾 GUARDAR
    public async Task<bool> Guardar(TblIngreso entidad)
    {
        if (entidad.Id == 0)
            await _context.TblIngresos.AddAsync(entidad);
        else
            _context.TblIngresos.Update(entidad);

        return await _context.SaveChangesAsync() > 0;
    }

    // 🔍 BUSCAR
    public async Task<TblIngreso?> Buscar(int id)
    {
        return await _context.TblIngresos.FindAsync(id);
    }

    // ❌ ELIMINAR
    public async Task<bool> Eliminar(int id)
    {
        var ingreso = await _context.TblIngresos.FindAsync(id);

        if (ingreso == null)
            return false;

        _context.TblIngresos.Remove(ingreso);

        return await _context.SaveChangesAsync() > 0;
    }

    // 📋 LISTAR CON FILTRO
    public async Task<List<TblIngreso>> GetList(Expression<Func<TblIngreso, bool>> criterio)
    {
        return await _context.TblIngresos
            .Where(criterio)
            .OrderByDescending(i => i.Fecha)
            .ToListAsync();
    }
}