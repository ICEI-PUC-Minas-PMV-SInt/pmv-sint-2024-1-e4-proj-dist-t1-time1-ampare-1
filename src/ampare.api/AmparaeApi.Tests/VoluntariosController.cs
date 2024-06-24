using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ampare.api.Controllers;
using ampare.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;  // Certifique-se de que esta linha está presente
using Moq;


public class VoluntariosControllerTests
{
    private readonly VoluntariosController _controller;
    private readonly AppDbContext _context;

    public VoluntariosControllerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new AppDbContext(options);
        _controller = new VoluntariosController(_context);
    }


    public async Task GetVoluntario_ReturnsAllVoluntarios()
    {
        // Arrange
        _context.Voluntarios.Add(new Voluntario { VoluntarioId = 1, Nome = "Voluntario 1" });
        _context.Voluntarios.Add(new Voluntario { VoluntarioId = 2, Nome = "Voluntario 2" });
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetVoluntario();

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<Voluntario>>>(result);
        var voluntarios = Assert.IsAssignableFrom<IEnumerable<Voluntario>>(actionResult.Value);
        Assert.Equal(2, voluntarios.Count());
    }


    public async Task GetVoluntario_ReturnsVoluntarioById()
    {
        // Arrange
        var voluntario = new Voluntario { VoluntarioId = 1, Nome = "Voluntario 1" };
        _context.Voluntarios.Add(voluntario);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetVoluntario(1);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Voluntario>>(result);
        var returnedVoluntario = Assert.IsType<Voluntario>(actionResult.Value);
        Assert.Equal(voluntario.VoluntarioId, returnedVoluntario.VoluntarioId);
    }

    
    public async Task Create_AddsNewVoluntario()
    {
        // Arrange
        var voluntario = new Voluntario { VoluntarioId = 1, Nome = "Voluntario 1" };

        // Act
        var result = await _controller.Create(voluntario);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Voluntario>>(result);
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        var createdVoluntario = Assert.IsType<Voluntario>(createdAtActionResult.Value);
        Assert.Equal(voluntario.VoluntarioId, createdVoluntario.VoluntarioId);
    }

    
    public async Task Update_UpdatesVoluntario()
    {
        // Arrange
        var voluntario = new Voluntario { VoluntarioId = 1, Nome = "Voluntario 1" };
        _context.Voluntarios.Add(voluntario);
        await _context.SaveChangesAsync();

        voluntario.Nome = "Voluntario Atualizado";

        // Act
        var result = await _controller.Update(1, voluntario);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var updatedVoluntario = await _context.Voluntarios.FindAsync(1);
        Assert.Equal("Voluntario Atualizado", updatedVoluntario.Nome);
    }

    
    public async Task Delete_RemovesVoluntario()
    {
        // Arrange
        var voluntario = new Voluntario { VoluntarioId = 1, Nome = "Voluntario 1" };
        _context.Voluntarios.Add(voluntario);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.Delete(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
        var deletedVoluntario = await _context.Voluntarios.FindAsync(1);
        Assert.Null(deletedVoluntario);
    }
}
