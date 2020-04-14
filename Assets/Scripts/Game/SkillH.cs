using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillH : MonoBehaviour
{
    private Image iconH;
    private bool isHSkill;
    private bool isHLock;
    public PlayerMove move;
    private bool isStartTimerH;
    private float timerH;
    public float skillStopTime;
    public float cooldownTimeH;

    // Start is called before the first frame update
    void Start()
    {
        iconH = transform.Find("MaskH").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("SkillH") && isHSkill == false && isHLock == false)
        {
            isHLock = true;
            isHSkill = true;
            move.speed = move.speed * 2;
            isStartTimerH = true;
        }

        if (isStartTimerH == true)
        {
            timerH += Time.deltaTime;
            iconH.fillAmount = (cooldownTimeH - timerH) / cooldownTimeH;            
        }
        if (timerH >= skillStopTime)
        {
            if (isHSkill == true)
            {
                move.speed = move.speed / 2;
                isHSkill = false;
            }
        }
        if (timerH >= cooldownTimeH)
        {
            iconH.fillAmount = 0;
            timerH = 0;
            isHLock = false;
            isStartTimerH = false;
        }
    }
}
