using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBtnScript : MonoBehaviour
{
    [SerializeField] Button MusicBtn;
    [SerializeField] GameObject MusicObj;
    // Start is called before the first frame update
    void Start()
    {
        MusicObj = GameObject.FindGameObjectWithTag("MusicObj");
        MusicBtn = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        MusicBtn.onClick.AddListener(() =>
        {
            MusicObj.GetComponent<MusicScript>().MusicBtnClick();
        });  
    }

    
}
