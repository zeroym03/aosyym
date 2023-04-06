using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    [SerializeField] Transform _tranhero;
    [SerializeField] Transform _trancamera;

    void Update()
    {
        tset();

    }
    void tset()
    {
        Debug.Log("asd") ;
        _trancamera.position = _tranhero.position + new Vector3(0,25,0);
    }
}
