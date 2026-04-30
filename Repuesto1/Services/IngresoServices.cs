using System.Text;
using Microsoft.EntityFrameworkCore;
using Aplicada1.Core;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;
using System.Linq.Expressions;

namespace Repuesto1.Services;

public class IngresoServices() : IService<TblIngreso, int>
{
    public Task<TblIngreso?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TblIngreso>> GetList(Expression<Func<TblIngreso, bool>> criterio)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Guardar(TblIngreso entidad)
    {
        throw new NotImplementedException();
    }
}
