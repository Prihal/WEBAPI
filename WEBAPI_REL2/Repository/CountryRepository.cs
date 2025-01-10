using AutoMapper;
using WEBAPI_REL2.Data;
using WEBAPI_REL2.Interfaces;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Repository
{
    public class CountryRepository: ICountryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(AppDbContext context,IMapper mapper)
        {
            _context=context;
            _mapper=mapper;

        }

        public bool CountryExist(int id)
        {
           return _context.Countrys.Any(c=>c.Id==id);
        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);

            return Save();
        }

        public bool DeleteCountry(Country country)
        {
           _context.Remove(country);
            return Save();
        }

        public ICollection<Country> GetAllCountry()
        {
            return _context.Countrys.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countrys.Where(c=>c.Id==id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int Oid)
        {
            return _context.Owners.Where(o => o.Id == Oid).Select(o => o.country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerFromACountry(int cid)
        {
            return _context.Owners.Where(c => c.country.Id == cid).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return Save();
        }
    }
}
