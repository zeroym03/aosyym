using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerCon : MonoBehaviour
{
    public int _dmg = 0;
    public int _Hp = 20;
    // Start is called before the first frame update
    void Start()
    {
        _dmg = GenericSinglngton<Hero>.Instans._Damages;// 영웅 데이터 따로 보관하도록
        //ChangeUnitState();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
//public class TowerConState
//{
//   protected TowerCon _towerCon;
//    public virtual void OnEnter(TowerCon towerCon)
//    {
//        _towerCon = towerCon;
//    }
//    public virtual void TowerAction()
//    {
        
//    }
//}
//public class Startower : TowerConState
//{
//    public override void OnEnter(TowerCon towerCon)
//    {
//     base.OnEnter(towerCon);
//    }
//    public override void TowerAction()
//    {
//        _towerCon._Hp -= _towerCon._dmg;
//        Debug.Log(_towerCon._Hp);
//        if (_towerCon._Hp <= 0)
//        {
//            removal();
//        }
//    }
//    //공격 코드 만들어야 함
//    // 공격 코드를 스크립트 따로 만들고 앞에 타워 active만 체크해서 피격 스크립트 하면? triger가 문제네 흠 mono안받으면 못쓰고 
//    //관리만 이걸로 하고 타워 스크립트 따로? 이거 말고는 방법이없다?
//    void removal()
//    {
//        _towerCon.gameObject.SetActive(false);
//    }
//}

