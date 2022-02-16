using CoreTestApplication.Models;

namespace CoreTestApplication.DataAccessLayer;

public interface IShipDataAccessor 
{
    IEnumerable<Ship> GetShips();
    IEnumerable<Ship> AddShip(Ship ship);

    IEnumerable<Ship> UpdateShip(Ship ship, string id);

    IEnumerable<Ship> DeleteShip(string id);

}