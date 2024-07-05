using Wbd.Pillars.ClassLib.DataStore;

namespace Wbd.Pillars.ClassLib.Player;

[Serializable]
public class Character
{
    public string Name { get; set; } = Data.NewCharacterName;
    public string ImageFileName { get; set; } = Data.DefaultImageFileName;
    public AttributeScore Strength { get; set; } = new(0);
    public AttributeScore Dexterity { get; set; } = new(0);
    public AttributeScore Constitution { get; set; } = new(0);
    public AttributeScore Intelligence { get; set; } = new(0);
    public AttributeScore Wisdom { get; set; } = new(0);
    public AttributeScore Personality { get; set; } = new(0);
    public DateTime? LastPlayed { get; set; } = null;
}
