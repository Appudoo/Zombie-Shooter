using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManger : MonoBehaviour
{
    int WithBoeder = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="left"|| collision.gameObject.tag == "right"|| collision.gameObject.tag == "top"||collision.gameObject.tag == "buttom")
        {
            WithBoeder++;
           
            if(WithBoeder%10==0)
            {
                Destroy(this.gameObject);
            }
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            Debug.Log("hello");
            zombie_movment.inst.tiggerOn();
            
        }
    }


}
