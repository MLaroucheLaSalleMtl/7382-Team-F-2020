using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G : MonoBehaviour
{
    private Image iconG;
    private bool isGSkill;
    private bool isGLock;
    public PlayerMove move;
    private bool isStartTimerG;
    private float timerG;
    public float skillStopTime;
    public float cooldownTimeG;

    // Start is called before the first frame update
    void Start()
    {
        iconG = transform.Find("MaskG").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("SkillG") && isGSkill == false && isGLock == false)
        {
            isGLock = true;
            isGSkill = true;
            move.speed = move.speed * 2;
            isStartTimerG = true;
        }

        if (isStartTimerG == true)
        {
            timerG += Time.deltaTime;
            iconG.fillAmount = (cooldownTimeG - timerG) / cooldownTimeG;            
        }
        if (timerG >= skillStopTime)
        {
            if (isGSkill == true)
            {
                move.speed = move.speed / 2;
                isGSkill = false;
            }
        }
        if (timerG >= cooldownTimeG)
        {
            iconG.fillAmount = 0;
            timerG = 0;
            isGLock = false;
            isStartTimerG = false;
        }
    }
}
