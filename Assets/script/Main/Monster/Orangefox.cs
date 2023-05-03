using UnityEngine;
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
        Vector3 Loocdir = _hero.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(Loocdir.x, 0, Loocdir.z));
        transform.position = Vector3.MoveTowards(transform.position, _hero.position, Time.deltaTime * _speed);
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
