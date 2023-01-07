using System.Numerics;

namespace fib;

public class Program
{
    static void Main()
    {
        Console.WriteLine(Fibonacci(-1));
        Console.WriteLine(Fibonacci(0));
        Console.WriteLine(Fibonacci(6));
        Console.WriteLine(Fibonacci(7));
        Console.WriteLine(Fibonacci(8));
        Console.WriteLine(Fibonacci(50));
        Console.WriteLine(Fibonacci(250));
        Console.WriteLine(Fibonacci(500));
    }

    public static string Fibonacci(int n)
    {
        if (n < 0) { return $"The handling of negative numbers is not handled by this implementation of Fibonacci! (argument passed = {n})"; }
        BigInteger[] memoizator = new BigInteger[n + 1];
        return Fibonacci(n, memoizator).ToString();
    }

    private static BigInteger Fibonacci(int n, BigInteger[] memoizator)
    {
        if (memoizator[n] != 0) return memoizator[n];
        if (n <= 2) return BigInteger.One;
        memoizator[n] = Fibonacci(n - 1, memoizator) + Fibonacci(n - 2, memoizator);
        return memoizator[n];
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