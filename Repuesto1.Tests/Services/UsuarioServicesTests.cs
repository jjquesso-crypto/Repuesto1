using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Models;
using Repuesto1.Services;
using Repuesto1.Tests.Infrastructure;
using Xunit;

namespace Repuesto1.Tests.Services;

public class UsuarioServicesTests
{
    [Fact]
    public async Task Guardar_CuandoUsuarioEsValido_GuardaCorrectamente()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new UsuarioServices(context);

        var usuario = CreateUsuario(0);

        var result = await service.Guardar(usuario);

        Assert.True(result);
        Assert.Equal(1, context.TblUsuarios.Count());
    }

    [Fact]
    public async Task ValidarLogin_CuandoDatosSonCorrectos_RetornaUsuario()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seed = TestDbContextFactory.CreateContext(dbName))
        {
            seed.TblUsuarios.Add(CreateUsuario(1));
            await seed.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new UsuarioServices(context);

        var result = await service.ValidarLogin("admin", "1234");

        Assert.NotNull(result);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteUsuario_LoDesactiva()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seed = TestDbContextFactory.CreateContext(dbName))
        {
            seed.TblUsuarios.Add(CreateUsuario(2));
            await seed.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new UsuarioServices(context);

        var result = await service.Eliminar(2);

        Assert.True(result);
        Assert.False(context.TblUsuarios.First().Activo);
    }

    private static TblUsuario CreateUsuario(int id)
    {
        return new TblUsuario
        {
            Id = id,
            NombreUsuario = "admin",
            Contraseña = "1234",
            NombreCompleto = "Administrador",
            Rol = "Admin",
            Activo = true
        };
    }
}