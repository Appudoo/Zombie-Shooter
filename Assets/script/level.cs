using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    public Sprite ispass, isfail, loack;
    public Button[] btn = new Button[10];
    public Sprite[] pass_no = new Sprite[10];
    public Sprite[] fail_no = new Sprite[10];
    int level_no = 1, click_no;
    // Start is called before the first frame update
    void Start()
    {
        level_no = PlayerPrefs.GetInt("level_number", 1)
;        for (int i = 0; i < btn.Length; i++)
        {
            int temp_btn_no = i+1;
            btn[i].GetComponent<Image>().sprite = isfail;
            btn[i].transform.GetChild(0).GetComponent<Image>().sprite = fail_no[i];
            btn[i].transform.GetChild(1).GetComponent<Image>().sprite = loack;
            btn[i].transform.GetChild(1).transform.position = new Vector2(btn[i].transform.position.x + 57.32f, btn[i].transform.position.y - 59.36f);
            btn[i].onClick.AddListener(() => onclickLevel_btn(temp_btn_no));
            btn[i].interactable = false;
        }
        for (int i = 0; i <= level_no - 1; i++)
        {
            btn[i].interactable = true;
            btn[i].GetComponent<Image>().sprite = ispass;
            btn[i].transform.GetChild(0).GetComponent<Image>().sprite = pass_no[i];
            btn[i].transform.GetChild(1).GetComponent<Image>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onclickLevel_btn(int n)
    {
        click_no = n;
        Debug.Log(click_no);
    }
}
