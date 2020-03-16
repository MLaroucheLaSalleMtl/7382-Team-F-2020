using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    private Image icon;
    public float cooldownTime = 8;
    public float timer = 0;
    public bool isStartTimer = false;

    public PlayerMove move;
    public Gun gun1;
    public Gun gun2;
    public Gun gun3;

    bool isGSkill = false;
    bool isHSkill = false;
    bool isJSkill = false;
    bool isKSkill = false;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        icon = transform.Find("Mask").GetComponent<Image>();

        gun1.OnFire();
        gun2.stopFire();
        gun3.stopFire();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartTimer)
        {
            //isStartTimer = true;
            timer += Time.deltaTime;
            icon.fillAmount = (cooldownTime - timer) / cooldownTime;
            if(Input.GetKeyDown(KeyCode.K))
            {               
                isKSkill = true;
                gun1.stopFire();
                gun2.OnFire();
                gun3.OnFire();               
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                isGSkill = true;
                move.speed = move.speed * 2;
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                isHSkill = true;
                gun1.OnFireH();
            }
        }
        if (timer >= cooldownTime)
        {
            icon.fillAmount = 0;
            timer = 0;
            isStartTimer = false;
            if(isKSkill == true)
            {
                isKSkill = false;
                gun1.OnFire();
                gun2.stopFire();
                gun3.stopFire();
            }
            if (isGSkill == true)
            {
                isKSkill = false;
                move.speed = move.speed / 2;
            }
            if (isHSkill == true)
            {
                isHSkill = false;
                gun1.stopFire();
                gun1.OnFire();
            }
        }
    }

    public void OnClick()
    {       
        isStartTimer = true;
    }
}
