using Microsoft.EntityFrameworkCore;
using Character.Models;
using Backpack.Models;
using Weapon.Models;
using Faction.Models;


namespace Relationship.Data;

public class ApplicationDBContext : DbContext
{

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    public DbSet<CharacterModel> Characters { get; set; } = default!;
    public DbSet<BackpackModel> Backpacks { get; set; } = default!;
    public DbSet<WeaponModel> Weapons { get; set; } = default!;
    public DbSet<FactionModel> Factions { get; set; } = default!;

}