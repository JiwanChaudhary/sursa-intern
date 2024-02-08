using Character.Models;


namespace Weapon.Models;

public class WeaponModel
{


    public int Id { get; set; }

    public string? Name { get; set; }

    public int CharacterId { get; set; }

    public CharacterModel? Character { get; set; }



}