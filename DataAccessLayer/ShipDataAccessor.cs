using CoreTestApplication.DataAccessLayer;
using CoreTestApplication.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoreTestApplication.DataAccessLayer;

public class ShipDataAccessor : IShipDataAccessor
{
    private List<Ship> ships = new List<Ship>();

    private IWebHostEnvironment hostinEnvironment;
    public ShipDataAccessor(IWebHostEnvironment hostinEnvironment)
    {
        this.hostinEnvironment = hostinEnvironment;
        var stringShipData = System.IO.File.ReadAllText(Path.Combine(hostinEnvironment.ContentRootPath + "\\Data\\Ships.json"));
        this.ships = JsonConvert.DeserializeObject<List<Ship>>(stringShipData) ?? new List<Ship>();
    }

    public IEnumerable<Ship> GetShips()
    {
        return this.ships;
    }

    public IEnumerable<Ship> AddShip(Ship ship)
    {
        this.ships.Add(ship);
        return this.ships;
    }

    public IEnumerable<Ship> UpdateShip(Ship ship, string id)
    {
        var shipToBeDeleted = this.ships.FirstOrDefault(obj => obj.Id == id);
        this.ships.Remove(shipToBeDeleted);
        this.ships.Add(ship);
        return this.ships;
    }

    public IEnumerable<Ship> DeleteShip(string id)
    {
        var shipToBeDeleted = this.ships.FirstOrDefault(obj => obj.Id == id);
        this.ships.Remove(shipToBeDeleted);
        return this.ships;
    }

}