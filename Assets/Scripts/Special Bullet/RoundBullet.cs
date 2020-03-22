using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundBullet : MonoBehaviour
{
    public BulletCharacter bulletTemplate;
    public Transform firPoint;
    public List<BulletCharacter> tempBullets;

    // Start is called before the first frame update
    void Start()
    {
        tempBullets = new List<BulletCharacter>();
        StartCoroutine(FirRound(5, firPoint.transform.position));
        Destroy(gameObject, 4f);
    }

    IEnumerator FirRound(int number, Vector3 creatPoint)
    {
        Vector3 bulletDir = firPoint.transform.up;
        Quaternion rotateQuate = Quaternion.AngleAxis(10, Vector3.forward);//使用四元数制造绕Z轴旋转10度的旋转
        for (int i = 0; i < number; i++)    //发射波数
        {
            for (int j = 0; j < 36; j++)
            {
                CreatBullet(bulletDir, creatPoint);
                bulletDir = rotateQuate * bulletDir; //让发射方向旋转10度，到达下一个发射方向
            }
            yield return new WaitForSeconds(0.5f); //协程延时，0.5秒进行下一波发射
        }
        yield return null;
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
