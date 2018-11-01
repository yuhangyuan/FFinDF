﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static int V = 25;
    public static int H = 25;
    // Use this for initialization
    void Start()
    {
        for (V = -15; V < 15; V++)
        {
            for (H = -15; H < 15; H++)
            {
                GameObject Ink = ObjectPool.GetInstance().GetObj("GrassTrans");
                Ink.transform.position = transform.position + new Vector3(H, 0, V);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }


}
