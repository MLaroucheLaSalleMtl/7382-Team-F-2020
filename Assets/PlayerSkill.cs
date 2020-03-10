using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    [Range(1f, 6f)] [Tooltip("速度移动区间")] [SerializeField] private float speed = 4;
    public float ExtraGun = 10;
    //public float AllGun = 2;
    private float ResetExtraGun;
    private static int gunCount = 1;
    public Gun gun1;
    public Gun gun2;
    public Gun gun3;
    public GameObject shield;
    public Image skill3Bullet;
    bool isSkill = false;
    // Start is called before the first frame update
    void Start()
    {
        ResetExtraGun = ExtraGun;
        ExtraGun = 0;
        gun1.OnFire();
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ExtraGun -= Time.deltaTime;

        if (ExtraGun > 0)
        {
            if (gunCount == 1)
            {
                transfromToExtraGun();
            }
        }
        else
        {
            if (gunCount == 2)
            {
                TransfromToNormalGun();
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            speed = speed * 2;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            transfromToExtraGun();
        }
    }

    private void transfromToExtraGun()
    {
        //if(skill3Bullet.fillAmount > 0)
        //{
        gunCount = 2;
        gun1.stopFire();
        gun2.OnFire();
        gun3.OnFire();
        //skill3Bullet.fillAmount = 1;
        // }
    }

    public void TransfromToNormalGun()
    {
        //if (skill3Bullet.fillAmount <= 0.2f)
        //{
        gunCount = 1;
        gun2.stopFire();
        gun3.stopFire();
        gun1.OnFire();
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SinBullet")
        {
            Award award = collision.GetComponent<Award>();
            if (award.type == 0)
            {
                ExtraGun = ResetExtraGun;
                Destroy(collision.gameObject);
            }

        }
        if (collision.tag == "Shield")
        {
            Award award = collision.GetComponent<Award>();
            if (award.type == 0)
            {
                shield.SetActive(true);
                Destroy(collision.gameObject);
            }
        }
    }
}
