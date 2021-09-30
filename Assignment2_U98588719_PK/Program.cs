using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_Assignment_2_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] heights = { -5, 1, 5, 0, -7 };
            int max_height = LargestAltitude(heights);
            Console.WriteLine("Maximum altitude gained is {0}", max_height);
            Console.WriteLine();
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");
            Console.WriteLine();

            //Question3:
            Console.WriteLine("Question 3");
            string[] words1 = { "bella", "label", "roller" };
            List<string> commonWords = CommonChars(words1);
            Console.WriteLine("Common characters in all the strigs are:");
            for (int i = 0; i < commonWords.Count; i++)
            {
                Console.Write(commonWords[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            int[] arr1 = { 1, 2, 2, 1, 1, 3 };
            bool unq = UniqueOccurrences(arr1);
            if (unq)
                Console.WriteLine("Number of Occurences of each element are same");
            else
                Console.WriteLine("Number of Occurences of each element are not same");
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            List<List<string>> items = new List<List<string>>();
            items.Add(new List<string>() { "phone", "blue", "pixel" });
            items.Add(new List<string>() { "computer", "silver", "lenovo" });
            items.Add(new List<string>() { "phone", "gold", "iphone" });

            string ruleKey = "color";
            string ruleValue = "silver";

            int matches = CountMatches(items, ruleKey, ruleValue);
            Console.WriteLine("Number of matches for the given rule :{0}", matches);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:

            Console.WriteLine("Question 7:");
            string allowed = "ab";
            string[] words = { "ad", "bd", "aaab", "baa", "badab" };
            int count = CountConsistentStrings(allowed, words);
            Console.WriteLine("Number of Consistent strings are : {0}", count);
            Console.WriteLine(" ");
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8");
            int[] num1 = { 12, 28, 46, 32, 50 };
            int[] num2 = { 50, 12, 32, 46, 28 };
            int[] indexes = AnagramMappings(num1, num2);
            Console.WriteLine("Mapping of the elements are");
            for (int i = 0; i < indexes.Length; i++)
            {
                Console.Write(indexes[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            /*//Question 10:
            Console.WriteLine("Question 10");
            int[] arr10 = { 2, 3, 1, 2, 4, 3 };
            int target_subarray_sum = 7;
            int minLen = minSubArrayLen(target_subarray_sum, arr10);
            Console.WriteLine("Minimum length subarray with given sum is {0}", minLen);
            Console.WriteLine();
            */
        }

        /*
        Question 1:

        There is a biker going on a road trip. The road trip consists of n + 1 points at different altitudes. The biker starts his trip on point 0 with altitude equal 0.
        You are given an integer array gain of length n where gain[i] is the net gain in altitude between points i and i + 1  for all (0 <= i < n). Return the highest altitude of a point.
        Example 1:
        Input: gain = [-5,1,5,0,-7]
        Output: 1
        Explanation: The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.

        */

        public static int LargestAltitude(int[] gain)
        {
            try
            {
                //variable declarations
                int n = gain.Length;
                int cnt = 0, high = 0;

                if (n >= 1 && n <= 100)//constraint check 1 
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (gain[i] >= -100 && gain[i] <= 100) //constraint check 2 
                        {
                            cnt = cnt + gain[i];
                            if (cnt > high)
                            {
                                high = cnt;
                            }
                        }//constraint check 2 ends 
                    }
                }//constraint check 1 ends 
                return high;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:

        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search

        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2

        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1

        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4

        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                Array.Sort(nums); //sort input array 
                //variable decalartions
                int valmin = 0, valmax = nums.Length - 1;

                while (valmin <= valmax)
                {
                    int val = (valmin + valmax) / 2;//calculating the mid value 

                    if (target == nums[val])
                        return val;
                    else if (target < nums[val])
                        valmax = val - 1;
                    else if (target > nums[val])
                        valmin = val + 1;
                }
                return valmin;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 3
       
        Given an array words of strings made only from lowercase letters, return a list of all characters that show up in all strings in words (including duplicates).  For example, if a character occurs 3 times in all strings but not 4 times, you need to include that character three times in the final answer.
        You may return the answer in any order.
        Example 1:
        Input: ["bella","label","roller"]
        Output: ["e","l","l"]
        Example 2:
        Input: ["cool","lock","cook"]
        Output: ["c","o"]

        */

        public static List<string> CommonChars(string[] words)
        {
            try
            {
                List<string> commonwords = new List<string>();
                List<int[]> arr = new List<int[]>(words.Length);

                if (words.Length >= 1 && words.Length <= 100) //constraint check 1
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        arr.Add(new int[26]); //create array for all alphabets size to store each letter 

                        if (words[i].Length >= 1 && words[i].Length <= 100) //constraint check 2
                        {
                            foreach (var v in words[i].ToCharArray())
                            {
                                int inter = v - 'a';
                                arr[i][inter]++;
                            }
                        }//constraint check 2 ends
                    }
                    for (int j = 0; j < 26; j++)
                    {
                        //fins the min occurence of each word that is common 
                        int minoccur = int.MaxValue;
                        for (int k = 0; k < words.Length; k++)
                        {
                            minoccur = Math.Min(minoccur, arr[k][j]);
                        }

                        //add new string for min occurence of letter  
                        for (int m = 0; m < minoccur; m++)
                        {
                            int charAsInt = 'a' + j;
                            char val = (char)charAsInt;
                            commonwords.Add(val.ToString());
                        }
                    }
                }//constraint check 1 ends 
                return commonwords;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 4:

        Given an array of integers arr, write a function that returns true if and only if the number of occurrences of each value in the array is unique.

        Example 1:
        Input: arr = [1,2,2,1,1,3]
        Output: true
        Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.

        Example 2:
        Input: arr = [1,2]
        Output: false

         */

        public static bool UniqueOccurrences(int[] arr)
        {
            try
            {
                if (arr.Length >= 1 && arr.Length <= 1000) //constraint check 1 
                {
                    //create dictionary and check occurence 
                    var occur = new Dictionary<int, int>();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] >= -1000 && arr[i] <= 1000)//constraint check 2
                        {
                            if (occur.ContainsKey(arr[i]))
                                occur[arr[i]] = ++occur[arr[i]];
                            else
                                occur[arr[i]] = 1;
                        }//constraint check 2 ends 
                    }

                    int comp1 = occur.Values.Distinct().Count();
                    int comp2 = occur.Values.Count();
                    if (comp1 == comp2) //check if they contains unique/distinct values by counting elements in them
                        return true;
                    else
                        return false;
                }//constraint check 1 ends 
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 5:

        You are given an array items, where each items[i] = [type, color, name]  describes the type, color, and name of the ith item. You are also given a rule represented by two strings, ruleKey and ruleValue.
        The ith item is said to match the rule if one of the following is true:
        •	ruleKey == "type" and ruleValue == type.
        •	ruleKey == "color" and ruleValue == color.
        •	ruleKey == "name" and ruleValue == name.

        Return the number of items that match the given rule.

        Example 1:
        Input:  items = [["phone","blue","pixel"],["computer","silver","lenovo"],["phone","gold","iphone"]],  ruleKey = "color",  ruleValue = "silver".
        Output: 1
        Explanation: There is only one item matching the given rule, which is ["computer","silver","lenovo"].

        Example 2:
        Input: items = [["phone","blue","pixel"],["computer","silver","phone"],["phone","gold","iphone"]], ruleKey = "type",  ruleValue = "phone"
        Output: 2
        Explanation: There are only two items matching the given rule, which are ["phone","blue","pixel"]  and ["phone","gold","iphone"]. 

        Note that the item ["computer","silver","phone"] does not match.

        */

        public static int CountMatches(List<List<string>> items, string ruleKey, string ruleValue)
        {
            try
            {
                int count = 0; //variable dec
                if (items.Count >= 1 && items.Count <= 104) //constraint check 1
                {
                    if ((ruleKey.Length >= 1 && ruleKey.Length <= 10)
                        && (ruleValue.Length > 1 && ruleValue.Length <= 10)) //constraint check 2 
                    {
                        if (ruleKey == "type" || ruleKey == "color" || ruleKey == "name") //constraint check 3 
                        {
                            bool rulek, rulev;
                            //check if string rulekey and ruleValue containts lowercase letters 
                            rulek = ruleKey.Any(char.IsLower);
                            rulev = ruleValue.Any(char.IsLower);

                            if (rulek == true && rulev == true) //constraint check 4
                            {

                                foreach (var item in items) //check for matching values
                                {
                                    if (ruleKey == "type" && item[0] == ruleValue ||
                                        ruleKey == "color" && item[1] == ruleValue ||
                                        ruleKey == "name" && item[2] == ruleValue)
                                    {
                                        count++;
                                    }
                                }
                            }//constraint check 4 ends 
                        }//constraint check 3 ends
                    }//constraint check 2 ends 
                }//constraint check 1 ends 
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 6:
        
        Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers. Length.
        You may not use the same element twice, there will be only one solution for a given array.

        Note: Solve it in O(n) and O(1) space complexity.

        Hint: Use the fact that array is sorted in ascending order and there exists only one solution.
        Typically, in these cases it’s useful to use pointers tracking the two ends of the array.

        Example 1:
        Input: numbers = [2,7,11,15], target = 9
        Output: [1,2]
        Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

        Example 2:
        Input: numbers = [2,3,4], target = 6
        Output: [1,3]

        Example 3:
        Input: numbers = [-1,0], target = -1
        Output: [1,2]

        */

        public static void targetSum(int[] nums, int target)
        {
            try
            {
                //variable decarations 
                int[] res = new int[2];
                int i = 0, j = nums.Length - 1;
                int sum;

                if (nums.Length >= 2 && nums.Length <= 3 * 100000) //constraint check 1
                {
                    sum = nums[i] + nums[j]; //calculate sum to check with target

                    if (nums[i] >= -1000 && nums[i] <= 1000)//constraint check 2
                    {
                        Array.Sort(nums); //constraint check 3 

                        while (sum != target)
                        {
                            if (sum < target)
                                i++;
                            else
                                j--;

                            sum = nums[i] + nums[j];
                        }
                        //to print indices of two numbers
                        res[0] = i + 1;
                        res[1] = j + 1;
                        Console.Write("[" + String.Join(",", res) + "]");
                    }//constraint check 2 ends 
                } //constraint check 1 ends 
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 7:

        You are given a string allowed consisting of distinct characters and an array of strings words. A string is consistent if every character in words[i] appears in the string allowed.
        Return the number of consistent strings in the array words.

        Note: The algorithm should have run time complexity of O(n).
        Hint: Use Dictionaries. 

        Example 1:
        Input: allowed = "ab", words = ["ad","bd","aaab","baa","badab"]
        Output: 2
        Explanation: Strings "aaab" and "baa" are consistent since they only contain characters 'a' and 'b'. string “bd” is not consistent since ‘d’ is not in string allowed.

        Example 2:
        Input: allowed = "abc", words = ["a","b","c","ab","ac","bc","abc"]
        Output: 7
        Explanation: All strings are consistent.

        */
        public static int CountConsistentStrings(string allowed, string[] words)
        {
            try
            {
                Dictionary<int, int> mydict = new Dictionary<int, int>();

                if ((words.Length >= 1 && words.Length <= 100000)
                    && (allowed.Length >= 1 && allowed.Length <= 26)) //Constraint check 1 2 3 
                {
                    for (int i = 0; i < allowed.Length; i++) //Constraint check 4
                    {
                        for (int j = i + 1; j < allowed.Length; j++)
                        {
                            if (allowed[i] == allowed[j])
                                return 0;
                            else
                            {
                                //add all letters in allowed to dict
                                foreach (int letter in allowed)
                                {
                                    mydict.Add(letter, 0);
                                }
                                int count = 0, wordcount = 0;
                                //for all word in words string check the values from the dict 
                                foreach (var w in words)
                                {
                                    wordcount++;
                                    foreach (var k in w)
                                    {
                                        if (mydict.ContainsKey(k) == false)
                                        {
                                            count++;
                                            break;
                                        }
                                    }
                                }
                                return wordcount - count;
                            }
                        }
                    } //Constraint check 4 ends 
                }//Constraint check 1  2 3 ends 
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 8:

        You are given two integer arrays nums1 and nums2 where nums2 is an anagram of nums1. Both arrays may contain duplicates.

        Return an index mapping array mapping from nums1 to nums2 where mapping[i] = j indicates that  the ith element in nums1 appears in nums2 at index j. If there are multiple answers, return any of them.
        An array a is an anagram of array b if b is made by randomizing the order of the elements in a.

 
        Example 1:
        Input: nums1 = [12,28,46,32,50], nums2 = [50,12,32,46,28]
        Output: [1,4,3,2,0]
        Explanation: As mapping[0] = 1 because the 0th element of nums1 appears at nums2[1], and mapping[1] = 4 because the 1st element of nums1 appears at nums2[4], and so on.

        */
        public static int[] AnagramMappings(int[] nums1, int[] nums2)
        {
            try
            {
                int[] ans = new int[nums1.Length];

                if (nums1.Length >= 1 && nums1.Length <= 100 && nums1.Length == nums2.Length) //constraint check 1 & 2
                {
                    for (int i = 0; i < nums1.Length; i++)
                    {
                        if (nums1[i] >= 0 && nums1[i] <= 100000 && nums2[i] >= 0 && nums2[i] <= 100000)//constraint check 3
                        {
                            ans[i] = Array.IndexOf(nums2, nums1[i]);
                        }//constraint check 3 ends 
                    }
                }//constraint check 1 & 2 ends
                return ans;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
        
        Question 9:

        Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

        Note: Time Complexity should be O(n).
        Hint: Keep track of maximum sum as you move forward.
        Example 1:
        Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        Output: 6
        Explanation: [4,-1,2,1] has the largest sum = 6.
        Example 2:
        Input: nums = [1]
        Output: 1

        */
        public static int MaximumSum(int[] arr)
        {
            try
            {
                //variable decalation
                int sum = 0;
                int maxsum = int.MinValue;

                if (arr.Length >= 1 && arr.Length <= 30000)//Constraint check 1
                {

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] >= -100000 && arr[i] <= 100000)//Constraint check 2
                        {
                            sum = sum + arr[i];
                            maxsum = Math.Max(sum, maxsum);
                            if (sum < 0)
                                sum = 0;
                        }//Constraint check 2 ends 
                    }
                }//Constraint check 1 ends 
                return maxsum;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}