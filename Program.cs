namespace Week3Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PalindromePrompt();
            SumDigitsInString("L0r3m.1p5um");
            int[] result = TwoSum([2, 11, 7, 15], 9);
            if (result == null)
            {
                Console.WriteLine("There are no two sums that equal target.");
                return;
            }
            Console.WriteLine($"The numbers at these indexes equal the total: [{String.Join(",", result)}]");
            string input = "ABFCACDB";
            int length = StringReplace(input);
            Console.WriteLine($"The resulting length of the string: {input} is: {length}");
        }

        static void PalindromePrompt()
        {
            Console.WriteLine("Enter a word and I'll check if it is a palindrome");
            string word = Console.ReadLine()?.Trim();
            if (String.IsNullOrWhiteSpace(word))
            {
                Console.WriteLine("input cannot be empty or whitespace.");
                return;
            }
            Console.WriteLine(IsPalindrome(word)
                ? $"{word} is a Palindrome"
                : $"{word} is not a Palindrome");
        }
        static bool IsPalindrome(string input)
        {
            int l = 0;
            int r = input.Length - 1;

            while (l < r) 
            {
                if (char.ToLower(input[l]) == char.ToLower(input[r]))
                {
                    l++;
                    r--;
                } 
                else
                {
                    return false;
                }
            }
            return true;
        }

        static void SumDigitsInString(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    sum += input[i] - '0';
                }
            }
            Console.WriteLine($"Total sum for \"{input}\" is : {sum}");
        }

        static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numMap = new();

            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (numMap.ContainsKey(diff))
                {
                    return [numMap[diff], i];
                }
                numMap[nums[i]] = i;
            }

            return [];
        }
        
        static int StringReplace(string s)
        {
            string curr = s;
            string prev = s;

            while (true)
            {
                curr = curr.Replace("AB", "").Replace("CD", "");
                if (curr == prev)
                {
                    break;
                }
                prev = curr;

            }
            return curr.Length;
        }
    }
}
