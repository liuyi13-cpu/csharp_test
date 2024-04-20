using UnityEngine;

/// <summary>
/// 子类Awake方法会覆盖基类
/// </summary>
public class TestEqualMonoSub : TestEqualMono
{
    private void Awake()
    {
        Debug.Log("TestEqualMonoSub TestEqualMono");
    }

    private new void Start()
    {
        base.Start();
        Debug.Log("TestEqualMonoSub TestEqualMono");
    }
}


