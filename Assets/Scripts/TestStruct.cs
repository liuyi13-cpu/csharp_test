using Unity.Collections;
using UnityEngine;

public class TestStruct : ITest
{
    public void DoTest()
    {
        Test1();
        Test2();
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
    
    public struct ChunkData1
    {
        public ushort[] data;
        public int x;
        public int y;
    }
    
    public class ChunkData2
    {
        public ushort[] data;
        public int x;
        public int y;
    }
    
    public class C1
    {
        // 2.类成员变量时
        // 堆上分配，内联分配在C1。C1gc释放时候，一起释放，不直接参与gc
        // 性能要好点
        public ChunkData1 Data1;
        // 堆上分配，参与gc
        public ChunkData2 Data2;
        
        // 3.类成员变量数组时
        // 内联分配，开销更低
        // 数组元素是值类型的真正实例，具有更好的引用局部性
        public ChunkData1[] DataArray1;
        public ChunkData2[] DataArray2;
        
        // 4.Struct转换时需要注意装修拆箱
        
        // 5.大型印尼用类型的赋值操作消耗低
    }

    /// <summary>
    /// struct vs class
    /// https://learn.microsoft.com/zh-cn/dotnet/standard/design-guidelines/choosing-between-class-and-struct
    /// </summary>
    private void Test2()
    {
        // 1.临时变量
        // 栈上分配，出栈销毁，不参与gc
        ChunkData1 Data1 = new ChunkData1();
        // 堆上分配，参与gc
        ChunkData2 Data2 = new ChunkData2();
    }
}
