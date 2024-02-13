using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = Regex.Match("abc8xyzfdsa", "((?<One>abc)\\d+)?(?<Two>xyz)(.*)", RegexOptions.RightToLeft);
            
            int index = 0;
            // foreach (var group in results.Groups) // .NET 7
            foreach (var group in results.Groups.Cast<Group>()) // .NET 4.8
            {
                Console.WriteLine($"I:{index} N:{group.Name} V:{group.Value}");
                index++;
            }
        }
    }
}
