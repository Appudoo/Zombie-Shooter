using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playManager : MonoBehaviour
{
    public static playManager instance;
    public GameObject[] levels = new GameObject[10];
    public int[] zombie_number = new int[10];
    int level_no;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        level_no = PlayerPrefs.GetInt("level_number");
        levels[level_no].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    internal void CheckisOver()
    {
        if(zombie_movment.inst.DieConuter == zombie_number[level_no-1])
        {
            Time.timeScale = 0;
        }
    }
}
