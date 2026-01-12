using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public void Enqueue(string value, int priority)
    {
        _queue.Add(new PriorityItem(value, priority));
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        // Find highest priority (first occurrence for ties)
        int highestIndex = 0;
        for (int i = 1; i < _queue.Count; i++)  // Fixed: was _queue.Count - 1
        {
            if (_queue[i].Priority > _queue[highestIndex].Priority)  // Fixed: was >=
                highestIndex = i;
        }

        string value = _queue[highestIndex].Value;
        _queue.RemoveAt(highestIndex);  // Fixed: Now actually removes
        return value;
    }

    public override string ToString() => $"[{string.Join(", ", _queue)}]";
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString() => $"{Value} (Pri:{Priority})";
}