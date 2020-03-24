using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    private Image icon;
    private float timer = 0;
    public float cooldownTime;
    private bool isStartTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        icon = transform.Find("MaskK").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            isStartTimer = true;
        }

        if (isStartTimer)
        {
            timer += Time.deltaTime;
            icon.fillAmount = (cooldownTime - timer) / cooldownTime;
        }
        if (timer >= cooldownTime)
        {
            icon.fillAmount = 0;
            timer = 0;
            isStartTimer = false;
        }
    }
}
