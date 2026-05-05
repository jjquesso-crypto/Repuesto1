using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Models;
using Repuesto1.Services;
using Repuesto1.Tests.Infrastructure;
using Xunit;

namespace Repuesto1.Tests.Services;

public class ProductoServicesTests
{
    [Fact]
    public async Task Buscar_CuandoExisteProducto_RetornaEntidad()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblProductos.Add(CrearProducto(id: 1, nombre: "Filtro de Aceite", precio: 350, cantidad: 20));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ProductoServices(context);

        var result = await service.Buscar(1);

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
        Assert.Equal("Filtro de Aceite", result.Nombre);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteProducto_RetornaNull()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ProductoServices(context);

        var result = await service.Buscar(999);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetList_CuandoSeFiltraPorCantidad_RetornaCoincidencias()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblProductos.AddRange(
                CrearProducto(id: 1, nombre: "Aceite", precio: 500, cantidad: 15),
                CrearProducto(id: 2, nombre: "Bujía", precio: 200, cantidad: 3),
                CrearProducto(id: 3, nombre: "Filtro Aire", precio: 300, cantidad: 12)
            );

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ProductoServices(context);

        var result = await service.GetList(p => p.Cantidad > 10);

        Assert.Equal(2, result.Count);
        Assert.Contains(result, p => p.Id == 1);
        Assert.Contains(result, p => p.Id == 3);
        Assert.DoesNotContain(result, p => p.Id == 2);
    }

    [Fact]
    public async Task Guardar_CuandoProductoEsNuevo_InsertaCorrectamente()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ProductoServices(context);

        var nuevoProducto = CrearProducto(id: 10, nombre: "Radiador", precio: 4500, cantidad: 5);

        var result = await service.Guardar(nuevoProducto);

        Assert.True(result);

        var saved = await context.TblProductos.FirstOrDefaultAsync(p => p.Id == 10);

        Assert.NotNull(saved);
        Assert.Equal("Radiador", saved!.Nombre);
        Assert.Equal(4500, saved.Precio);
    }

    //[Fact]
    //public async Task Guardar_CuandoProductoExiste_ModificaCorrectamente()
    //{
    //    var dbName = TestDbContextFactory.NewDatabaseName();

    //    await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
    //    {
    //        seedContext.TblProductos.Add(CrearProducto(id: 20, nombre: "Correa", precio: 700, cantidad: 8));
    //        await seedContext.SaveChangesAsync();
    //    }

    //    await using var context = TestDbContextFactory.CreateContext(dbName);
    //    var service = new ProductoServices(context);

    //    var actualizado = CrearProducto(id: 20, nombre: "Correa Industrial", precio: 1000, cantidad: 12);

    //    var result = await service.Guardar(actualizado);

    //    Assert.True(result);

    //    var saved = await context.TblProductos.FirstOrDefaultAsync(p => p.Id == 20);

    //    Assert.NotNull(saved);
    //    Assert.Equal("Correa Industrial", saved!.Nombre);
    //    Assert.Equal(1000, saved.Precio);
    //    Assert.Equal(12, saved.Cantidad);
    //}

    [Fact]
    public async Task Eliminar_CuandoExisteProducto_LoMarcaComoInactivo()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.TblProductos.Add(CrearProducto(id: 5, nombre: "Batería", precio: 2500, cantidad: 4));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ProductoServices(context);

        var result = await service.Eliminar(5);

        Assert.True(result);

        var producto = await context.TblProductos.FirstOrDefaultAsync(p => p.Id == 5);

        Assert.NotNull(producto);
        Assert.True(producto!.Inactivo);
    }

    private static TblProducto CrearProducto(int id, string nombre, decimal precio, int cantidad)
    {
        return new TblProducto
        {
            Id = id,
            Nombre = nombre,
            Precio = precio,
            Cantidad = cantidad,
            Inactivo = false
        };
    }
}