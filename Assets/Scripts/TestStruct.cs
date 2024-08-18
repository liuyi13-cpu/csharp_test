using Unity.Collections;
using UnityEngine;

public class TestStruct : ITest
{
    public void DoTest()
    {
        Test1();
    }
    
    private Color[] _colors = new Color[1];
    private NativeArray<Color> _colors1 = new NativeArray<Color>();
    private void Test1()
    {
        _colors[0].r = 100;
        _colors[0].g = 200;
        _colors[0].b = 300;

        _colors[0] = new Color(100, 200, 300);
        var color = _colors[0];
        color.r = 1000;

        // _colors1[0].r = 100;
        
    }
}
