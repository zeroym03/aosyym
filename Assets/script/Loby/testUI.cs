using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testUI : MonoBehaviour
{
    [SerializeField] Text text;
    void Start()
    { init(); }
    public void init()//�������� �޾Ƽ� ��°� ����
    {
        text.text = GenericSinglngton<HeroData>.Instans._name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
