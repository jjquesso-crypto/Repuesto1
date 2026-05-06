using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Models;
using Repuesto1.Services;
using Repuesto1.Tests.Infrastructure;
using Xunit;

namespace Repuesto1.Tests.Services;

public class CompraServicesTests
{
    [Fact]
    public async Task Buscar_CuandoExisteCompra_RetornaEntidad()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblCompras.Add(CreateCompra(1, "C-001", 500));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new CompraServices(context);

        var result = await service.Buscar(1);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
        Assert.Equal("C-001", result.NumeroFactura);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteCompra_RetornaNull()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new CompraServices(context);

        var result = await service.Buscar(999);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetList_CuandoSeFiltraPorTotal_RetornaCoincidencias()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblCompras.AddRange(
                CreateCompra(1, "C-001", 100),
                CreateCompra(2, "C-002", 300),
                CreateCompra(3, "C-003", 700)
            );
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new CompraServices(context);

        var result = await service.GetList(c => c.Total > 200);

        Assert.Equal(2, result.Count);
        Assert.Contains(result, c => c.Id == 2);
        Assert.Contains(result, c => c.Id == 3);
        Assert.DoesNotContain(result, c => c.Id == 1);
    }

    [Fact]
    public async Task Guardar_CuandoCompraEsValida_InsertaCorrectamente()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new CompraServices(context);

        var nuevaCompra = CreateCompra(10, "C-010", 900);

        var result = await service.Guardar(nuevaCompra);

        Assert.True(result);

        var savedEntity = await context.TblCompras.FirstOrDefaultAsync(c => c.Id == 10);
        Assert.NotNull(savedEntity);
        Assert.Equal("C-010", savedEntity!.NumeroFactura);
    }

    [Fact]
    public async Task Guardar_CuandoCompraExiste_ModificaCorrectamente()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblCompras.Add(CreateCompra(20, "C-020", 100));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new CompraServices(context);

        var compraActualizada = CreateCompra(20, "C-020-MOD", 1500);

        var wasUpdated = await service.Guardar(compraActualizada);

        Assert.True(wasUpdated);

        var saved = await context.TblCompras.FirstOrDefaultAsync(c => c.Id == 20);
        Assert.NotNull(saved);
        Assert.Equal("C-020-MOD", saved!.NumeroFactura);
        Assert.Equal(1500, saved.Total);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteCompra_EliminaCorrectamente()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblCompras.Add(CreateCompra(5, "C-005", 200));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new CompraServices(context);

        var result = await service.Eliminar(5);

        Assert.True(result);
        Assert.Empty(context.TblCompras);
    }

    private static TblCompra CreateCompra(int id, string factura, decimal total)
    {
        return new TblCompra
        {
            Id = id,
            NumeroFactura = factura,
            Fecha = DateTime.Now,
            IdProveedor = 1,
            SubTotal = total,
            Iva = total * 0.18m,
            Total = total,
            Estado = "PAGADA"
        };
    }
}