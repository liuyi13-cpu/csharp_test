using System.Collections.Generic;
using UnityEngine;

public class CsharpTest : MonoBehaviour
{
    private void Start()
    {
        var list = new List<ITest>();
        list.Add(new TestRect());
        list.Add(new TestArray());
        list.Add(new TestIn());
        list.Add(new TestEqual());
        list.Add(new TestStruct());

        foreach (var test in list)
        {
            test.DoTest();
        }
    }
}
