using System;

public enum Light
{
    Red,
    Green,
    Yellow
}

public class TrafficLights
{
    static void Main()
    {
        string[] lights = Console.ReadLine().Split();
        int n = int.Parse(Console.ReadLine());
        int itterator = 0;
        for (int i = 0; i < n; i++)
        {
            foreach (var light in lights)
            {
                int nextLightIndex = (int) Enum.Parse(typeof(Light), light) + 1 + itterator;
                Light nextLight = (Light) (nextLightIndex % 3);
                Console.Write(nextLight + " "); 
            }
            Console.WriteLine();
            itterator++;
        }
    }
}