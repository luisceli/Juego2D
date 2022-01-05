using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gruntScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject jhon;
    public float LastShoot;
    private int vida=3;
    private void Update()
    {
        if(jhon == null) {
            return;
        }
    
        Vector3 direction= jhon.transform.position - transform.position;
        if(direction.x >=0.0f) transform.localScale= new Vector3 (1.0f,1.0f,1.0f);
        else transform.localScale= new Vector3(-1.0f,1.0f,1.0f);

        float distance = Mathf.Abs(jhon.transform.position.x- transform.position.x);

        if(distance < 1.0f && Time.time >LastShoot+0.25f){
            Shoot();
            LastShoot= Time.time;
        }
    }

    public void Shoot (){
        Vector3 direction;
        if(transform.localScale.x ==1.0f) direction= Vector2.right;
        else direction = Vector2.left;

       GameObject bullet= Instantiate(bulletPrefab,transform.position + direction *0.1f ,Quaternion.identity);
       bullet.GetComponent<bullet_script>().SetDirection(direction);
    }

     public void Hit(){
        vida= vida-1;
        if(vida ==0)Destroy(gameObject);
    }
}
