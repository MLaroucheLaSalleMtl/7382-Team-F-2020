using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Image icon;
    public float cooldownTime = 8;
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
        if (isStartTimer)
        {
            timer += Time.deltaTime;
            icon.fillAmount = (cooldownTime - timer) / cooldownTime;
            //PlayerMove.SkillThreeGun();
        }
        if (timer >= cooldownTime)
        {
            icon.fillAmount = 0;
            timer = 0;
            isStartTimer = false;
            //PlayerMove.TransfromToNormalGun();
        }
    }

    public void OnClick()
    {       
        isStartTimer = true;
    }

    public void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {

        }
    }

    public void Skill2()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {

        }
    }

    public void Skill3()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {

        }
    }

    public void Skill4()
    {
        //if(Input.GetKeyDown(KeyCode.K))
        //{
        //    PlayerMove.gun2.OnFire();
        //}
    }
}
