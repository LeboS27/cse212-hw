using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Basic priority check - highest priority first
    // Expected: "C" (3), then "B" (2), then "A" (1)
    // Bug: Not removing items, loop misses last element
    public void Test1_BasicPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 3);
        
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Same priority should be FIFO
    // Expected: "First" then "Third" (both priority 3)
    // Bug: >= selects last occurrence, should use > for first occurrence
    public void Test2_SamePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 3);
        pq.Enqueue("Second", 2);
        pq.Enqueue("Third", 3);
        
        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Empty queue throws exception
    // Expected: InvalidOperationException with correct message
    // Bug: Works, but verifying
    public void Test3_EmptyQueue()
    {
        var pq = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Single item works
    // Expected: That item is returned
    public void Test4_SingleItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Single", 5);
        Assert.AreEqual("Single", pq.Dequeue());
    }
}