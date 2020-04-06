using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class H : MonoBehaviour
{
    private Image iconH;
    private bool isHSkill;
    private bool isHLock;
    public GameObject shield;
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
            shield.SetActive(true);
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
                shield.SetActive(false);
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
