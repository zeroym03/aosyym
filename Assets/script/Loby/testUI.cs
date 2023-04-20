using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testUI : MonoBehaviour
{
    [SerializeField] Text text;
    void Start()
    { init(); }
    public void init()//무기정보 받아서 출력값 변경
    {
        text.text = GenericSinglngton<HeroData>.Instans._name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
