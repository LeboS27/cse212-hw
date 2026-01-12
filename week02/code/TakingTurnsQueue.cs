using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private class PersonQueueItem
    {
        public string Name { get; }
        public int Turns { get; set; }  // Can be set to update remaining turns
        
        public PersonQueueItem(string name, int turns)
        {
            Name = name;
            Turns = turns;
        }
    }
    
    private readonly Queue<PersonQueueItem> _queue = new Queue<PersonQueueItem>();
    
    public int Length => _queue.Count;
    
    public void AddPerson(string name, int turns)
    {
        _queue.Enqueue(new PersonQueueItem(name, turns));
    }
    
    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }
        
        var currentPerson = _queue.Dequeue();
        
        // Check if person should be re-enqueued
        bool shouldReEnqueue = false;
        
        if (currentPerson.Turns <= 0)  // Infinite turns
        {
            shouldReEnqueue = true;
        }
        else if (currentPerson.Turns > 0)
        {
            currentPerson.Turns--;  // Use one turn
            if (currentPerson.Turns > 0)
            {
                shouldReEnqueue = true;
            }
        }
        
        // Return the person (with updated turns)
        Person result = new Person(currentPerson.Name, currentPerson.Turns);
        
        // Re-enqueue if needed
        if (shouldReEnqueue)
        {
            _queue.Enqueue(currentPerson);
        }
        
        return result;
    }
}