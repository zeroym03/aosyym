using UnityEngine;
using UnityEngine.UI;

public class ResultText: MonoBehaviour
{
    [SerializeField] Text[] text;//1���ݷ�,0�̸�
    HeroUnitData _heroUnitData ;
    void Start()
    {
        init();
        TextSet(_heroUnitData);
    }
    public void init()//�������� �޾Ƽ� ��°� ����
    {
        _heroUnitData = GenericSinglngton<HeroUnitData>.Instance;
    }
    public void TextSet(HeroUnitData heroUnitData)
    {
        text[0].text = "�̸�:" + heroUnitData.Name.ToString();
        text[1].text = "���ݷ�:" + heroUnitData.Damages.ToString();
    }
}
