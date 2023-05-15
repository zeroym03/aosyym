using UnityEngine;
using UnityEngine.UI;

public class ResultText: MonoBehaviour
{
    [SerializeField] Text text;
    void Start()
    { init(); }
    public void init()//무기정보 받아서 출력값 변경
    {
        text.text = GenericSinglngton<HeroUnitData>.Instance.name;
    }
}
