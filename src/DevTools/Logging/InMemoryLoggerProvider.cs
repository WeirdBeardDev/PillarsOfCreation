using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Wbd.Pillars.DevTools.Logging;

[ProviderAlias("InMemoryLog")]
public sealed class InMemoryLoggerProvider : ILoggerProvider
{
    public event EventHandler? LogAdded;
    private readonly ConcurrentDictionary<string, InMemoryLogger> _loggers = new();

    public InMemoryLoggerProvider()
    { }

    public ILogger CreateLogger(string categoryName) => _loggers.GetOrAdd(categoryName, name => new InMemoryLogger(name, this));

    public void Dispose() => _loggers.Clear();

    public IEnumerable<string> GetAllLogEntries() => _loggers.Values.SelectMany(logger => logger.GetEntries());

    internal void NotifyLogAdded() => LogAdded?.Invoke(this, EventArgs.Empty);
}