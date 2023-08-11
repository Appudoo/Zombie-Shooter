using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public static win inst;
    public Text complated_text;
    public GameObject star1, star2, star3;
    public Sprite fullstar, emtystar;
    int level,star;
    internal bool iswin;
    void Start()
    {
        inst = this;
        if (PlayerPrefs.GetInt("isPlay") == 0   )
        {
            level = PlayerPrefs.GetInt("crruntlevel");
        }
        else
        {
            level = PlayerPrefs.GetInt("level_number")-1;
        }
        Debug.Log(level);
        Debug.Log(gunController.instance.bulletCounter);

        complated_text.text = level + " Complated ";

        DefineStar();

        if(iswin)
        {
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    internal void DefineStar()
    {
        if (gunController.instance.bulletCounter == 4)
        {
            star1.GetComponent<Image>().sprite = fullstar;
            star2.GetComponent<Image>().sprite = fullstar;
            star3.GetComponent<Image>().sprite = fullstar;
            star = 3;
        }
        if (gunController.instance.bulletCounter == 3)
        {
            star1.GetComponent<Image>().sprite = fullstar;
            star2.GetComponent<Image>().sprite = fullstar;
            star3.GetComponent<Image>().sprite = emtystar;
            star = 2;
        }
        if (gunController.instance.bulletCounter < 3)
        {
            star1.GetComponent<Image>().sprite = fullstar;
            star2.GetComponent<Image>().sprite = emtystar;
            star3.GetComponent<Image>().sprite = emtystar;
            star = 1;
        }
        iswin = true;

        int level;
        if (PlayerPrefs.GetInt("isPlay") == 0)
        {
            level = PlayerPrefs.GetInt("crruntlevel");
        }
        else
        {
            level = PlayerPrefs.GetInt("level_number")-1;
        }

        PlayerPrefs.SetInt("star" + level, star);
    }

    public void onclickContinue()
    {
        SceneManager.LoadScene("play");
        Time.timeScale = 1;
        this.enabled = false;
    }
}
