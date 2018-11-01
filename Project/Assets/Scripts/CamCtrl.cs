using UnityEngine;
using System.Collections;


public class CamCtrl : MonoBehaviour
{
    public static CamCtrl cc;
    public float smooth = 1f;
    Vector3 offset;
    float camShake;
    public Transform camTrans;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - PlayerBehaviour.playerTrans.position;
        cc = this;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 sp = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, PlayerBehaviour.playerTrans.position + offset, ref sp, smooth);
        //transform.LookAt(Player.playerTrans.position);

        if (camShake > 0)
        {
            camTrans.localPosition = Random.onUnitSphere * camShake * 0.25f;
            camShake -= Time.deltaTime;
            if (camShake <= 0)
            {
                camTrans.localPosition = Vector3.zero;
            }
        }
    }

    public void camShakeCtrl(float v)
    {
        if (camShake < v)
        {
            camShake = v;
        }
    }
}

