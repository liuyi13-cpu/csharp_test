using UnityEngine;

public class TestIn : ITest
{
    struct MyStruct
    {
        public int count;
        public MyStruct(int i)
        {
            count = i;
        }
    }

    class MyClass
    {
        public int count;
        public MyClass(int i)
        {
            count = i;
        }
    }

    public void Test()
    {
        TestIn1();
        TestRef();
        TestOut();
    }

    /// <summary>
    /// in关键字测试
    /// https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/in-parameter-modifier
    /// </summary>
    private void TestIn1()
    {
        unsafe
        {
            Debug.LogWarning($"START TestIn1");
            
            var count = 10;
            var p = &count;
            Debug.Log($"Int {(int)p}");
            
            var str = new MyStruct(10);
            var p1 = &str;
            Debug.Log($"MyStruct {(int)p1}");
            
            var cls = new MyClass(10);
            Debug.Log($"MyClass {cls.GetHashCode()}");
            _TestIn1(count, str, cls);
            
            Debug.Log($"MyClass {cls.count}");
            Debug.Log($"MyClass {cls.GetHashCode()}");
        }
    }
    
    private void _TestIn1(in int count, in MyStruct str, in MyClass cls)
    {
        // count = 10;              // in不能被赋值修改
        Debug.Log($"{count} count");

        // str = new MyStruct();
        // str.count = 10;          // struct成员变量也不能修改
        Debug.Log($"MyStruct {str}");
        
        
        // cls = new MyClass();
        cls.count = 99;             // in修饰的class成员变量可以修改
    }
    
    /// <summary>
    /// ref关键字测试
    /// </summary>
    private void TestRef()
    {
        Debug.LogWarning($"START TestRef");

        unsafe
        {
            var count = 10;
            var p = &count;
            Debug.Log($"Int {(int)p}");
            
            var str = new MyStruct(10);
            var p1 = &str;
            Debug.Log($"MyStruct {(int)p1}");
            
            var cls = new MyClass(10);
            Debug.Log($"MyClass {cls.GetHashCode()}");
            
            _TestRef(ref count, ref str, ref cls);
            
            Debug.Log($"count {count}");
            Debug.Log($"MyStruct {str.count}");
            Debug.Log($"MyClass {cls.count}");
            Debug.Log($"MyClass {cls.GetHashCode()}");
        }
    }    
    
    private void _TestRef(ref int count, ref MyStruct str, ref MyClass cls)
    {
        count = 99;
        str.count = 99;
        cls.count = 99;
    }
    
    /// <summary>
    /// out关键字测试
    /// </summary>
    private void TestOut()
    {
        Debug.LogWarning($"START TestOut");

        unsafe
        {
            var count = 10;
            var p = &count;
            Debug.Log($"Int {(int)p}");
            
            var str = new MyStruct(10);
            var p1 = &str;
            Debug.Log($"MyStruct {(int)p1}");
            
            var cls = new MyClass(10);
            Debug.Log($"MyClass {cls.GetHashCode()}");
            
            _TestOut(out count, out str, out cls);
            
            Debug.Log($"count {count}");
            Debug.Log($"MyStruct {str.count}");
            Debug.Log($"MyClass {cls.count}");
            Debug.Log($"MyClass {cls.GetHashCode()}");
        }
    }    
    
    private void _TestOut(out int count, out MyStruct str, out MyClass cls)
    {
        count = 99;
        str.count = 99;
        
        cls = new MyClass(99);
    }
}
