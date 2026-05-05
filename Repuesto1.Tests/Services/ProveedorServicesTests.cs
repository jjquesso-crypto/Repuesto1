using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Models;
using Repuesto1.Services;
using Repuesto1.Tests.Infrastructure;
using Xunit;

namespace Repuesto1.Tests.Services;

public class ProveedorServicesTests
{
    [Fact]
    public async Task Buscar_CuandoExisteProveedor_RetornaEntidad()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblProveedores.Add(CrearProveedor(id: 1, nombre: "Auto Import"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ProveedorServices(context);

        var result = await service.Buscar(1);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
        Assert.Equal("Auto Import", result.Nombre);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteProveedor_RetornaNull()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ProveedorServices(context);

        var result = await service.Buscar(999);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetList_CuandoSeFiltraPorNombre_RetornaCoincidencias()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblProveedores.AddRange(
                CrearProveedor(id: 1, nombre: "Auto Repuestos SRL"),
                CrearProveedor(id: 2, nombre: "Moto Piezas"),
                CrearProveedor(id: 3, nombre: "Auto Import")
            );

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ProveedorServices(context);

        var result = await service.GetList(p => p.Nombre.Contains("Auto"));

        Assert.Equal(2, result.Count);
        Assert.Contains(result, p => p.Id == 1);
        Assert.Contains(result, p => p.Id == 3);
        Assert.DoesNotContain(result, p => p.Id == 2);
    }

    [Fact]
    public async Task Guardar_CuandoProveedorEsNuevo_InsertaCorrectamente()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ProveedorServices(context);

        var nuevoProveedor = CrearProveedor(id: 10, nombre: "Proveedor Nuevo");

        var result = await service.Guardar(nuevoProveedor);

        Assert.True(result);

        var saved = await context.TblProveedores.FirstOrDefaultAsync(p => p.Id == 10);

        Assert.NotNull(saved);
        Assert.Equal("Proveedor Nuevo", saved!.Nombre);
    }

    [Fact]
    public async Task Guardar_CuandoProveedorExiste_ModificaCorrectamente()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblProveedores.Add(CrearProveedor(id: 20, nombre: "Proveedor Viejo"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ProveedorServices(context);

        var actualizado = CrearProveedor(id: 20, nombre: "Proveedor Actualizado");

        var result = await service.Guardar(actualizado);

        Assert.True(result);

        var saved = await context.TblProveedores.FirstOrDefaultAsync(p => p.Id == 20);

        Assert.NotNull(saved);
        Assert.Equal("Proveedor Actualizado", saved!.Nombre);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteProveedor_LoMarcaComoInactivo()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblProveedores.Add(CrearProveedor(id: 5, nombre: "Proveedor Eliminar"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ProveedorServices(context);

        var result = await service.Eliminar(5);

        Assert.True(result);

        var proveedor = await context.TblProveedores.FirstOrDefaultAsync(p => p.Id == 5);

        Assert.NotNull(proveedor);
        Assert.True(proveedor!.Inactivo);
    }

    private static TblProveedore CrearProveedor(int id, string nombre)
    {
        return new TblProveedore
        {
            Id = id,
            Nombre = nombre,
            Ruc = "101010101",
            Telefono = "8090000000",
            Direccion = "Nagua",
            Email = "proveedor@test.com",
            Inactivo = false
        };
    }
}