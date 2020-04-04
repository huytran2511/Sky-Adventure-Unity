using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollector : MonoBehaviour
{
    private GameObject[] backgrounds;
    private float firstY;


    void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");

        firstY = backgrounds[0].transform.position.y;

        for(int i = 1; i < backgrounds.Length; i++)
        {
            if(firstY < backgrounds[i].transform.position.y)
            {
                firstY = backgrounds[i].transform.position.y;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Background")
        {
            Vector3 temp = collision.transform.position;
            float height = ((BoxCollider2D)collision).size.y;
            temp.y = firstY + height;
            collision.transform.position = temp;
            firstY = temp.y;
        }
    }
}
