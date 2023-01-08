using System.Numerics;

namespace grid_traveller;

public class Program
{
    static void Main()
    {
        SafeGridTraveller(1, 1);
        SafeGridTraveller(1, 2);
        SafeGridTraveller(2, 1);
        SafeGridTraveller(2, 2);
        SafeGridTraveller(2, 3);
        SafeGridTraveller(3, 2);
        SafeGridTraveller(3, 3);
        SafeGridTraveller(18, 18);
        SafeGridTraveller(99, 99);
    }

    public static void SafeGridTraveller(int cols, int rows)
    {
        try
        {
            Console.WriteLine($"There are {GridTraveller(cols, rows)} routes to get from top left to bottom right of a {cols} by {rows} grid (going down and right).");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static BigInteger GridTraveller(int cols, int rows)
    {
        if (cols < 1) throw new ArgumentException($"Grids have to contain at least one column!");
        if (rows < 1) throw new ArgumentException($"Grids have to contain at least one row!");

        var memo = new Dictionary<string, BigInteger>();

        return GridTraveller(cols, rows, memo);
    }

    private static BigInteger GridTraveller(int cols, int rows, Dictionary<string, BigInteger> memo)
    {
        var key = cols > rows ? rows + ":" + cols : cols + ":" + rows;
        if (memo.ContainsKey(key)) { return memo[key]; }

        if (cols == 1 && rows == 1)
        {
            memo[key] = BigInteger.One;
            return memo[key];
        }

        if (cols == 0 || rows == 0)
        {
            memo[key] = BigInteger.Zero;
            return memo[key];
        }

        memo[key] = GridTraveller(cols - 1, rows, memo) + GridTraveller(cols, rows - 1, memo);
        return memo[key];
    }
}