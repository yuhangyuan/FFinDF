using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Avatar : MonoBehaviour
{
    public GameObject Body;
    public float MaxHealth = 1;
    public float Health;
    public float speed = 1f;
    public static int Ammunition;
    float hurt;
    public GameObject[] turnWeapon = new GameObject[4];
    public GameObject weaponType;

    private void Awake()
    {
        Health = MaxHealth;
    }


    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }



}
