using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_movment : MonoBehaviour
{
    public static zombie_movment inst;
    float speed = 0.02f;
    Animator animator;
 
    internal int level;
    void Start()
    {
        inst = this;
        this.animator = this.GetComponent<Animator>();
        level = PlayerPrefs.GetInt("level_number");
    }

    // Update is called once per frame
    void Update()
    {
     
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
           
            this.GetComponent<PolygonCollider2D>().enabled = false;
            this.animator.SetTrigger("isDie");
            playManager.instance. DieConuter++;
           
           
            speed = 0;
        }
        if (collision.gameObject.tag == "right break")
        {
            speed = -0.01f;
            this.transform.position = new Vector2(transform.position.x - 0.8f, transform.position.y);
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (collision.gameObject.tag == "left break")
        {
            speed = 0.01f;
            this.transform.position = new Vector2(transform.position.x + 0.8f, transform.position.y);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
    internal void tiggerOn()
    {
        gunController.instance.audioSource.PlayOneShot(gunController.instance.zombieDie);
        this.animator.SetTrigger("isDie");
       
    }

    

}
