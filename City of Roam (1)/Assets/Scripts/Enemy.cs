using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    
    void Update()
    {

        transform.position += Vector3.left * speed * Time.deltaTime;
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.isTrigger)
        {
            Destroy(gameObject);
        }
        
    }
   
}
