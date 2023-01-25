using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsIconFill : MonoBehaviour
{
    [SerializeField] Image FillImage;
    public float TimeLeftSkill;
    void Start()
    {
        StartCoroutine(DestroyThisIcon(TimeLeftSkill));
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeLeftSkill > 0)
        {
            FillImage.fillAmount -= 1f / TimeLeftSkill * Time.deltaTime;
        }
    }

    IEnumerator DestroyThisIcon(float DestroyDelay)
    {
        yield return new WaitForSeconds(DestroyDelay);
        Destroy(gameObject);
    }
}  

   

