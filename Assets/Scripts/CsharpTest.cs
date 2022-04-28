using System.Collections.Generic;
using UnityEngine;

public class CsharpTest : MonoBehaviour
{
    void Start()
    {
        var list = new List<ITest>();
        list.Add(new TestIn());
        foreach (var test in list)
        {
            test.Test();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
