using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
     private Rigidbody2D  Rigidbody2D;
     private float horizontal;
     public float Speed;
     public float jumpforce;
     private bool suelo;
     private Animator Animator;
    public GameObject bulletPrefab; 

    private float LastShoot;
    private int vida=5;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     horizontal = Input.GetAxisRaw("Horizontal");

     if(horizontal <0.0f) transform.localScale= new Vector3(-1.0f,1.0f,1.0f);
     else if(horizontal> 0.0f)transform.localScale= new Vector3(1.0f,1.0f,1.0f);

     Animator.SetBool("Running",horizontal !=0.0f);

    Debug.DrawRay(transform.position,Vector3.down *0.1f);
    if( Physics2D.Raycast(transform.position, Vector3.down,0.1f)){
         suelo= true;
    }else
        suelo=false;

     if(Input.GetKeyDown(KeyCode.W)&& suelo){
         Jump();
     }

     if(Input.GetKey(KeyCode.Space)&& Time.time > LastShoot +0.25f){
         Shoot();
         LastShoot= Time.time;
     }
     }
    

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up *jumpforce);
    }

    private void Shoot(){

        Vector3 direction;
        if(transform.localScale.x ==1.0f) direction= Vector2.right;
        else direction = Vector2.left;

       GameObject bullet= Instantiate(bulletPrefab,transform.position + direction *0.1f ,Quaternion.identity);
       bullet.GetComponent<bullet_script>().SetDirection(direction);
    }
     private void FixedUpdate()
    {
        Rigidbody2D.velocity= new Vector2(horizontal, Rigidbody2D.velocity.y);
    }

    public void Hit(){
        vida= vida-1;
        if(vida ==0)Destroy(gameObject);
    }
}
