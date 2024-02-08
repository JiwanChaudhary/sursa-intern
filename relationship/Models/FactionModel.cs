using Character.Models;


namespace Faction.Models;

public class FactionModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<CharacterModel>? Characters { get; set; }



}