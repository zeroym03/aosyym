using UnityEngine;

public class Nexus : MonoBehaviour
{
    [SerializeField] TwinsTower twinsTower1;
    [SerializeField] TwinsTower twinsTower2;
    [SerializeField] GameObject endCanvas;
    int _towerHp = 200;
    public int Hp { get { return _towerHp; } set { _towerHp = value; } }
    int _dmg = 0;
    private void Start()
    {
        gameObject.SetActive(true);
        _dmg = GenericSinglngton<HeroUnitData>.Instance.Damages;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (twinsTower2.Hp <= 0 && twinsTower1.Hp <= 0) 
        {
            _towerHp -= _dmg;
            Debug.Log(_towerHp);
            if (_towerHp <= 0)
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
        Time.timeScale = 1f;
        endCanvas.SetActive(true);
    }
}
