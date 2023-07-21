namespace Wbd.Pillars.ClassLib.Player;

[Serializable]
public class AbilityScores
{
    #region Properties
    public AttributeScore Strength { get; set; }
    public AttributeScore Dexterity { get; set; }
    public AttributeScore Constitution { get; set; }
    public AttributeScore Intelligence { get; set; }
    public AttributeScore Wisdom { get; set; }
    public AttributeScore Charisma { get; set; }
    #endregion Properties

    #region Ctor
    public AbilityScores(double str, double dex, double con, double intell, double wis, double cha)
    {
        Strength = new AttributeScore(str);
        Dexterity = new AttributeScore(dex);
        Constitution = new AttributeScore(con);
        Intelligence = new AttributeScore(intell);
        Wisdom = new AttributeScore(wis);
        Charisma = new AttributeScore(cha);
    }
    #endregion Ctor
}
