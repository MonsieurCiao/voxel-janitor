using System;
using UnityEngine;

public class questionBlock : MonoBehaviour
{
    public GameObject mushroom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(mushroom,new Vector3(transform.position.x, transform.position.y+1, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
