namespace Wbd.Pillars.ClassLib.Player;

[Serializable]
public class Creator
{
    public int LastActiveSlot { get; set; } = -1;
    public List<Character> Characters { get; set; } = [new(), new(), new(), new()];
}
