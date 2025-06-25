using Wbd.Pillars.ClassLib.DataStore;

namespace Wbd.Pillars.ClassLib.Player;

[Serializable]
public class PlayerCharacter
{
    public string Name { get; set; } = Data.NewCharacterName;
    public string ImageFileName { get; set; } = Data.DefaultImageFileName;
    public Stats Stats { get; set; } = new Stats(0, 0, 0, 0, 0, 0);
    public string Skills { get; set; } = string.Empty;
    public string StartingLocation { get; set; } = string.Empty;
    public string Items { get; set; } = string.Empty;
    public DateTime? LastPlayed { get; set; } = null;
    public bool ContainsCharacter => !string.IsNullOrEmpty(Name) && Name != Data.NewCharacterName && !string.IsNullOrWhiteSpace(ImageFileName) && Stats != null;
}
