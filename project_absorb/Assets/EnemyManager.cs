using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static List<List<int>>
       combinationSum(List<int> arr, int sum)
    {
        List<List<int>> ans
            = new List<List<int>>();
        List<int> temp = new List<int>();

        // first do hashing since hashset does not always
        // sort
        //  removing the duplicates using HashSet and
        // Sorting the List

        HashSet<int> set = new HashSet<int>(arr);
        arr.Clear();
        arr.AddRange(set);
        arr.Sort();

        findNumbers(ans, arr, sum, 0, temp);
        return ans;
    }

    static void
    findNumbers(List<List<int>> ans,
                List<int> arr, int sum, int index,
                List<int> temp)
    {

        if (sum == 0)
        {

            // Adding deep copy of list to ans

            ans.Add(new List<int>(temp));
            return;
        }

        for (int i = index; i < arr.Count; i++)
        {

            // checking that sum does not become negative

            if ((sum - arr[i]) >= 0)
            {

                // Adding element which can contribute to
                // sum

                temp.Add(arr[i]);

                findNumbers(ans, arr, sum - arr[i], i,
                            temp);

                // removing element from list (backtracking)
                temp.Remove(arr[i]);
            }
        }
    }

    private void Start()
    {
        List<int> arr = new List<int>();

        arr.Add(1);
        arr.Add(2);
        arr.Add(3);
        arr.Add(4);

        int sum = 4;

        List<List<int>> ans
            = combinationSum(arr, sum);

        // If result is empty, then
        if (ans.Count == 0)
        {
           // System.Diagnostics.Debug.WriteLine("Empty");
            return;
        }

        Debug.Log(ans[0][0] + " ");
        // print all combinations stored in ans

       /* for (int i = 0; i < ans.Count; i++)
        {

           // Debug.Log("(");
            for (int j = 0; j < ans[i].Count; j++)
            {
                Debug.Log(ans[i][j] + " ");
            }
           // Debug.Log(") ");
        }*/

    }
}
