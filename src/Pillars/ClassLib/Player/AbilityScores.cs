namespace Wbd.Pillars.ClassLib.Player;

[Serializable]
public class AbilityScores(double str, double dex, double con, double intell, double wis, double per)
{
    public AttributeScore Strength { get; set; } = new AttributeScore(str);
    public AttributeScore Dexterity { get; set; } = new AttributeScore(dex);
    public AttributeScore Constitution { get; set; } = new AttributeScore(con);
    public AttributeScore Intelligence { get; set; } = new AttributeScore(intell);
    public AttributeScore Wisdom { get; set; } = new AttributeScore(wis);
    public AttributeScore Personality { get; set; } = new AttributeScore(per);
}
