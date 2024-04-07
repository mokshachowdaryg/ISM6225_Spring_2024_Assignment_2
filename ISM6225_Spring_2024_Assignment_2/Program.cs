/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Handle the edge case where the input array is empty
                if (nums.Length == 0) return 0;
                
                // Initialize a variable 'k' to keep track of the unique elements count
                int k = 1;

                // Iterate through the array starting from the second element
                for (int i = 1; i < nums.Length; i++)
                {
                    // Check if the current element is different from the previous element
                    if (nums[i] != nums[i - 1])
                    {
                        // If the current element is unique, copy it to the position indicated by 'k'
                        nums[k] = nums[i];
                        // Increment 'k' to move to the next position for the unique element
                        k++;
                    }
                }
                // Return the count of unique elements
                return k;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Initialize a variable 'nonZeroIndex' to keep track of the position for the next non-zero element
                int nonZeroIndex = 0;
                // Iterate through the input array
                for (int i = 0; i < nums.Length; i++)
                {
                    // Check if the current element is non-zero
                    if (nums[i] != 0)
                    {
                        // If the current element is non-zero, copy it to the position indicated by 'nonZeroIndex'
                        nums[nonZeroIndex] = nums[i];
                        // Increment 'nonZeroIndex' to move to the next position for the next non-zero element
                        nonZeroIndex++;
                    }
                }
                // After the first loop, all the non-zero elements have been moved to the front of the array
                // Now, set the remaining elements (from 'nonZeroIndex' to the end of the array) to 0
                for (int i = nonZeroIndex; i < nums.Length; i++)
                {
                    nums[i] = 0;
                }
                // Return the modified array as a List<int>
                return nums.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Create a list to store the triplets that sum up to 0
                IList<IList<int>> result = new List<IList<int>>();
                // Sort the input array in ascending order
                Array.Sort(nums);
                // Iterate through the array from the first element to the second-to-last element
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip the current element if it is a duplicate of the previous element
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;
                    // Set the left and right pointers to the elements after the current element
                    int left = i + 1, right = nums.Length - 1;
                    // Use the two-pointer approach to find triplets that sum up to 0
                    while (left < right)
                    {
                        // Calculate the sum of the current triplet
                        int sum = nums[i] + nums[left] + nums[right];
                        // If the sum is 0, add the triplet to the result list and skip any duplicate elements
                        if (sum == 0)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip any duplicate left and right elements
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;
                            // Move the left and right pointers inward
                            left++;
                            right--;
                        }
                        // If the sum is less than 0, move the left pointer to the right
                        else if (sum < 0)
                            left++;
                        // If the sum is greater than 0, move the right pointer to the left
                        else
                            right--;
                    }
                }

                // Return the list of triplets
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Initialize variables to keep track of the maximum number of consecutive ones
                // and the current count of consecutive ones
                int maxOnes = 0;
                int currentOnes = 0;
                // Iterate through the input array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is 1, increment the current count of consecutive ones
                    if (nums[i] == 1)
                    {
                        currentOnes++;
                        // Update the maximum count of consecutive ones if the current count is greater
                        maxOnes = Math.Max(maxOnes, currentOnes);
                    }
                    // If the current element is 0, reset the current count of consecutive ones
                    else
                    {
                        currentOnes = 0;
                    }
                }
                // Return the maximum count of consecutive ones
                return maxOnes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Initialize a variable 'decimal_db' to store the decimal equivalent of the binary number
                int decimal_db = 0;
                // Initialize a variable 'base_value' to keep track of the current place value (1, 2, 4, 8, ...)
                int base_value = 1;
                // Iterate through the binary number until it becomes 0
                while (binary > 0)
                {
                    // Get the last digit of the binary number
                    int remainder = binary % 10;
                    // Add the current digit multiplied by the corresponding base value to the 'decimal_db' variable
                    decimal_db += remainder * base_value;
                    // Update the 'base_value' by multiplying it by 2 (since each digit in binary represents a power of 2)
                    base_value *= 2;
                    // Remove the last digit from the binary number by dividing it by 10
                    binary /= 10;
                }
                // Return the final decimal equivalent
                return decimal_db;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // If the input array has less than 2 elements, the maximum gap is 0
                if (nums.Length < 2)
                    return 0;
                // Find the maximum and minimum values in the input array
                int max_val = nums.Max();
                int min_val = nums.Min();
                // Calculate the bucket size based on the range of values and the number of elements in the array
                int bucket_size = Math.Max(1, (max_val - min_val) / (nums.Length - 1));
                int bucket_count = (max_val - min_val) / bucket_size + 1;
                // Initialize arrays to store the minimum and maximum values in each bucket
                int[] bucket_min = new int[bucket_count];
                int[] bucket_max = new int[bucket_count];
                // Initialize the bucket_min and bucket_max arrays with the maximum and minimum possible values, respectively
                for (int i = 0; i < bucket_count; i++)
                {
                    bucket_min[i] = int.MaxValue;
                    bucket_max[i] = int.MinValue;
                }
                // Iterate through the input array and assign each element to its respective bucket
                    foreach (int num in nums)
                {
                    int bucket_index = (num - min_val) / bucket_size;
                    bucket_min[bucket_index] = Math.Min(bucket_min[bucket_index], num);
                    bucket_max[bucket_index] = Math.Max(bucket_max[bucket_index], num);
                }
                // Find the maximum gap between the maximum values of adjacent non-empty buckets
                int max_gap = 0;
                int prev_max = min_val;

                for (int i = 0; i < bucket_count; i++)
                {
                    // Skip empty buckets
                    if (bucket_min[i] == int.MaxValue && bucket_max[i] == int.MinValue)
                        continue;

                    max_gap = Math.Max(max_gap, bucket_min[i] - prev_max);
                    prev_max = bucket_max[i];
                }
                // Return the maximum gap
                return max_gap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Sort the array in descending order
                Array.Sort(nums, (a, b) => b.CompareTo(a));
                // Iterate through the array from the first element to the third-to-last element
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Check if the current element, the next element, and the next-to-next element
                    // can form a valid triangle (i.e., the sum of the two smaller sides is greater
                    // than the largest side)
                    if (nums[i] < nums[i + 1] + nums[i + 2])
                    {
                        // If a valid triangle is found, return the sum of the three sides
                        return nums[i] + nums[i + 1] + nums[i + 2];
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Keep removing the leftmost occurrence of the 'part' substring from 's' until there are no more occurrences
                while (s.Contains(part))
                {
                    // Find the index of the leftmost occurrence of the 'part' substring
                    int index = s.IndexOf(part);
                    // Remove the 'part' substring from 's' starting from the found index
                    s = s.Substring(0, index) + s.Substring(index + part.Length);
                }
                // Return the modified string 's' after removing all occurrences of 'part'
                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}