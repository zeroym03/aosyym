using UnityEngine;
using UnityEngine.UI;

public class ResultText: MonoBehaviour
{
    [SerializeField] Text text;
    void Start()
    { init(); }
    public void init()//�������� �޾Ƽ� ��°� ����
    {
        text.text = GenericSinglngton<HeroUnitData>.Instance.name;
    }
}
