namespace Wbd.Pillars.ClassLib.Player;

[Serializable]
public class Stats
{
    public Stats(double strength, double dexterity, double constitution, double intelligence, double wisdom, double personality)
    {
        Strength = new AttributeScore(strength);
        Dexterity = new AttributeScore(dexterity);
        Constitution = new AttributeScore(constitution);
        Intelligence = new AttributeScore(intelligence);
        Wisdom = new AttributeScore(wisdom);
        Personality = new AttributeScore(personality);
    }
    [JsonConstructor]
    public Stats(AttributeScore strength, AttributeScore dexterity, AttributeScore constitution, AttributeScore intelligence, AttributeScore wisdom, AttributeScore personality)
    {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Personality = personality;
    }

    public AttributeScore Strength { get; set; }
    public AttributeScore Dexterity { get; set; }
    public AttributeScore Constitution { get; set; }
    public AttributeScore Intelligence { get; set; }
    public AttributeScore Wisdom { get; set; }
    public AttributeScore Personality { get; set; }
}
