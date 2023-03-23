using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpDown : MonoBehaviour
{
    [SerializeField] Image _hpimage;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Hpdown(float value)
    {
        float min = 0;
        float max = 1;
        if (min > value) value = min;
        if (max < value) value = max;
        _hpimage.transform.localScale = new Vector3(value, 1, 1);
    }
}
