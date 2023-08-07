using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manger : MonoBehaviour
{
    public GameObject play, setting, level;
    public Sprite on, off;
    public Button sound,music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onclickSetting()
    {
        setting.SetActive(true);
    } 
    
    public void onclickPlay()
    {
        level.SetActive(true);
        play.SetActive(false);
    }

    public void onclicksound()
    {
        if(sound.GetComponent<Image>().sprite == on)
        {
            sound.GetComponent<Image>().sprite = off;
        }
        else
        {
            sound.GetComponent<Image>().sprite = on;

        }
    }
    public void onclickmusic()
    {
        if (music.GetComponent<Image>().sprite == on)
        {
            music.GetComponent<Image>().sprite = off;
        }
        else
        {
            music.GetComponent<Image>().sprite = on;

        }
    }
    public void onclickClose()
    {
        setting.SetActive(false);
        play.SetActive(true);
    }
}
