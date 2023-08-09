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
    int level;
    internal bool iswin;
    void Start()
    {
        inst = this;
        level = PlayerPrefs.GetInt("level_number");
        Debug.Log(level);
        Debug.Log(gunController.instance.bulletCounter);

        complated_text.text = level-1 + " Complated ";

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
        }
        if (gunController.instance.bulletCounter == 3)
        {
            star1.GetComponent<Image>().sprite = fullstar;
            star2.GetComponent<Image>().sprite = fullstar;
            star3.GetComponent<Image>().sprite = emtystar;
        }
        if (gunController.instance.bulletCounter < 3)
        {
            star1.GetComponent<Image>().sprite = fullstar;
            star2.GetComponent<Image>().sprite = emtystar;
            star3.GetComponent<Image>().sprite = emtystar;
        }
        iswin = true;
    }

    public void onclickContinue()
    {
        SceneManager.LoadScene("play");
        Time.timeScale = 1;
        this.enabled = false;
    }
}
