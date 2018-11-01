using UnityEngine;
using System.Collections;

public class Ammunition : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.tag == "Player")
        {
            PlayerBehaviour.Ammunition += 1;
            Destroy(gameObject);
        }
    }
}
