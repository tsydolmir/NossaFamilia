﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float lifeTime = 0;
    public float distance = 0;
    public int damage = 1;
    public float speed = 8;

    bool collided = false;  

    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
         projetilmovement();   
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    public int getDamage()
    {
        return damage;
    }

    void projetilmovement()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        //checkCollision();
    }

    void OnTriggerEnter2D(Collider2D other)
    {    
        if(other != null)
        {            
            if(other.CompareTag("Enemy"))
            {           
                Debug.Log("ENTAO TA ENTRANDO AQUI");     
                other.GetComponent<LivingBeing>().onHit(damage);
                Destroy(gameObject);
            }
            
        }
    }

    

    // void checkCollision()
    // {
    //     RaycastHit2D hitInfo = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, -2), transform.forward, distance, enemyLayer);
        
    //     Debug.Log("ENTRA AQUEEEEE1");
    //     Debug.Log(hitInfo.collider);
    //     if(hitInfo.collider != null)
    //     {            
    //         Debug.Log("ENTRA AQUEEEEE2");
    //         if(hitInfo.collider.CompareTag("Enemy"))
    //         {                   
    //             Debug.Log("ENTRA AQUEEEEE3");
    //             hitInfo.collider.GetComponent<Enemy>().takeDamage(damage);                
    //         }
    //         DestroyProjetil();
           
    //     }
    // }

    // void OnCollisionEnter2D(Collision2D collisionInfo)
    // {
    //     if(collisionInfo.gameObject.layer == 11)
    //     {
    //         collisionInfo.collider.GetComponent<Enemy>().takeDamage(damage);
    //         DestroyProjetil();        
    //     }

    //     if(collisionInfo.gameObject.layer == 12 && !collided)
    //     {
    //         if (!collided)
    //         {
    //             collided = true;
    //             collisionInfo.collider.GetComponent<RunnerEnemy>().onHit(damage);
    //         }
            
    //         DestroyProjetil();
    //     }
    // }


    void DestroyProjetil()
    {
        Destroy(gameObject);
    }
}
