using UnityEngine;
using UnityEngine.UI;

public class ResultText: MonoBehaviour
{
    [SerializeField] Text text;
    HeroUnitData _heroUnitData = new HeroUnitData();
    void Start()
    { init(); }
    public void init()//무기정보 받아서 출력값 변경
    {
        text.text = _heroUnitData.Name;
    }
}
