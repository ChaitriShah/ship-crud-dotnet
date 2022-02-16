using Microsoft.AspNetCore.Mvc;
using CoreTestApplication.Models;
using CoreTestApplication.DataAccessLayer;

namespace CoreTestApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipController : ControllerBase
{
    private IWebHostEnvironment hostinEnvironment;
    private IShipDataAccessor shipDataAccessor;
    public ShipController(IWebHostEnvironment hostinEnvironment, IShipDataAccessor shipDataAccessor)
    {
        this.hostinEnvironment = hostinEnvironment;
        this.shipDataAccessor = shipDataAccessor;
    }

    [HttpGet]
    public IEnumerable<Ship> GetShips()
    {
        return this.shipDataAccessor.GetShips();
    }

    [HttpPost]
    public IEnumerable<Ship> AddShip(Ship ship)
    {
        return this.shipDataAccessor.AddShip(ship);
    }

    [HttpPut("{id}")]
    public IEnumerable<Ship> UpdateShip(Ship ship, string id)
    {
        return this.shipDataAccessor.UpdateShip(ship, id);
    }

    [HttpDelete("{id}")]
    public IEnumerable<Ship> DeleteShip(string id)
    {
        return this.shipDataAccessor.DeleteShip(id);
    }
}