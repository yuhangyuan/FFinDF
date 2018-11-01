using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //transform.position = PlayerBehaviour.playerTrans.position;
        //transform.rotation = PlayerBehaviour.playerTrans.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
