namespace Wbd.Pillars.ClassLib.Player;

[Serializable]
public class Character
{
    public string Name { get; set; }
    public AbilityScores Scores { get; set; } = default!;
}
