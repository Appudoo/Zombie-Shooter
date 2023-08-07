using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_movment : MonoBehaviour
{
    public static zombie_movment inst;
    float speed = 0.02f;
    public Sprite dieImage;
    Animator animator;
    bool isDie=false;
    void Start()
    {
        inst = this;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDie)
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            animator.SetTrigger("isDie");
            isDie = true;
            StartCoroutine(onDieImge());
            speed = 0;
        }
        if (collision.gameObject.tag == "right break")
        {
            speed = -0.01f;
            //this.GetComponent<SpriteRenderer>().flipX = true;
            this.transform.position = new Vector2(transform.position.x - 0.8f, transform.position.y);
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (collision.gameObject.tag == "left break")
        {
            speed = 0.01f;
            //this.GetComponent<SpriteRenderer>().flipX = false;
            this.transform.position = new Vector2(transform.position.x + 0.8f, transform.position.y);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
    internal void tiggerOn()
    {
        gunController.instance.audioSource.PlayOneShot(gunController.instance.zombieDie);
        this.animator.SetTrigger("isDie");
       
    }

    IEnumerator onDieImge()
    {
        yield return new WaitForSeconds(1.8f);
        this.animator.enabled = false;
    }

}
