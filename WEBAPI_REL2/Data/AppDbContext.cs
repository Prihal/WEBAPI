using Microsoft.EntityFrameworkCore;
using WEBAPI_REL2.Models;

namespace WEBAPI_REL2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonCatagory> PokemonCatagories { get; set; }
        public DbSet<Pokemonowner> Pokemonowners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCatagory>()
                .HasOne(p => p.Pokemons)
                .WithMany(p => p.PokemonCatagorys)
                .HasForeignKey(c=>c.p_id);
            modelBuilder.Entity<PokemonCatagory>()
                .HasOne(pa => pa.Categories)
                .WithMany(pa => pa.pokemonCatagories)
                .HasForeignKey(ca => ca.c_id);

            modelBuilder.Entity<Pokemonowner>()
                .HasOne(ps => ps.Pokemons)
                .WithMany(ps =>ps.Pokemonowners)
                .HasForeignKey(s => s.p_id);
            modelBuilder.Entity<Pokemonowner>()
               .HasOne(pd => pd.Owners)
               .WithMany(pd =>pd.Pokemonowners)
               .HasForeignKey(d => d.o_id);
        }
    }
}
