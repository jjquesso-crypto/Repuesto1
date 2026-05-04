using Aplicada1.Core;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repuesto1.Services;

public class UsuarioServices : IService<TblUsuario, int>
{
    private readonly RepuestoContext _context;

    public UsuarioServices(RepuestoContext context)
    {
        _context = context;
    }

    public async Task<bool> Guardar(TblUsuario entidad)
    {
        if (entidad.Id == 0)
            await _context.TblUsuarios.AddAsync(entidad);
        else
            _context.TblUsuarios.Update(entidad);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<TblUsuario?> Buscar(int id)
    {
        return await _context.TblUsuarios.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var usuario = await _context.TblUsuarios.FindAsync(id);

        if (usuario == null)
            return false;

        usuario.Activo = false;

        _context.TblUsuarios.Update(usuario);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<TblUsuario>> GetList(Expression<Func<TblUsuario, bool>> criterio)
    {
        return await _context.TblUsuarios
            .Where(criterio)
            .ToListAsync();
    }

    // 🔐 VALIDAR LOGIN
    public async Task<TblUsuario?> ValidarLogin(string usuario, string clave)
    {
        return await _context.TblUsuarios
            .FirstOrDefaultAsync(u =>
                u.NombreUsuario == usuario &&
                u.Contraseña == clave &&
                u.Activo == true);
    }

    // 👥 OBTENER ROLES
    public async Task<List<string>> ObtenerRoles()
    {
        return await _context.TblUsuarios
            .Where(x => x.Rol != null)
            .Select(x => x.Rol!)
            .Distinct()
            .ToListAsync();
    }
}