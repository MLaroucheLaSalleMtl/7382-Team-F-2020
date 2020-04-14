using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillJ : MonoBehaviour
{
    private Image iconJ;
    private bool isJSkill;
    private bool isJLock;
    public GameObject shield;
    private bool isStartTimerJ;
    private float timerJ;
    public float skillStopTime;
    public float cooldownTimeJ;

    // Start is called before the first frame update
    void Start()
    {
        iconJ = transform.Find("MaskJ").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("SkillJ") && isJSkill == false && isJLock == false)
        {
            isJLock = true;
            isJSkill = true;
            shield.SetActive(true);
            isStartTimerJ = true;
        }

        if (isStartTimerJ == true)
        {
            timerJ += Time.deltaTime;
            iconJ.fillAmount = (cooldownTimeJ - timerJ) / cooldownTimeJ;
        }
        if (timerJ >= skillStopTime)
        {
            if (isJSkill == true)
            {
                shield.SetActive(false);
                isJSkill = false;
            }
        }
        if (timerJ >= cooldownTimeJ)
        {
            iconJ.fillAmount = 0;
            timerJ = 0;
            isJLock = false;
            isStartTimerJ = false;
        }
    }
}
