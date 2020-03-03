using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyBasic;
    public GameObject enemyBasic2;
    public GameObject Stone;
    public GameObject AwardBullet;
    public GameObject AwardShield;
    public GameObject Laser;
    public GameManager enemyBasicRate1;

    [SerializeField] private float enemyBasicRate = 0.5f;
    [SerializeField] private float enemyBasicRate2 = 1f;
    [SerializeField] private float StoneRate = 5f;
    [SerializeField] private float AwardBulletRate = 10f;
    [SerializeField] private float AwardShieldRate = 10f;
    [SerializeField] private float LaserRate = 10f;
    private float seconds, minutes;

    

    public void CreateEnemyBasic()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(enemyBasic, new Vector3(x,transform.position.y,0), Quaternion.identity);
    }
    public void CreateEnemyBasic2()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(enemyBasic2, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateStone()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(Stone, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateAward1()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(AwardBullet, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateAwardShield()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(AwardShield, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }

    public void CreateLaser()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(Laser, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyBasicRate1 = GetComponent<GameManager>();
        enemyBasicRate = GameManager.enemyBasicRate1;
        
        InvokeRepeating("CreateEnemyBasic", 1, enemyBasicRate);
        InvokeRepeating("CreateEnemyBasic2", 10, enemyBasicRate2);
        InvokeRepeating("CreateStone", 8, StoneRate);
        InvokeRepeating("CreateAward1", 3, AwardBulletRate);
        InvokeRepeating("CreateAwardShield", 5, AwardShieldRate);
        InvokeRepeating("CreateLaser", 6, LaserRate);
        InvokeRepeating("IncreaseEnemyRate", 10, 10);
    }
    void IncreaseEnemyRate()
    {
       //GameManager.instance.enemyBasicRate1 *= 0.1f;
         enemyBasicRate *= 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        //CountTime();
    }

    /*public void CountTime()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        if (seconds >= 10f)
        {
            enemyBasicRate *= 0.8f;
        }

    }*/
}
