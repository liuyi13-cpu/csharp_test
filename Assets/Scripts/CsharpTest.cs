using System.Collections.Generic;
using UnityEngine;

public class CsharpTest : MonoBehaviour
{
    private void Start()
    {
        var list = new List<ITest>();
        list.Add(new TestIn());
        list.Add(new TestEqual());

        foreach (var test in list)
        {
            test.DoTest();
        }
    }
}
