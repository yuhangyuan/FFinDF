using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrassCtrl : Avatar
{
    //草死后

    //草中生成物体类型
    public GameObject ItemSword;
    public GameObject ItemGun;
    public GameObject ItemBow;
    public GameObject Amm;
    public GameObject Aid;
    public GameObject Trap;
    public GameObject Other;

    //随机生成概率
    public float RadomItem;
    public float RadomAmmunition;
    public int WeightSword;
    public int WeightGun;
    public int WeightBow;
    public int WeightAid;
    public int WeightTrap;
    public int WeightOther;

    //是否已经生成过随机数
    bool isRandomed;

    public Transform GrassTrans;
    public float smooth = 0.5f;
    Vector2 offset2;
    Vector3 offset3;
    public float MoveTime;
    public Animator GrassAnim;
    SpriteRenderer IsGrass;
    float SightRate;

    public GameObject DeathBox;

    private void Awake()
    {
    }

    void Start()
    {
        GrassAnim = GetComponentInChildren<Animator>();
        IsGrass = GetComponentInChildren<SpriteRenderer>();
        DeathBox.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider grass)
    {
        if (grass.tag == "MySight")
        {
            SightRate = 0.1f;
        }
        if (Input.GetButton("AddSpeed"))
        {
            if (grass.tag == "Player")
            {
                GrassAnim.SetTrigger("isMoveA");
            }

        }
        if (grass.tag == "Enemy")
        {
            Debug.Log("青蛙跳了一下");
            GrassAnim.SetTrigger("isMove");
        }
        if (FrogCtrl.SpeedUpMove)
        {
        }
        if (grass.tag == "MyCuter")
        {
            Health = 0;
        }
    }


    void Update()
    {
        GrassAnim.SetFloat("SighTime", SightRate);
        if (SightRate >= 0f)
        {
            SightRate -= Time.deltaTime;
        }
        ///<summary>
        ///旧的草触发逻辑
        ///</summary>
        ///旧的草触发逻辑
        ///float PosDis = Vector3.Distance(transform.position, GrassTrans.position);
        ///if (PosDis > 0f)
        ///{
        ///   if (MoveTime > 0f)
        ///  {
        ///     MoveTime -= Time.deltaTime;
        ///    transform.position -= (transform.position - GrassTrans.position) * smooth * 0.5f;
        ///}
        ///}
        GrassState();
    }

    void GrassState()
    {
        if (Health <= 0)
        {
            GrassAnim.SetBool("isCut", true);
            //AnimatorStateInfo info = GrassAnim.GetCurrentAnimatorStateInfo(0);
            //if (info.normalizedTime >= 1.0f)
            //{
            //    IsGrass.enabled = false;
            //}

            DeathBox.GetComponent<BoxCollider>().enabled = true;
            //随机生成道具
            if (!isRandomed)
            {
                RandomValue();
                isRandomed = true;
            }
        }
        else
        {
            //IsGrass.enabled = true;
            GrassAnim.SetBool("isCut", false);
            //GrassAnim.SetBool("isAlive", true);

        }
    }

    public void RandomValue()
    {
        float a = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        if (RadomItem >= a)
        {//生成道具
            if (RadomAmmunition >= b)
            {//生成子弹
                Instantiate(Amm, transform.position, transform.rotation);
            }
            else
            {//生成工具
                int all = WeightSword + WeightGun + WeightBow + WeightAid + WeightTrap + WeightOther;
                float c = Random.Range(0.0f, all);
                if (c <= WeightSword)
                { //生成一把长剑
                    Instantiate(ItemSword, transform.position, transform.rotation);
                }
                else if (c > WeightSword && c <= WeightSword + WeightGun)
                {//生成一把枪
                    Instantiate(ItemGun, transform.position, transform.rotation);
                }
                else if (c > WeightSword + WeightGun && c <= WeightSword + WeightGun + WeightBow)
                {//生成一把弓
                    Instantiate(ItemBow, transform.position, transform.rotation);
                }
                else if (c > WeightSword + WeightGun + WeightBow && c <= WeightSword + WeightGun + WeightBow + WeightAid)
                {//生成急救包
                    //Instantiate(Aid, transform.position, transform.rotation);
                }
                else if (c > WeightSword + WeightGun + WeightBow && c <= WeightSword + WeightGun + WeightBow + WeightTrap)
                {//生成一个陷阱包
                    //Instantiate(Trap, transform.position, transform.rotation);
                }
                else
                {//生成其它什么鬼玩意儿
                    //Instantiate(Other, transform.position, transform.rotation);
                }
            }
        }
        else
        {//不生成道具
        }

    }
}
