using System.Numerics;

namespace fib;

public class Program
{
    static void Main()
    {
        SafeFibonacci(-1);
        SafeFibonacci(0);
        SafeFibonacci(7);
        SafeFibonacci(8);
        SafeFibonacci(50);
        SafeFibonacci(250);
        SafeFibonacci(500);
    }

    public static void SafeFibonacci(int n)
    {
        try
        {
            Console.WriteLine(Fibonacci(n));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static BigInteger Fibonacci(int n)
    {
        if (n < 0) 
        { 
            throw new ArgumentException($"The handling of negative numbers ({n}) is not handled by this implementation of Fibonacci!"); 
        }
        var memo = new BigInteger[n + 1];
        return Fibonacci(n, memo);
    }

    private static BigInteger Fibonacci(int n, BigInteger[] memo)
    {
        if (memo[n] != 0) return memo[n];
        if (n <= 2) return BigInteger.One;
        memo[n] = Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
        return memo[n];
    }
}

/*
// Memoization in JavaScript
// js Object, key will be arg to fn, value will be the return value

const fib = (n, memo = {}) => {
    if (n in memo) return memo[n];
    if (n <= 2) return 1;
    memo[n] = fib(n - 1, memo) + fib(n - 2, memo);
    return memo[n];
};

console.log(fib(6));
console.log(fib(7));
console.log(fib(8));
console.log(fib(50));

*/