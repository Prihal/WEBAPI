using System.Diagnostics.Eventing.Reader;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetAllCountry();

        Country GetCountry(int id);
        Country GetCountryByOwner(int Oid);

        ICollection<Owner> GetOwnerFromACountry(int cid);

        bool CountryExist(int id);

        bool CreateCountry(Country country);

        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);

        bool Save();

    }
}
