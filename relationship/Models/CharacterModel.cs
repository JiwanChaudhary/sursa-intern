using Backpack.Models;
using Faction.Models;
using Weapon.Models;


namespace Character.Models;

public class CharacterModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public BackpackModel? Backpack { get; set; }

    public List<WeaponModel>? Weapons { get; set; }
    public List<FactionModel>? Factions  { get; set; }



}