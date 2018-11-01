using UnityEngine;
using System.Collections;

public class CreatGrass : MonoBehaviour
{
    public GameObject Grass;
    private int H;
    private int V;
    // Use this for initialization
    void Start()
    {
        for (H = -3; H < 3; H++)
        {
            //Vector3 Horizontal = new Vector3(H, 0, 0);
            //Instantiate(Grass, Horizontal, transform.rotation);
            for (V = -3; V < 3; V++)
            {
                Vector3 Vertical = new Vector3(H, 0, V);
                Instantiate(Grass, Vertical, transform.rotation);
            }
        }
    }


}
