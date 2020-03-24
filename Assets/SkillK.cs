using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillK : MonoBehaviour
{
    private bool isKSkill;
    private bool isKLock;

    public Gun gun1;
    public Gun gun2;
    public Gun gun3;

    private bool isStartTimerK;
    private float timerK;
    public float cooldownTimeK;
    private float coolTime;

    private CoolDown cooldown;

    // Start is called before the first frame update
    void Start()
    {
        coolTime = cooldown.cooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && isKSkill == false && isKLock == false)
        {
            isKLock = true;
            isKSkill = true;
            gun1.stopFire();
            gun2.OnFire();
            gun3.OnFire();
            timerK += Time.deltaTime;
            isStartTimerK = true;
        }
        //if (isStartTimerK == true)
        //{
        //    timerK += Time.deltaTime;
        //}
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
        if (timerK >= coolTime)
        {
            timerK = 0;
            isKLock = false;
            //isStartTimerK = false;
            isKSkill = false;
        }
    }
}
