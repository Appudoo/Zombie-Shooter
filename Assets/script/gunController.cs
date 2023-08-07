using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public static gunController instance;
    public GameObject bullet, gunpoint, parent, bullets_number, bullet_prefab;
    public Sprite bullets;
    public GameObject[] imagesArray = new GameObject[5];
    internal AudioSource audioSource;
    public AudioClip gunFire, zombie, zombieDie;
    public GameObject target;
    int bulletCounter = 0;

    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(zombie);
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

        target.transform.position = new Vector2(mousePos.x, mousePos.y);

        Vector2 offset = new Vector2(mousePos.x - gunPos.x, mousePos.y - gunPos.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        bulletCounter++;
        Vector2 directionOfBullet = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        print(directionOfBullet);
        audioSource.PlayOneShot(gunFire);
        GameObject g = Instantiate(bullet, gunpoint.transform.position, Quaternion.identity);
        g.transform.SetParent(parent.transform);
        g.GetComponent<Rigidbody2D>().AddForce(directionOfBullet * 1500);
        destroy();
        playManager.instance.CheckisOver();
    }
    void destroy()
    {
        Destroy(imagesArray[bulletCounter-1]);
        if (bulletCounter == 5)
        {
            Debug.Log("Game over");
        }
    }



}
