using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Image iconG;
    private Image iconH;
    private Image iconJ;
    private Image iconK;

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
    private bool isStartTimerG = false;
    private bool isStartTimerH = false;
    private bool isStartTimerJ = false;
    private bool isStartTimerK = false;

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

    //private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        //this.manager = GameManager.instance;
        //iconG = transform.Find("MaskG").GetComponent<Image>();
        //iconH = transform.Find("MaskH").GetComponent<Image>();
        //icon = transform.Find("Mask").GetComponent<Image>();

        gun1.OnFire();
        iconK = transform.Find("MaskK").GetComponent<Image>();
        //gun2.stopFire();
        //gun3.stopFire();
        //shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SkillG();
        SkillK();
    }

    void FixedUpdate()
    {
        checkG();
        checkK();
    }

    private void SkillG()
    {
        if (Input.GetKey("g") && isGSkill == false && isGLock == false)
        {            
            isGLock = true;
            isGSkill = true;
            move.speed = 10;
            isStartTimerG = true;
        }
    }
    private void checkG()
    {
        if (isStartTimerG == true)
        {
            timerG += Time.deltaTime;
            iconG.fillAmount = (cooldownTime - timerG) / cooldownTime;         
        }
        if (timerG >= cooldownTimeG)
        {
            if (isGSkill == true)
            {
                move.speed = 4;
                isGSkill = false;
            }
        }
        if (timerG >= cooldownTime)
        {
            iconG.fillAmount = 0;
            timerG = 0;
            isGLock = false;
            isStartTimerG = false;
            //isGSkill = false;
        }
    }

    public void SkillK()
    {
        if (Input.GetKey("k") && isKSkill == false && isKLock == false)
        {
            isKLock = true;
            isKSkill = true;
            gun1.stopFire();
            gun2.OnFire();
            gun3.OnFire();
            isStartTimerK = true;
        }
    }
    private void checkK()
    {
        if (isStartTimerK == true)
        {
            timerK += Time.deltaTime;
            iconK.fillAmount = (cooldownTime - timerK) / cooldownTime;            
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
            iconK.fillAmount = 0;
            timerK = 0;
            isKLock = false;
            isStartTimerK = false;
            //isKSkill = false;
        }
    }

    //private void SkillH()
    //{
    //    if (isStartTimer == true)
    //    {
    //        timerH += Time.deltaTime;
    //        iconH.fillAmount = (cooldownTime - timerH) / cooldownTime;
    //        if (Input.GetKeyDown(KeyCode.H) && isHSkill == false && isHLock == false)
    //        {
    //            isHLock = true;
    //            isHSkill = true;
    //            shield.SetActive(true);
    //        }
    //    }
    //    if (timerH >= cooldownTimeH)
    //    {
    //        if (isHSkill == true)
    //        {
    //            isHSkill = false;
    //            shield.SetActive(false);
    //        }
    //    }

    //    if (timerH >= cooldownTime)
    //    {
    //        iconH.fillAmount = 0;
    //        timerH = 0;
    //        isHLock = false;
    //        isStartTimer = false;
    //        isHSkill = false;
    //    }
    //}

    //public void OnClick()
    //{
    //    isStartTimer = true;
    //}
}
