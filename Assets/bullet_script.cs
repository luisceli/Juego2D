using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
    public AudioClip Sound;
    public float speed;
     private Rigidbody2D Rigidbody2D;
     private Vector2 Direction;
    void Start()
    {
         Rigidbody2D = GetComponent<Rigidbody2D>();
         Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
   private void FixedUpdate()
   {
       Rigidbody2D.velocity= Direction * speed;
   }

   public void SetDirection(Vector2 direction){
       Direction= direction;
   }

   public void DestroyBullet(){
       Destroy(gameObject);

   }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movimiento jhon= collision.GetComponent<Movimiento>();
       gruntScript grunt= collision.GetComponent<gruntScript>();

       if(jhon!= null){
           jhon.Hit();
       }

       if(grunt != null){
           grunt.Hit();
       }
       DestroyBullet();
    }
  
}
