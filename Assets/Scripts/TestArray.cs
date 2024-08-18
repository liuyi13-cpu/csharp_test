using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class TestArray : ITest
{
    public void DoTest()
    {
        Test1();
        Test2();
    }
    
    /// <summary>
    /// 二维数组性能测试
    /// [] vs [,]
    /// 结论：一维数组性能更好点
    /// [DEBUG] 1560ms vs 1960ms
    /// </summary>
    private void Test1()
    {
        int rows = 1000;
        int cols = 1000;
        int iterations = 1000;

        // 一维数组
        int[] array1D = new int[rows * cols];
        Stopwatch sw1 = Stopwatch.StartNew();
        for (int iter = 0; iter < iterations; iter++)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array1D[i * cols + j] = i + j;
                }
            }
        }
        sw1.Stop();
        Debug.LogWarning($"1D array time: {sw1.ElapsedMilliseconds} ms");

        // 二维数组
        int[,] array2D = new int[rows, cols];
        Stopwatch sw2 = Stopwatch.StartNew();
        for (int iter = 0; iter < iterations; iter++)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array2D[i, j] = i + j;
                }
            }
        }
        sw2.Stop();
        Debug.LogWarning($"2D array time: {sw2.ElapsedMilliseconds} ms");
    }

    /// <summary>
    /// 数组字典遍历性能测试
    /// 结论：数组性能好  10倍
    /// 195ms vs 1728ms
    /// </summary>
    private void Test2()
    {
        // 1.数组
        int size = 1000000*100;
        int[] array = new int[size];
        // 初始化数组
        for (int i = 0; i < size; i++)
        {
            array[i] = i;
        }
        // 测量遍历数组的时间
        Stopwatch sw = Stopwatch.StartNew();
        long sum = 0;
        for (int i = 0; i < size; i++)
        {
            sum += array[i];
        }
        sw.Stop();
        Debug.LogWarning($"遍历数组耗时: {sw.ElapsedMilliseconds} ms");

        // 2.字典
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        // 初始化字典
        for (int i = 0; i < size; i++)
        {
            dictionary[i] = i;
        }
        // 测量遍历字典的时间
        Stopwatch sw2 = Stopwatch.StartNew();
        long sum2 = 0;
        foreach (var kvp in dictionary)
        {
            sum += kvp.Value;
        }
        sw2.Stop();
        Debug.LogWarning($"遍历字典耗时: {sw2.ElapsedMilliseconds} ms");
    }
}
