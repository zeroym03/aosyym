using UnityEngine;
public class TowerHpCon : MonoBehaviour//이름 제데로 바꾸기
{
    [SerializeField] TowerHpCon beforetower;
    int _Hp =200;
    public int Hp { get { return _Hp; } set { _Hp = value; } }
    int _dmg = 0;
    //공격 코드 만들어야 함
    private void Start()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        _dmg = GenericSinglngton<HeroUnitData>.Instance.Damages;
        if (beforetower == null || beforetower._Hp <= 0)
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
            Debug.Log("앞에포탑이 살아있습니다");
        }
    }
    void removal()
    {
        gameObject.SetActive(false);
    }
}
