using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogCtrl : AICtrl
{
    public float MoveRate = 3;
    public float moveDis;
    public float JumpRate = 3;
    float FragJump;
    float FragMove;
    float speeDir;
    bool isWall;

    void Start()
    {
        FragMove = Random.Range(0.0f, MoveRate);
        FragJump = Random.Range(0.0f, JumpRate);
        speeDir = speed;
    }
    Vector3 Target;
    float offsetDot;
    void Update()
    {
        Hurt();
        FieldLimit();


        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 3, Color.red);
        //RaycastHit hit = new RaycastHit();
        //if (Physics.Raycast(ray, out hit))
        //{
        //    Debug.Log(hit.transform.gameObject.tag);
        //    float PointDis = (hit.transform.position - transform.position).sqrMagnitude;
        //    Debug.Log(PointDis);
        //    if (hit.transform.gameObject.tag == "Wall" && PointDis <= 1)
        //    {
        //        isWall = true;
        //    }
        //    else
        //    {
        //        isWall = false;
        //    }
        //}

        //青蛙移动
        if (FragMove < MoveRate)
        {
            FragMove += Time.deltaTime;
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
            FragMove -= MoveRate;
        }

        if (offsetDot >= 0.5f)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        //青蛙跳
        if (FragJump < JumpRate)
        {
            FragJump += Time.deltaTime;
            speed = speeDir;
            SpeedUpMove = false;
        }
        else
        {
            transform.position += transform.forward;
            SpeedUpMove = true;
            FragJump -= JumpRate;
        }

    }
    //public void Turnback()
    //{
    //    Ray ray = new Ray(transform.position, transform.forward);
    //    Debug.DrawRay(ray.origin, ray.direction * 3, Color.red);
    //    RaycastHit hit = new RaycastHit();
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        if (hit.transform.gameObject.tag == "Wall")
    //        {
    //            Debug.Log("撞墙了");
    //            transform.rotation = Quaternion.Euler(0, 180f, 0);
    //            Target = transform.forward;
    //        }
    //    }
    //}
}
