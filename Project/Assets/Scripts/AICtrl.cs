using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICtrl : MonoBehaviour
{
    public int health = 3;
    public float speed;
    public static bool SpeedUpMove;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
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
    public void GetGrassMove()
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
    }
}
