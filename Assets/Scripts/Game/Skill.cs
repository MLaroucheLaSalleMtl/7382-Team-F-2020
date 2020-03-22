using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    private Image icon;
    public float cooldownTime;
    public float cooldownTimeG;
    public float cooldownTimeH;
    public float cooldownTimeJ;
    public float cooldownTimeK;

    private float timerG = 0;
    private float timerH = 0;
    private float timerJ = 0;
    private float timerK = 0;

    private bool isStartTimer = false;
    //private bool isStartTimerG = false;
    //private bool isStartTimerH = false;
    //private bool isStartTimerJ = false;
    //public bool isStartTimerK = false;

    public PlayerMove move;
    public GameObject shield;
    public Gun gun1;
    public Gun gun2;
    public Gun gun3;

    bool isGSkill = false;
    bool isHSkill = false;
    bool isJSkill = false;
    bool isKSkill = false;

    bool isKLock = false;
    bool isGLock = false;
    bool isHLock = false;
    bool isJLock = false;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        icon = transform.Find("Mask").GetComponent<Image>();

        gun1.OnFire();
        gun2.stopFire();
        gun3.stopFire();
        //shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SkillK();
        SkillG();
        //SkillH();
    }

    private void SkillK()
    {
        if (isStartTimer == true)
        {
            timerK += Time.deltaTime;
            icon.fillAmount = (cooldownTime - timerK) / cooldownTime;
            if (Input.GetKeyDown(KeyCode.K) && isKSkill == false && isKLock == false)
            {
                isKLock = true;
                isKSkill = true;
                gun1.stopFire();
                gun2.OnFire();
                gun3.OnFire();
            }
        }
        if (timerK >= cooldownTimeK)
        {
            if (isKSkill == true)
            {
                isKSkill = false;
                gun1.OnFire();
                gun2.stopFire();
                gun3.stopFire();
            }
        }

        if (timerK >= cooldownTime)
        {
            icon.fillAmount = 0;
            timerK = 0;
            isKLock = false;
            isStartTimer = false;
            isKSkill = false;
        }
    }

    private void SkillG()
    {
        if (isStartTimer == true)
        {
            timerG += Time.deltaTime;
            icon.fillAmount = (cooldownTime - timerG) / cooldownTime;
            if (Input.GetKeyDown(KeyCode.G) && isGSkill == false && isGLock == false)
            {
                isGLock = true;
                isGSkill = true;
                move.speed = move.speed * 2;
            }
        }
        if (timerG >= cooldownTimeG)
        {
            if (isGSkill == true)
            {
                isGSkill = false;
                move.speed = move.speed / 2;
            }
        }

        if (timerG >= cooldownTime)
        {
            icon.fillAmount = 0;
            timerG = 0;
            isGLock = false;
            isStartTimer = false;
            isGSkill = false;
        }
    }

    private void SkillH()
    {
        if (isStartTimer == true)
        {
            timerH += Time.deltaTime;
            icon.fillAmount = (cooldownTime - timerH) / cooldownTime;
            if (Input.GetKeyDown(KeyCode.H) && isHSkill == false && isHLock == false)
            {
                isHLock = true;
                isHSkill = true;
                shield.SetActive(true);
            }
        }
        if (timerH >= cooldownTimeH)
        {
            if (isHSkill == true)
            {
                isHSkill = false;
                shield.SetActive(false);
            }
        }

        if (timerH >= cooldownTime)
        {
            icon.fillAmount = 0;
            timerH = 0;
            isHLock = false;
            isStartTimer = false;
            isHSkill = false;
        }
    }

    public void OnClick()
    {
        isStartTimer = true;
    }
}
