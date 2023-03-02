using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
enum fox
{
    move,
    attack,
    die,
}
public class Orangefox : MonoBehaviour
{
    [SerializeField] Transform _hero;
    [SerializeField] GameObject _rotate;
    [SerializeField] float _speed;
    [SerializeField] float _hp;
    [SerializeField] int _attack;
    [SerializeField] Animator _ani;
    Vector3 v3 = Vector3.zero;
    private void Update()
    {
        v3 += (Vector3.forward).normalized * Time.deltaTime * _speed;
        _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));// 가는 방향으로 보는 방향 전환시켜야함
        transform.Translate((_hero.position - transform.position).normalized * Time.deltaTime * _speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        {
            if (collision.gameObject.name == "Hero")
            {
                // collision.gameObject.GetComponent<Hero>().Hitted();
                _hp -= 5;
                Debug.Log(_hp);
            }
        }
    }

}
