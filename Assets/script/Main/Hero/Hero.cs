using UnityEngine;
using UnityEngine.AI;
enum heromove
{
    Idle,
    move,//우킬릭
    w,//좌클릭
    die,
    remove,
    attack,
    a,
}
public class Hero : MonoBehaviour
{
    [SerializeField] GameoverUI _gameoverUI;
    [SerializeField] HpDown _hpimage;
    HeroUnitData heroUnitData = new HeroUnitData();
    Color _heroColor;
    int _hpdown = 5;//임시 피해변수
    int _maxHP = 0;
    private void Awake()
    {
        HeroAwakeData();
        HeroStartTrans();
    }
    void HeroAwakeData()
    {
        heroUnitData._HeroAni = GetComponentInChildren<Animator>();
        heroUnitData._HeroAgent = GetComponent<NavMeshAgent>();
        heroUnitData._HeroSword = GetComponentInChildren<BoxCollider>();
        _heroColor = GetComponentInChildren<SkinnedMeshRenderer>().material.color;
        _maxHP = heroUnitData.hp;
    }
    private void Start()
    {        HeroDataReset();    }
    void Update()
    {
        if (heroUnitData.hit == false && heroUnitData.move == true) Hitted();  //연속피해 방지
        HittedColer();
       if (heroUnitData.attack == false) Attack();
        if (heroUnitData.move == true && heroUnitData.attack == false)
        {
            MouseClick();
        }
        if (heroUnitData.move == false)
        { GameOver(); ReMove(); }
        attacktimeCon();
        heroUnitData._herotransform = transform;
    }
    void MouseClick()//move
    {
        if (Input.GetMouseButtonDown(0))//선택
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                heroUnitData._HeroAgent.SetDestination(hit.point);
                Debug.Log(heroUnitData._HeroAgent.destination);
            }
        }
        if (Vector3.Distance(gameObject.transform.position, heroUnitData._HeroAgent.destination) >= 0.3f)// 현위치 - 목적이 계산
        {
            heroUnitData._HeroAni.SetInteger("hero", (int)heromove.move);
        }
        else
        {
            heroUnitData._HeroAni.SetInteger("hero", (int)heromove.Idle);
        }
    }
    public void Attack()//attack
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            heroUnitData.attack = true;
            heroUnitData._HeroAni.SetTrigger("Attack");
            heroUnitData._HeroSword.enabled = true;
            DonMove();
        }
        
    }
    void EndAttack()//attack
    {
        if (heroUnitData.attacktime > 0.5f)
        {
            heroUnitData.attack = false;
            heroUnitData._HeroSword.enabled = false;
            heroUnitData.attacktime = 0f;
        }
    }
    public void Hitted()//hitted
    {
        if (Input.GetKeyDown(KeyCode.M) /*_hp >= _hehp1*/)
        {
            heroUnitData.hp -= _hpdown;
            heroUnitData.hit = true;
            _hpimage.Hpdown((float)heroUnitData.hp / _maxHP);
            Debug.Log("받은피해" + _hpdown + "현재체력" + heroUnitData.hp);
        }

        if (heroUnitData.hp <= 0)
        {
            Die();
            DonMove();
        }
    }
    public void HittedColer()//hitted
    {
        if (heroUnitData.hit == true)
        {
            heroUnitData.cortimer += Time.deltaTime;
            GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
            if (heroUnitData.cortimer > 0.5f)
            {
                GetComponentInChildren<SkinnedMeshRenderer>().material.color = _heroColor;
                heroUnitData.cortimer = 0f;
                heroUnitData.hit = false;
            }
        }
    }
    public void Die()//die 
    {
        heroUnitData._HeroAni.SetInteger("hero", (int)heromove.die);
        heroUnitData.move = false;
    }
    public void GameOver()
    {
        if (_gameoverUI.gameObject.active == false) { _gameoverUI.gameObject.SetActive(true);}
        _gameoverUI.timechange(heroUnitData.dietimer);
    }
    public void ReMove()//die
    {
        heroUnitData.dietimer -= Time.deltaTime;
        if (heroUnitData.dietimer <= 0f)
        {
       
            heroUnitData._HeroAni.SetInteger("hero", (int)heromove.a);
            heroUnitData._HeroAni.SetTrigger("Remove");
            heroUnitData.dietimer = 5f;
            HeroDataReset();
        }
    }
    public void DonMove()//캐릭터
    {
        heroUnitData._HeroAgent.destination = gameObject.transform.position;
    }


    // 데이터 관리용 파일에 옮기는걸 생각중
   public void attacktimeCon()
    {
        if (heroUnitData.attack == true)
        {
            heroUnitData.attacktime += Time.deltaTime;
            EndAttack();
        }
    }
    public void HeroDataReset()
    {
        heroUnitData.attacktime = 0f;
        heroUnitData.dietimer = 5f;
        heroUnitData.cortimer = 0f;
        heroUnitData._HeroSword.enabled = false;
        heroUnitData.attack = false;
        heroUnitData.hit = false;
        heroUnitData.hp = _maxHP;
        heroUnitData.move = true;
        _gameoverUI.gameObject.SetActive(false);
        _hpimage.Hpdown((float)heroUnitData.hp / _maxHP);
    }
    void HeroStartTrans()
    {
        gameObject.SetActive(false);
        if (heroUnitData.teamBlue == true)
        { gameObject.transform.position = new Vector3(-71, 0, -71); }
        else { gameObject.transform.position = new Vector3(71, 0, 71); }
        gameObject.SetActive(true);
    }
}

