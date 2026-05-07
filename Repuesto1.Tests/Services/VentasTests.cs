using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Models;
using Repuesto1.Services;
using Repuesto1.Tests.Infrastructure;
using Xunit;

namespace Repuesto1.Tests.Services;

public class VentasTests
{
    [Fact]
    public async Task Guardar_CuandoEsNuevaVenta_InsertaCorrectamente()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VentasServices(context);
        var nuevaVenta = new TblVentas
        {
            NumeroFactura = "FAC-001",
            Fecha = DateTime.Now,
            SubTotal = 100,
            Itebis = 18,
            Total = 118,
            Estado = "Activa"
        };

        var result = await service.Guardar(nuevaVenta);

        Assert.True(result);
        var savedVenta = await context.TblVentas.FirstOrDefaultAsync(v => v.NumeroFactura == "FAC-001");
        Assert.NotNull(savedVenta);
        Assert.Equal(118, savedVenta!.Total);
    }

    [Fact]
    public async Task Guardar_CuandoVentaExiste_ActualizaCorrectamente()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            var ventaExistente = new TblVentas
            {
                Id = 1,
                NumeroFactura = "FAC-001",
                SubTotal = 100,
                Itebis = 18,
                Total = 118,
                Estado = "Activa"
            };
            seedContext.TblVentas.Add(ventaExistente);
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VentasServices(context);
        var ventaActualizada = new TblVentas
        {
            Id = 1,
            NumeroFactura = "FAC-001",
            SubTotal = 200,
            Itebis = 36,
            Total = 236,
            Estado = "Pagada"
        };
        var result = await service.Guardar(ventaActualizada);

        Assert.True(result);
        var savedVenta = await context.TblVentas.FindAsync(1);
        Assert.Equal(236, savedVenta!.Total);
        Assert.Equal("Pagada", savedVenta.Estado);
    }

    [Fact]
    public async Task Buscar_CuandoExisteVenta_RetornaEntidad()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblVentas.Add(new TblVentas
            {
                Id = 1,
                NumeroFactura = "FAC-001",
                Total = 118
            });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VentasServices(context);
        var result = await service.Buscar(1);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
        Assert.Equal("FAC-001", result.NumeroFactura);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteVenta_RetornaNull()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new VentasServices(context);

        var result = await service.Buscar(999);

        Assert.Null(result);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteVenta_EliminaCorrectamente()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblVentas.Add(new TblVentas { Id = 1, NumeroFactura = "FAC-001" });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VentasServices(context);
        var result = await service.Eliminar(1);

        Assert.True(result);
        Assert.Empty(context.TblVentas);
    }

    [Fact]
    public async Task Eliminar_CuandoNoExisteVenta_RetornaFalse()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new VentasServices(context);

        var result = await service.Eliminar(999);

        Assert.False(result);
    }

    [Fact]
    public async Task GetList_CuandoSeFiltraPorEstado_RetornaCoincidencias()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblVentas.AddRange(
                new TblVentas { Id = 1, NumeroFactura = "FAC-001", Estado = "Activa", Fecha = DateTime.Now },
                new TblVentas { Id = 2, NumeroFactura = "FAC-002", Estado = "Pagada", Fecha = DateTime.Now },
                new TblVentas { Id = 3, NumeroFactura = "FAC-003", Estado = "Activa", Fecha = DateTime.Now });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VentasServices(context);
        var result = await service.GetList(v => v.Estado == "Activa");

        Assert.Equal(2, result.Count);
        Assert.Contains(result, v => v.Id == 1);
        Assert.Contains(result, v => v.Id == 3);
        Assert.DoesNotContain(result, v => v.Id == 2);
    }

    [Fact]
    public async Task GetList_RetornaOrdenadoPorFechaDescendente()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblVentas.AddRange(
                new TblVentas { Id = 1, NumeroFactura = "FAC-001", Fecha = new DateTime(2024, 1, 1) },
                new TblVentas { Id = 2, NumeroFactura = "FAC-002", Fecha = new DateTime(2025, 1, 1) },
                new TblVentas { Id = 3, NumeroFactura = "FAC-003", Fecha = new DateTime(2023, 1, 1) });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VentasServices(context);
        var result = await service.GetList(v => true);

        Assert.Equal(3, result.Count);
        Assert.Equal(2025, result[0].Fecha?.Year);
        Assert.Equal(2024, result[1].Fecha?.Year);
        Assert.Equal(2023, result[2].Fecha?.Year);
    }
}