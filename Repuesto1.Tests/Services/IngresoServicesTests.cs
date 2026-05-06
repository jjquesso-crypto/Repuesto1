using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Models;
using Repuesto1.Services;
using Repuesto1.Tests.Infrastructure;
using Xunit;

namespace Repuesto1.Tests.Services;

public class IngresoServicesTests
{
    [Fact]
    public async Task Buscar_CuandoExisteIngreso_RetornaEntidad()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblIngresos.Add(CrearIngreso(id: 1, concepto: "Ingreso inicial", monto: 5000));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new IngresoServices(context);

        var result = await service.Buscar(1);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
        Assert.Equal("Ingreso inicial", result.Concepto);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteIngreso_RetornaNull()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new IngresoServices(context);

        var result = await service.Buscar(999);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetList_CuandoSeFiltraPorTipo_RetornaCoincidencias()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblIngresos.AddRange(
                CrearIngreso(id: 1, concepto: "Venta 1", monto: 2000, tipo: "VENTA"),
                CrearIngreso(id: 2, concepto: "Ingreso Manual", monto: 1000, tipo: "INGRESO"),
                CrearIngreso(id: 3, concepto: "Venta 2", monto: 3000, tipo: "VENTA")
            );

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new IngresoServices(context);

        var result = await service.GetList(i => i.Tipo == "VENTA");

        Assert.Equal(2, result.Count);
        Assert.Contains(result, i => i.Id == 1);
        Assert.Contains(result, i => i.Id == 3);
        Assert.DoesNotContain(result, i => i.Id == 2);
    }

    [Fact]
    public async Task Guardar_CuandoIngresoEsNuevo_InsertaCorrectamente()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new IngresoServices(context);

        var nuevoIngreso = CrearIngreso(id: 10, concepto: "Nuevo ingreso", monto: 8000);

        var result = await service.Guardar(nuevoIngreso);

        Assert.True(result);

        var saved = await context.TblIngresos.FirstOrDefaultAsync(i => i.Id == 10);

        Assert.NotNull(saved);
        Assert.Equal("Nuevo ingreso", saved!.Concepto);
        Assert.Equal(8000, saved.Monto);
    }

    [Fact]
    public async Task Guardar_CuandoIngresoExiste_ModificaCorrectamente()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblIngresos.Add(CrearIngreso(id: 20, concepto: "Ingreso viejo", monto: 1500));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new IngresoServices(context);

        var actualizado = CrearIngreso(id: 20, concepto: "Ingreso actualizado", monto: 9999);

        var result = await service.Guardar(actualizado);

        Assert.True(result);

        var saved = await context.TblIngresos.FirstOrDefaultAsync(i => i.Id == 20);

        Assert.NotNull(saved);
        Assert.Equal("Ingreso actualizado", saved!.Concepto);
        Assert.Equal(9999, saved.Monto);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteIngreso_EliminaCorrectamente()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblIngresos.Add(CrearIngreso(id: 5, concepto: "Eliminar ingreso", monto: 1000));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new IngresoServices(context);

        var result = await service.Eliminar(5);

        Assert.True(result);
        Assert.Empty(context.TblIngresos);
    }

    private static TblIngreso CrearIngreso(int id, string concepto, decimal monto, string tipo = "INGRESO")
    {
        return new TblIngreso
        {
            Id = id,
            Fecha = DateTime.Now,
            Tipo = tipo,
            Concepto = concepto,
            Monto = monto,
            IdReferencia = null,
            TipoReferencia = null
        };
    }
}