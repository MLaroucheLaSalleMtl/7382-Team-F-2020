using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Image icon;
    public float cooldownTime = 2;
    public float timer = 0;
    public bool isStartTimer;
    private object getbuttondown;

    // Start is called before the first frame update
    void Start()
    {
        icon = transform.Find("Mask").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isStartTimer)
        {
            timer += Time.deltaTime;
            icon.fillAmount = (cooldownTime - timer) / cooldownTime;
        }
        if(timer >= cooldownTime)
        {
            icon.fillAmount = 0;
            timer = 0;
            isStartTimer = false;
        }
    }

    public void OnClick()
    {
        
        isStartTimer = true;
    }
}
