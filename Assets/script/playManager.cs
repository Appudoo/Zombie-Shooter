using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playManager : MonoBehaviour
{
    public GameObject[] levels = new GameObject[10];
    int level_no;
    // Start is called before the first frame update
    void Start()
    {
        level_no = PlayerPrefs.GetInt("level_number");
        levels[level_no].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
