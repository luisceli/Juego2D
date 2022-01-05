using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
     public GameObject jhon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(jhon != null){
        Vector3 position = transform.position;
        position.x = jhon.transform.position.x;
        transform.position= position;
        }
        
    }
}
