using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyBasic;
    public GameObject enemyBasic2;
    public GameObject Boss;
    public GameObject Award1;
    [SerializeField] private float enemyBasicRate = 0.5f;
    [SerializeField] private float enemyBasicRate2 = 1f;
    [SerializeField] private float BossRate = 40f;
    [SerializeField] private float Award1Rate = 10f;

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
    public void CreateBoss()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(Boss, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateAward1()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(Award1, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyBasic", 1, enemyBasicRate);
        InvokeRepeating("CreateEnemyBasic2", 3, enemyBasicRate);
        InvokeRepeating("CreateBoss", 50, enemyBasicRate);
        InvokeRepeating("CreateAward1", 40, enemyBasicRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
