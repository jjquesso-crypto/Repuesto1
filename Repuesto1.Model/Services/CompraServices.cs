using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Aplicada1.Core;

namespace Repuesto1.Data.Services;

public class CompraServices() : IService<Compra, int>
{
    public Task<Compra?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Compra>> GetList(Expression<Func<Compra, bool>> criterio)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Guardar(Compra entidad)
    {
        throw new NotImplementedException();
    }
}