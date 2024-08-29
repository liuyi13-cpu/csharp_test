using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;


// 4个int > Rect
// 550 VS 1341
public class TestRect : ITest
{
    public void DoTest()
    {
        Test1(1, 2, 3, 4);
    }

    private void ProcessInts(int x, int y, int width, int height)
    {
        int area = width * height;
    }

    private void ProcessRect(in RectInt rect)
    {
        int area = rect.width * rect.height;
    }

    private void Test1(int x, int y, int w, int h)
    {
        const int iterations = 100000000;
        RectInt rect = new RectInt(1, 2, 3,4);
        Stopwatch stopwatch = new Stopwatch();

        // 测试传递4个int参数
        stopwatch.Start();
        for (int i = 0; i < iterations; i++)
        {
            ProcessInts(x, y, w, h);
        }
        stopwatch.Stop();
        Debug.LogWarning($"Passing 4 ints: {stopwatch.ElapsedMilliseconds} ms");

        // 测试传递ref Rectint参数
        stopwatch.Restart();
        for (int i = 0; i < iterations; i++)
        {
            ProcessRect(in rect);
        }
        stopwatch.Stop();
        Debug.LogWarning($"Passing ref Rectint: {stopwatch.ElapsedMilliseconds} ms");
    }
    
}
