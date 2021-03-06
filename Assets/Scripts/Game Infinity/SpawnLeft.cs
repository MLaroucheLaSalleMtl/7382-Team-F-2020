﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLeft : MonoBehaviour
{
    public GameObject enemyBasic2;
    [SerializeField] private float enemyBasicRate2 = 1f;
    public void CreateEnemyBasic2()
    {
        float x = Random.Range(1.87f, -0.06f);
        GameObject.Instantiate(enemyBasic2, transform.position += Vector3.right * Time.deltaTime, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyBasic2", 9, enemyBasicRate2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
