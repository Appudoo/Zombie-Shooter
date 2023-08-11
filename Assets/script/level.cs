using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class level : MonoBehaviour
{
    public Sprite ispass, isfail, loack, fullStar, emtyStar;
    public Button[] btn = new Button[10];
    public Sprite[] pass_no = new Sprite[10];
    public Sprite[] fail_no = new Sprite[10];
    int level_no = 1, click_no;
    // Start is called before the first frame update
    void Start()
    {
        int level_no = PlayerPrefs.GetInt("level_number", 1);
        Debug.Log("lvl" + level_no);
        for (int i = 0; i < btn.Length; i++)
        {
            int temp_btn_no = i + 1;
            Debug.Log(temp_btn_no);
            btn[i].GetComponent<Image>().sprite = isfail;
            btn[i].transform.GetChild(0).GetComponent<Image>().sprite = fail_no[i];
            btn[i].transform.GetChild(1).GetComponent<Image>().sprite = loack;
            btn[i].transform.GetChild(1).transform.position = new Vector2(btn[i].transform.position.x + 57.32f, btn[i].transform.position.y - 59.36f);
            btn[i].onClick.AddListener(() => onclickLevel_btn(temp_btn_no));
            btn[i].interactable = false;
            btn[i].transform.GetChild(2).gameObject.SetActive(false);
        }
        for (int i = 0; i <= level_no - 1; i++)
        {
            btn[i].interactable = true;
            btn[i].GetComponent<Image>().sprite = ispass;
            btn[i].transform.GetChild(0).GetComponent<Image>().sprite = pass_no[i];
            btn[i].transform.GetChild(1).GetComponent<Image>().enabled = false;

        }
        for (int i = 0; i < level_no - 1; i++)
        {

            btn[i].transform.GetChild(2).gameObject.SetActive(true);
        }
        Debug.Log("hello");
        for (int i = 1; i <= level_no; i++)
        {
            int pass = PlayerPrefs.GetInt("star" + i);
            Debug.Log("pass" + pass);
            if (pass == 3)
            {

                btn[i - 1].transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = fullStar;
                btn[i - 1].transform.GetChild(2).transform.GetChild(1).GetComponent<Image>().sprite = fullStar;
                btn[i - 1].transform.GetChild(2).transform.GetChild(2).GetComponent<Image>().sprite = fullStar;
            }
            if (pass == 2)
            {
                btn[i - 1].transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = fullStar;
                btn[i - 1].transform.GetChild(2).transform.GetChild(1).GetComponent<Image>().sprite = fullStar;
                btn[i - 1].transform.GetChild(2).transform.GetChild(2).GetComponent<Image>().sprite = emtyStar;
            }
            if (pass == 1)
            {

                btn[i - 1].transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = fullStar;
                btn[i - 1].transform.GetChild(2).transform.GetChild(1).GetComponent<Image>().sprite = emtyStar;
                btn[i - 1].transform.GetChild(2).transform.GetChild(2).GetComponent<Image>().sprite = emtyStar;
            }


        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onclickLevel_btn(int n)
    {
        click_no = n;
        Debug.Log("CNO" + click_no);
        try
        {
            Debug.Log(btn[click_no - 1].transform.childCount);
            if (btn[click_no - 1].transform.GetChild(2).gameObject.activeSelf)
            {
                SceneManager.LoadScene("play");
                PlayerPrefs.SetInt("isPlay", 0);
                PlayerPrefs.SetInt("crruntlevel", click_no);
            }
            else
            {
                PlayerPrefs.SetInt("level_number", click_no);
                PlayerPrefs.SetInt("isPlay", 1);
                SceneManager.LoadScene("play");
            }
        }
        catch(System.Exception e)
        {
            Debug.Log(e.ToString());
        }

        //if (click_no < level_no && level_no>=1)
        //{

        //    SceneManager.LoadScene("play");
        //    PlayerPrefs.SetInt("isPlay", 0);
        //    PlayerPrefs.SetInt("crruntlevel", click_no);
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("level_number", click_no);
        //    PlayerPrefs.SetInt("isPlay", 1);
        //    SceneManager.LoadScene("play");

        //}


    }
}
