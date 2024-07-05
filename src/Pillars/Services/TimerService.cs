namespace Wbd.Pillars.Services;

public class TimerService
{
    #region Events
    public event EventHandler OnTick = default!;
    #endregion Events

    #region Properties
    private Timer Timer { get; set; } = default!;
    private int Interval { get; set; } = 1000;
    #endregion Properties

    #region Methods
    public void Start() => Timer = new Timer(Tick, null, 0, Interval);
    public void Stop() => Timer.Dispose();
    private void Tick(object? state) => OnTick?.Invoke(this, EventArgs.Empty);
    #endregion Methods
}