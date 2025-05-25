using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Wbd.Pillars.DevTools.Logging;

public sealed class InMemoryLogger : ILogger
{
    private const int MaxLogLength = 1000;
    private readonly string _name;
    private readonly InMemoryLoggerProvider _provider;
    private readonly ConcurrentQueue<string> _logQueue = new();

    public InMemoryLogger(string name, InMemoryLoggerProvider provider)
    {
        _name = name;
        _provider = provider;
    }

    IDisposable ILogger.BeginScope<TState>(TState state) => default!;

    public bool IsEnabled(LogLevel logLevel) => true;
    public int Count => _logQueue.Count;
    public IEnumerable<string> GetEntries() => _logQueue.ToArray();

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception, string> formatter)
    {
        ArgumentNullException.ThrowIfNull(formatter);
        if (IsEnabled(logLevel))
        {
            var message = formatter(state, exception ?? new Exception("No exception provided"));
            var levelName = logLevel switch
            {
                LogLevel.Trace => "TRACE",
                LogLevel.Debug => "DEBUG",
                LogLevel.Information => "INFO",
                LogLevel.Warning => "WARN",
                LogLevel.Error => "ERROR",
                LogLevel.Critical => "CRITICAL",
                _ => "UNKNOWN"
            };
            var toLog = $"[{levelName}] [{_name}]: {message}";
            System.Console.WriteLine(toLog);
            if (_logQueue.Count >= MaxLogLength)
            {
                _logQueue.TryDequeue(out _);
            }
            _logQueue.Enqueue(toLog);
            _provider.NotifyLogAdded();
            if (exception != null)
            {
                System.Console.WriteLine(exception);
            }
        }
    }
}