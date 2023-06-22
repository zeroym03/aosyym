using UnityEngine;
using UnityEngine.UI;

public class ResultText: MonoBehaviour
{
    [SerializeField] Text[] text;//1공격력,0이름
    HeroUnitData _heroUnitData ;
    void Start()
    {
        init();
        TextSet(_heroUnitData);
    }
    public void init()//무기정보 받아서 출력값 변경
    {
        _heroUnitData = GenericSinglngton<HeroUnitData>.Instance;
    }
    public void TextSet(HeroUnitData heroUnitData)
    {
        text[0].text = "이름:" + heroUnitData.Name.ToString();
        text[1].text = "공격력:" + heroUnitData.Damages.ToString();
    }
}
