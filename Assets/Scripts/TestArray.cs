using System.Diagnostics;
using Debug = UnityEngine.Debug;

/// <summary>
/// 二维数组性能测试
/// [] vs [,]
/// 结论：一维数组性能更好点
/// [DEBUG] 1560ms vs 1960ms
/// </summary>
public class TestArray : ITest
{
    public void DoTest()
    {
        Test1();
    }
    
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
}
