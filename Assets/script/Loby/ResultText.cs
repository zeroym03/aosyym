using UnityEngine;
using UnityEngine.UI;

public class ResultText: MonoBehaviour
{
    [SerializeField] Text text;
    HeroUnitData _heroUnitData;
    void Start()
    { init(); }
    public void init()//�������� �޾Ƽ� ��°� ����
    {
        text.text = _heroUnitData.Name;
    }
}
