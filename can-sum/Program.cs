using System.Numerics;
using System.Runtime.CompilerServices;

namespace can_sum;

public class Program
{
    static void Main()
    {
        CanSumDisplay(7, 2, 3); // true
        CanSumDisplay(7, 5, 4, 3, 7); // true
        CanSumDisplay(7, 2, 4); // false
        CanSumDisplay(8, 2, 3, 5); // true
        CanSumDisplay(3000, 7, 14); // false
    }

    public static bool CanSumDisplay(int targetSum, params int[] numbers)
    {
        var result = CanSum(targetSum, numbers);
        Console.WriteLine($"You {(result ? "can" : "can't")} make {targetSum} out of the numbers [{String.Join(" & ", numbers)}]!");
        return result;
    }

    public static bool CanSum(int targetSum, params int[] numbers)
    {
        var memo = new Dictionary<int, bool>();

        return CanSum(targetSum, numbers, memo);
    }

    private static bool CanSum(int targetSum, int[] numbers, Dictionary<int, bool> memo)
    {
        if (memo.ContainsKey(targetSum)) return memo[targetSum];
        if (targetSum == 0) return true;
        if (targetSum < 0) return false;

        foreach (var number in numbers)
        {
            var remainder = targetSum - number;
            if (CanSum(remainder, numbers, memo) == true)
            {
                memo[targetSum] = true;
                return true;
            } 
        }

        memo[targetSum] = false;
        return false;
    }
}

/*
// Memoization in JavaScript
// js Object, key will be arg to fn, value will be the return value

const CanSum = (targetSum, numbers, memo = {}) => {
if (targetSum in memo) return memo[targetSum];
if (targetSum == 0) return true;
if (targetSum < 0) return false;

for (let num of numbers) {
    const remainder = targetSum - num;
    if (canSum(remainder, numbers, memo) == true) {
        memo[tagetSum] = true;
        return true;
    }
}

memo[target] = false;
return false;
};

console.log(canSum(7, [2, 3])); // true
console.log(canSum(7, [5, 4, 3, 7])); // true
console.log(canSum(7, [2, 4])); // false
console.log(canSum(8, [2, 3, 5])); // true
console.log(canSum(300, [7, 14])); // false

*/