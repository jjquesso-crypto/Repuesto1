using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Aplicada1.Core;
using Repuesto1.Data.Context;
using Repuesto1.Data.Models;

namespace Repuesto1 ;

public class CompraServices() : IService<TblCompra, int>
{
    public Task<TblCompra?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TblCompra>> GetList(Expression<Func<TblCompra, bool>> criterio)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Guardar(TblCompra entidad)
    {
        throw new NotImplementedException();
    }
}