using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSinglngton<T> where T : MonoBehaviour
{
    private static T _Instance;
    public static T Instans
    {
        get
        {
            if (_Instance == null)
            {
                GameObject temp = new GameObject();
                _Instance = temp.AddComponent<T>();
                Object.DontDestroyOnLoad(temp);
            }
            return _Instance;
        }
    }
}
