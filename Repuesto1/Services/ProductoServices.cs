using System.Text;
using Microsoft.EntityFrameworkCore;
using Aplicada1.Core;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using System.Linq.Expressions;

namespace Repuesto1.Services;

public class ProductoServices() : IService<TblProducto, int>
{
    public Task<TblProducto?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TblProducto>> GetList(Expression<Func<TblProducto, bool>> criterio)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Guardar(TblProducto entidad)
    {
        throw new NotImplementedException();
    }
}
