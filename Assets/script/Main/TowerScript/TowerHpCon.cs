using UnityEngine;
using static MinianCon;

public class TowerHpCon : MonoBehaviour//�̸� ������ �ٲٱ�
{
    [SerializeField] ETeamColor towerColor;
    public ETeamColor TowerColor { get { return towerColor; } }
    [SerializeField] TowerHpCon beforetower;
    int _Hp =200;
    public int Hp { get { return _Hp; } set { _Hp = value; } }
    int _dmg = 0;
    //���� �ڵ� ������ ��
    private void Start()
    {gameObject.SetActive(true);}
    private void OnTriggerEnter(Collider other)
    {
        _dmg = GenericSinglngton<HeroUnitData>.Instance.Damages;
        if (GenericSinglngton<AllDataSingletun>.Instance._eHeroTeamColor == towerColor)
        {
            Debug.Log("�������Դϴ�");
        }
        else if (beforetower == null || beforetower._Hp <= 0)
        {
            _Hp -= _dmg;
            Debug.Log(_Hp);
            if (_Hp <= 0)
            {
                removal();
            }
        }
        else
        {
            Debug.Log("�տ���ž�� ����ֽ��ϴ�");
        }
    }
    void removal() {Destroy(gameObject);}
}
