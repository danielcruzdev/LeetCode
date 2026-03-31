namespace NumberRecentCalls_933;

class Program
{
    static void Main(string[] args)
    {
        RecentCounter recentCounter = new RecentCounter();
        Console.WriteLine(recentCounter.Ping(1));    // 1
        Console.WriteLine(recentCounter.Ping(100));  // 2
        Console.WriteLine(recentCounter.Ping(3001)); // 3
        Console.WriteLine(recentCounter.Ping(3002)); // 3
    }
}

public class RecentCounter
{
    private Queue<int> _queue;

    public RecentCounter()
    {
        _queue = new Queue<int>();
    }

    public int Ping(int t)
    {
        _queue.Enqueue(t);

        while (_queue.Peek() < t - 3000)
            _queue.Dequeue();

        return _queue.Count;
    }
}