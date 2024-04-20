using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class TestEqualMono : MonoBehaviour
{
    public int inta;
    
    public static bool operator ==(TestEqualMono x, Object y)
    {
        return x.Equals(y);
    }

    public static bool operator !=(TestEqualMono x, Object y) => !(x == y);
        
    public static bool operator ==(TestEqualMono x, object y)
    {
        return x.Equals(y);
    }

    public static bool operator !=(TestEqualMono x, object y)
    {
        return !(x == y);
    }   
    
    public static bool operator ==(TestEqualMono x, int y)
    {
        return x.Equals(y);
    }

    public static bool operator !=(TestEqualMono x, int y)
    {
        return !(x == y);
    }

    private void Awake()
    {
        Debug.Log("Awake TestEqualMono");
    }

    protected void Start()
    {
        Debug.Log("Start TestEqualMono");
    }
}


