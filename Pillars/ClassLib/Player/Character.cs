namespace Wbd.Pillars.ClassLib.Player;

[Serializable]
public class Character
{
    public string Name { get; set; } = default!;
    public AbilityScores Scores { get; set; } = default!;
}
