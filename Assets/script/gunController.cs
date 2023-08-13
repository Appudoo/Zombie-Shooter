using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public static gunController instance;
    public GameObject bullet, gunpoint, parent, bullets_number, bullet_prefab;
    public Sprite bullets;
    GameObject[] imagesArray = new GameObject[6];
    internal AudioSource audioSource;
    public AudioClip gunFire, zombie, zombieDie;
    LineRenderer line;
    float angle;

    internal int bulletCounter = 5;

    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(zombie);
        line = GetComponent<LineRenderer>();
        for (int i = 0; i < 5; i++)
        {
            imagesArray[i] = Instantiate(bullet_prefab, bullets_number.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 gunPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        line.SetPosition(0, gunpoint.transform.position);
        line.SetPosition(1, mousePos);


        Vector2 offset = new Vector2(mousePos.x - gunPos.x, mousePos.y - gunPos.y);

        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
        }
    }

    void Fire()
    {

        Vector2 directionOfBullet = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        audioSource.PlayOneShot(gunFire);
        GameObject g = Instantiate(bullet, gunpoint.transform.position, Quaternion.Euler(0,0,angle));
        g.GetComponent<Rigidbody2D>().AddForce(directionOfBullet * 1500);
        destroy();
        
    }
    void destroy()
    {
        if (bulletCounter > 0)
        {
            Destroy(imagesArray[bulletCounter - 1]);
            bulletCounter--;
            
        }


        if (bulletCounter == 5)
        {
            Debug.Log("Game over");
        }
    }
}
