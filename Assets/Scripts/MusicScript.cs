using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
    public static MusicScript instance;
    public bool play;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (this != instance)
            {
                Destroy(this.gameObject);
            }
        }

    }
    void Start()
    {
        play = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicBtnClick()
    {

        if (play == true)
        {
            play = false;
            gameObject.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            play = true;
            gameObject.GetComponent<AudioSource>().mute = false;
        }
    }
}
