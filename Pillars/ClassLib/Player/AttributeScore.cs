namespace Wbd.Pillars.ClassLib.Player;

[Serializable]
public class AttributeScore
{
    #region Members
    private double _baseScore;
    private double _score;
    private bool _isDirty = false;
    #endregion Members

    #region Properties
    private double RawScore { get => _baseScore; set => _baseScore = value; }
    public double Score { get => ComputeScore(_baseScore); }
    #endregion Properties

    #region Ctor
    public AttributeScore(double baseScore)
    {
        _baseScore = baseScore;
    }
    #endregion Ctor

    #region Methods
    #endregion Methods

    #region Helpers
    private double ComputeScore(double baseScore)
    {
        return !_isDirty ? baseScore : baseScore;
    }
    #endregion Helpers
}
