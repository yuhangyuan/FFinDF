using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public int FrogWeight;
    public int FoolWeight;
    public int SmartWeight;
    public int CunningWeight;
    public GameObject Frog;
    public GameObject Fool;
    public GameObject Smart;
    public GameObject Cunning;
    public int AICount = 20;
    int all;

    // Use this for initialization
    void Start()
    {
        int i;
        for (i = 0; i <= AICount; i++)
        {
            all = FrogWeight + FoolWeight + SmartWeight + CunningWeight;
            int x = Random.Range(-Board.H, Board.H);
            int y = Random.Range(-Board.V, Board.V);
            RandomValue(x, y, all);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RandomValue(float x, float y, int all)
    {

        float c = Random.Range(0.0f, all);
        if (c <= FrogWeight)
        { //生成青蛙
            Instantiate(Frog, new Vector3(x, 0.25f, y), transform.rotation);
        }
        else if (c > FrogWeight && c <= FrogWeight + FoolWeight)
        {//生成智障
            Instantiate(Fool, new Vector3(x, 0.5f, y), transform.rotation);
        }
        else if (c > FrogWeight + FoolWeight && c <= FrogWeight + FoolWeight + SmartWeight)
        {//生成聪明
            Instantiate(Smart, new Vector3(x, 0.5f, y), transform.rotation);
        }
        else if (c > FrogWeight + FoolWeight + SmartWeight && c <= FrogWeight + FoolWeight + SmartWeight + CunningWeight)
        {//生成狡诈
            Instantiate(Cunning, new Vector3(x, 0.5f, y), transform.rotation);
        }
    }
}
