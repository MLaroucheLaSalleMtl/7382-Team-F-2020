﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundBullet : MonoBehaviour
{
    public BulletCharacter bulletTemplate;
    public Transform firPoint;
    public List<BulletCharacter> tempBullets;

    public float CountTime;
    public float StopTime;

    // Start is called before the first frame update
    void Start()
    {
        tempBullets = new List<BulletCharacter>();
        CountTime *= Time.deltaTime;
        StopTime += Time.deltaTime;
        StartCoroutine(FirRound(5, firPoint.transform.position));
        //Destroy(gameObject, 4f);
    }
     void Update()
    {
        
    }

    IEnumerator FirRound(int number, Vector3 creatPoint)
    {
        Vector3 bulletDir = Vector3.down;//更改弹幕发射方式
        Quaternion rotateQuate = Quaternion.AngleAxis(10, Vector3.forward);//使用四元数制造绕Z轴旋转10度的旋转
        while (CountTime < StopTime)
        {
            yield return new WaitForSeconds(5f);
            for (int i = 0; i < number; i++)    //发射波数
        {
            for (int j = 0; j < 36; j++)
            {
                CreatBullet(bulletDir, firPoint.transform.position);
                bulletDir = rotateQuate * bulletDir; //让发射方向旋转10度，到达下一个发射方向
            }
            yield return new WaitForSeconds(0.5f); //协程延时，0.5秒进行下一波发射
        }
        yield return null;

        }
           
    }
    public BulletCharacter CreatBullet(Vector3 dir, Vector3 creatPoint)
    {
        BulletCharacter bulletCharacter = Instantiate(bulletTemplate, creatPoint, Quaternion.identity);
        bulletCharacter.gameObject.SetActive(true);
        bulletCharacter.dir = dir;
        tempBullets.Add(bulletCharacter);
        return bulletCharacter;
    }

}
