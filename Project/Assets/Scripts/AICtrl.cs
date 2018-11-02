using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICtrl : MonoBehaviour
{
    public int health = 3;
    public float speed;
    public static bool SpeedUpMove;
    public GameObject IamHere;
    float IamHereRate;


    void Start()
    {

    }

    void Update()
    {



    }

    public void Move(Vector3 Target)
    {
    }
    public void Run()
    {
    }
    public void Cutting()
    {
    }
    public void Fire()
    {
    }
    //识别最近的动静
    public void GetMove()
    {
        //判断为草动

        //判断为阿凡达动

    }
    //识别人
    public void GetAvatar()
    {

    }

    public void Hurt()
    {
        if (health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Debug.Log("我死了");
        Destroy(gameObject);
    }

    public void FieldLimit()
    {
        if (transform.position.x < -26f) { transform.position = new Vector3(transform.position.x + Time.deltaTime * 10, transform.position.y, transform.position.z); }
        if (transform.position.x > 24f) { transform.position = new Vector3(transform.position.x - Time.deltaTime * 10, transform.position.y, transform.position.z); }
        if (transform.position.z > 24f) { transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * 10); }
        if (transform.position.z < -24.5f) { transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * 10); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Knife")
        {
            Debug.Log("被剌了一刀");
            health--;
        }
        if (other.name == "Sword")
        {
            Debug.Log("被捅了一刀");
            health -= 2;
        }
        if (other.name == "Bullet")
        {
            Debug.Log("被射了一枪");
            health--;
        }
        if (other.name == "Arrow")
        {
            Debug.Log("被射了一箭");
            health -= 2;
        }
        //如果离开草
        if (other.name == "DeathBox")
        {
            Debug.Log("我被发现了！！！");
            IamHereRate = 1.0f;
            IamHere.GetComponent<Collider>().enabled = true;
        }
    }
    //隐身延迟
    public void IamDisappear()
    {
        if (IamHereRate >= 0)
        {
            IamHereRate -= Time.deltaTime;
        }
        else
        {
            IamHere.GetComponent<Collider>().enabled = false;
        }
    }
}
