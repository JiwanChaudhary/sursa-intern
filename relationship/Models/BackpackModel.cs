using Character.Models;

namespace Backpack.Models;

public class BackpackModel
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int CharacterId { get; set; }

    public CharacterModel? Character { get; set; }
}