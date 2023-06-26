using UnityEngine;

public class TowerHpCon : MonoBehaviour//이름 제데로 바꾸기
{
    [SerializeField] ETeamColor towerColor;
    public ETeamColor TowerColor { get { return towerColor; } }
    [SerializeField] TowerHpCon beforetower;
    float _Hp =200;
    public float Hp { get { return _Hp; } set { _Hp = value; } }
    float _dmg = 0;
    //공격 코드 만들어야 함
    private void Start()
    {gameObject.SetActive(true);}
    private void Update()
    {
            if (_Hp <= 0) removal();
    }
    private void OnTriggerEnter(Collider other)
    {
        _dmg = GenericSinglngton<HeroUnitData>.Instance.Damages;
        if (GenericSinglngton<AllDataSingletun>.Instance._eHeroTeamColor == towerColor)
        {
        }
        else if (beforetower == null || beforetower._Hp <= 0)
        {
            _Hp -= _dmg;
        }
        else
        {
            Debug.Log("앞에포탑이 살아있습니다");
        }
    }
    void removal() {Destroy(gameObject);}
}
