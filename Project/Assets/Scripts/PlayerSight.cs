using UnityEngine;
using System.Collections;

public class PlayerSight : MonoBehaviour
{
    MeshCollider MyCollider;
    float ColRate = 0.01f;
    // Use this for initialization
    void Start()
    {
        MyCollider = GetComponent<MeshCollider>();
        GetComponentInParent<PlayerBehaviour>();

        //如果是敌人，则屏蔽此代码
        if (!PlayerBehaviour.playerTrans.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (ColRate >= 0)
        {
            MyCollider.enabled = true;
            ColRate -= Time.deltaTime;
        }
        else
        {
            MyCollider.enabled = false;
            ColRate = 0.01f;
        }

    }
}
