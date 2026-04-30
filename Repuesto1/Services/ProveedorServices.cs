using System.Text;
using Microsoft.EntityFrameworkCore;
using Aplicada1.Core;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using System.Linq.Expressions;

namespace Repuesto1.Services;

public class ProveedorServices() : IService<TblProveedore, int>
{
    public Task<TblProveedore?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TblProveedore>> GetList(Expression<Func<TblProveedore, bool>> criterio)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Guardar(TblProveedore entidad)
    {
        throw new NotImplementedException();
    }
}
