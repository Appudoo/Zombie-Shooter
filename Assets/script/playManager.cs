using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playManager : MonoBehaviour
{
    public static playManager instance;
    public GameObject win;
    public GameObject[] levels = new GameObject[10];
    public int[] zombie_number;
    internal int DieConuter = 0;
    int level_no;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (PlayerPrefs.GetInt("isPlay") == 0)
        {
            level_no = PlayerPrefs.GetInt("crruntlevel");
        }
        else
        {
            level_no = PlayerPrefs.GetInt("level_number");
        }

        levels[level_no - 1].SetActive(true);
        Debug.Log("play l "+level_no);

        InvokeRepeating(nameof(CheckisOver), 0f, 3f);

    }

    // Update is called once per frame
    void Update()
    {

    }
    internal void CheckisOver()
    {
        Debug.Log(zombie_number[level_no - 1]);
        if (DieConuter == zombie_number[level_no - 1])
        {

            Debug.Log(PlayerPrefs.GetInt("isPlay"));
            StartCoroutine(nameof(onWin));
            if (PlayerPrefs.GetInt("isPlay") != 0)
            {
                level_no++;
                PlayerPrefs.SetInt("level_number", level_no);

            }
        }
    }
    IEnumerator onWin()
    {
        yield return new WaitForSeconds(2f);
        win.SetActive(true);
    }
}
