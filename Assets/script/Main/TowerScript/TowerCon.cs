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
        _dmg = GenericSinglngton<Hero>.Instans._Damages;// ���� ������ ���� �����ϵ���
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
//    //���� �ڵ� ������ ��
//    // ���� �ڵ带 ��ũ��Ʈ ���� ����� �տ� Ÿ�� active�� üũ�ؼ� �ǰ� ��ũ��Ʈ �ϸ�? triger�� ������ �� mono�ȹ����� ������ 
//    //������ �̰ɷ� �ϰ� Ÿ�� ��ũ��Ʈ ����? �̰� ����� ����̾���?
//    void removal()
//    {
//        _towerCon.gameObject.SetActive(false);
//    }
//}

