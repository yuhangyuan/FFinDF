using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoolCtrl : AICtrl
{
    public float MoveRate = 3;
    public float moveDis;
    float FoolMove;
    Vector3 Target;
    float offsetDot;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Hurt();
        FieldLimit();

        //傻子移動
        if (FoolMove < MoveRate)
        {
            FoolMove += Time.deltaTime;
        }
        else
        {
            Vector2 a = Random.insideUnitCircle + new Vector2(transform.position.x, transform.position.z);
            Target = new Vector3(a.x * moveDis, transform.position.y, a.y * moveDis);//目标位置
            //if (isWall)
            //{
            //    Debug.Log("转向");
            //    //transform.rotation = Quaternion.Euler(0, 180f, 0);
            //    Target = new Vector3(0, transform.position.y, -a.y * moveDis);
            //}
            transform.LookAt(Target);
            Vector3 offset = Target - transform.position;
            offsetDot = Vector3.Dot(offset, offset);
            FoolMove -= MoveRate;
        }

        if (offsetDot >= 0.5f)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
}
