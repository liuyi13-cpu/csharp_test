using UnityEngine;

public class TestEqual : ITest
{
    class Mono1
    {
        // public static bool operator ==(Mono1 x,Object y)
        // {
        //     return x.Equals(y);
        // }
        // public static bool operator !=(Mono1 x, Object y)
        // {
        //     return !(x == y);
        // }
        
        public static bool operator ==(Mono1 x, object y)
        {
            return x.Equals(y);
        }
        public static bool operator !=(Mono1 x, object y)
        {
            return !(x == y);
        }
    }
    
    public void DoTest()
    {
        Test1();
    }

    public TestEqualMono a;
    private Mono1 b = new Mono1();
    
    /// <summary>
    /// ReferenceEquals 不会调用子类的重载方法==    [objA == objB] object类型的== 
    /// </summary>
    private void Test1()
    {
        a = Object.FindObjectOfType<TestEqualMono>();
        
        Debug.Log(a == null);       // 触发Object的重载 null会转换成Object?
        Debug.Log(a == (object)null);
        Debug.Log(a == 1);          // 触发object的重载
        Debug.Log(a == 1.0);        // 触发object的重载

        object a1 = a;
        Debug.Log(a1 == null);      // Object 赋值给object后 使用 == 也不会触发子类的重载方法==
        
        Debug.Log(ReferenceEquals(a, null));        
        
        
        
        Debug.Log(b == null);      // null会优先适配Object，然后object 
        Debug.Log(ReferenceEquals(b, null));
    }
}
