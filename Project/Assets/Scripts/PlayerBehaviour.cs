using UnityEngine;
using System.Collections;

public class PlayerBehaviour : Avatar
{
    GameObject PlayerObj;
    public static Transform playerTrans;
    public float AddSpeed = 1.5f;
    float speedRom;
    float shotRate = 0.15f;
    Transform WeaponPoint;
    float bullettime;
    bool isGun;
    public GameObject Bullet;
    public GameObject Arrow;
    bool haveGun;
    bool haveBow;
    bool haveSword;
    bool handGun;
    bool handBow;
    bool handSword;
    public GameObject Amm;

    public GameObject IamHere;
    float IamHereRate;

    public void PlayerCtrl()
    {

    }

    void Awake()
    {
        PlayerObj = GetComponent<GameObject>();
        playerTrans = transform;
        Health = 3;
    }

    void Start()
    {
        speedRom = speed;
        WeaponPoint = transform.Find("Cube/weaponPoint");
        GameObject Knife = Instantiate(Resources.Load("Prefabs/Knife")) as GameObject;
        GameObject Sword = Instantiate(Resources.Load("Prefabs/Sword")) as GameObject;
        GameObject Gun = Instantiate(Resources.Load("Prefabs/Gun")) as GameObject;
        GameObject Bow = Instantiate(Resources.Load("Prefabs/Bow")) as GameObject;
        Knife.transform.parent = transform.Find("Cube/weaponPoint").transform;
        Sword.transform.parent = transform.Find("Cube/weaponPoint").transform;
        Gun.transform.parent = transform.Find("Cube/weaponPoint").transform;
        Bow.transform.parent = transform.Find("Cube/weaponPoint").transform;
        turnWeapon[0] = Knife;
        turnWeapon[1] = Sword;
        turnWeapon[2] = Gun;
        turnWeapon[3] = Bow;
        weaponType = turnWeapon[0];
        turnWeapon[1].SetActive(false);
        turnWeapon[2].SetActive(false);
        turnWeapon[3].SetActive(false);
        GameObject MyKnife = weaponType.transform.Find("Knife").gameObject;
        MyKnife.tag = "MyCuter";

        weaponType.GetComponentInChildren<MeshCollider>().enabled = false;
        weaponType.GetComponentInChildren<MeshRenderer>().enabled = false;

        IamHere.GetComponent<Collider>().enabled = false;
    }


    void Update()
    {
        if (IamHereRate >= 0)
        {
            IamHereRate -= Time.deltaTime;
        }
        else
        {
            IamHere.GetComponent<Collider>().enabled = false;
        }

        //Debug.Log("弹药数量 = " + Ammunition);
        //Debug.Log("玩家当前生命 = " + Health);
        #region//玩家朝向
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Ground" || hit.transform.tag == "Grass" || hit.transform.tag == "Wall")
            {
                Vector3 LookAtPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(LookAtPos);
            }
        }
        #endregion

        //玩家移动
        Move();

        if (bullettime < shotRate)
        {
            bullettime += Time.deltaTime;
            if (!isGun)
            {
                weaponType.GetComponentInChildren<MeshCollider>().enabled = false;
                weaponType.GetComponentInChildren<MeshRenderer>().enabled = false;
            }
        }
        //玩家切枪
        ChangeWeapon();
        bool isFire = false;
        if (Input.GetButton("Fire1") && bullettime >= shotRate)
        { isFire = true; }
        if (isFire)
        {
            if (!isGun)
            {
                if (handSword && haveSword)
                {
                    weaponType = turnWeapon[1];
                    weaponType.GetComponentInChildren<MeshCollider>().enabled = true;
                }
                else
                {
                    weaponType = turnWeapon[0];
                    weaponType.GetComponentInChildren<MeshCollider>().enabled = true;
                }
                //Debug.Log("打了一炮");
                weaponType.GetComponentInChildren<MeshRenderer>().enabled = true;
            }
            else
            {
                if (haveGun || haveBow)
                {
                    if (Ammunition > 0)
                    {
                        Ammunition -= 1;
                        if (weaponType == turnWeapon[2] && handGun && haveGun)
                        {
                            //生成一发向前移动的子弹
                            Instantiate(Bullet, transform.position + transform.forward * 1.5f, transform.rotation);
                            //Debug.Log("子弹的位置是 = " + transform.position);
                            //生成火花
                            //生成声音
                        }
                        if (weaponType == turnWeapon[3] && handBow && haveBow)
                        {
                            Instantiate(Arrow, transform.position + transform.forward * 2.0f, transform.rotation);
                            //生成一发向前移动的弓箭

                        }
                    }
                    else { Debug.Log("没有弹药"); }
                }

            }

            bullettime -= shotRate;
        }

        //Debug.Log("current weapon type = " + weaponType);
    }



    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
        {
            if (Input.GetButton("AddSpeed"))
            {
                speed = speedRom * AddSpeed;
            }
            else
            {
                speed = speedRom;
            }
            Vector3 velocity = new Vector3(h, 0, v);
            transform.Translate(velocity * speed * Time.deltaTime);
        }
    }
    void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (turnWeapon != null)
            {
                isGun = false;
                handGun = false;
                handBow = false;
                handSword = false;
                weaponType = turnWeapon[0];
                turnWeapon[0].SetActive(true);
                turnWeapon[1].SetActive(false);
                turnWeapon[2].SetActive(false);
                turnWeapon[3].SetActive(false);
                shotRate = 0.15f;
                //动态设置物体标签
                //GameObject MyKnife = weaponType.transform.Find("Knife").gameObject;
                //MyKnife.tag = "MyCuter";
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (turnWeapon != null && haveSword)
            {
                isGun = false;
                handGun = false;
                handBow = false;
                handSword = true;
                weaponType = turnWeapon[1];
                turnWeapon[1].SetActive(true);
                turnWeapon[0].SetActive(false);
                turnWeapon[2].SetActive(false);
                turnWeapon[3].SetActive(false);
                shotRate = 1.0f;
                //动态设置物体标签
                GameObject MySword = weaponType.transform.Find("Sword").gameObject;
                MySword.tag = "MyCuter";
                //GameObject MySword = turnWeapon[1].GetComponentInChildren<GameObject>();
                //Debug.Log(MySword);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (turnWeapon != null && haveGun)
            {
                isGun = true;
                handGun = true;
                handBow = false;
                handSword = false;
                weaponType = turnWeapon[2];
                turnWeapon[2].SetActive(true);
                turnWeapon[1].SetActive(false);
                turnWeapon[0].SetActive(false);
                turnWeapon[3].SetActive(false);
                shotRate = 1.0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (turnWeapon != null && haveBow)
            {
                isGun = true;
                handGun = false;
                handBow = true;
                handSword = false;
                weaponType = turnWeapon[3];
                turnWeapon[3].SetActive(true);
                turnWeapon[1].SetActive(false);
                turnWeapon[2].SetActive(false);
                turnWeapon[0].SetActive(false);
                shotRate = 3.0f;
            }
        }
    }
    void OnTriggerEnter(Collider Coll)
    {

        //如果被子弹打中
        if (Coll.tag == "Bullet") { Hurt(2); }
        if (Coll.tag != "MyCuter")
        {
            //如果被小刀击中
            if (Coll.name == "Knife") { Hurt(1); }
            //如果被剑击中
            if (Coll.name == "Sword") { Hurt(2); }
        }
        if (Coll.tag == "Gun")
        {//拥有枪
            haveGun = true;
        }
        if (Coll.tag == "Bow")
        {//拥有弓
            haveBow = true;
        }
        if (Coll.tag == "ItemSword")
        {//拥有剑
            haveSword = true;
        }
        //如果离开草
        if (Coll.name == "DeathBox")
        {
            //Debug.Log("我被发现了！！！");
            IamHereRate = 1.0f;
            IamHere.GetComponent<Collider>().enabled = true;
        }
    }
    public void Hurt(int V)
    {
        if (V > 0)
        {
            //受伤特效+受伤音效
            Health -= V;
            if (Health <= 0)
            {
                Leave();
                Death();
            }
        }
    }
    public void Death()
    {
        Debug.Log("虽然你还活着，但你已经死了");
        gameObject.SetActive(false);
        //死亡特效
    }
    //死亡掉落
    void Leave()
    {
        int i = 0;
        for (i = 0; i <= Ammunition; i++)
        {
            Instantiate(Amm);
        }
    }
}
