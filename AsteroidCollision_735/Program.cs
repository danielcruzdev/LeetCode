namespace AsteroidCollision_735;

class Program
{
    static void Main(string[] args)
    {
        int[] asteroids = [5, 10, -5];
        var result = AsteroidCollision(asteroids);
        Console.WriteLine(string.Join(", ", result));
        
        asteroids = [8, -8];
        result = AsteroidCollision(asteroids);
        Console.WriteLine(string.Join(", ", result));
        
        asteroids = [10, 2, -5];
        result = AsteroidCollision(asteroids);
        Console.WriteLine(string.Join(", ", result));
        
        asteroids = [3, 5, -6, 2, -1, 4];
        result = AsteroidCollision(asteroids);
        Console.WriteLine(string.Join(", ", result));
        
        asteroids = [-2, -1, 1, 2];
        result = AsteroidCollision(asteroids);
        Console.WriteLine(string.Join(", ", result));
        
        asteroids = [-2, 2, 1, -2];
        result = AsteroidCollision(asteroids);
        Console.WriteLine(string.Join(", ", result));
    }
    
    private static int[] AsteroidCollision(int[] asteroids) 
    {
        // Use the input array as an in-place stack to avoid O(n) extra allocation.
        // 'top' is the index of the last element in our virtual stack.
        int top = -1;

        foreach (var asteroid in asteroids)
        {
            bool alive = true;
            
            while (alive && asteroid < 0 && top >= 0 && asteroids[top] > 0)
            {
                if (asteroids[top] < -asteroid)
                    top--;                  // current destroys top; keep checking
                else if (asteroids[top] == -asteroid)
                {
                    top--;                  // mutual destruction
                    alive = false;
                }
                else
                    alive = false;          // top survives; current is destroyed
            }

            if (alive)
                asteroids[++top] = asteroid;
        }
        
        return asteroids[..(top + 1)];
    }
}