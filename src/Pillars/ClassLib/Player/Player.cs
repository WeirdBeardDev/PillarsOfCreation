namespace Wbd.Pillars.ClassLib.Player;

[Serializable]
public class Player
{
    public int LastActiveSlot { get; set; } = -1;
    public List<PlayerCharacter> Characters { get; set; } = [new(), new(), new(), new()];
}
