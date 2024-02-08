using Backpack.RequestModels;

namespace Character.RequestModels;

public class CharacterRequestModel
{
    public string? Name { get; set; }
    public BackpackRequestModel? BackpackRequest { get; set; }
}