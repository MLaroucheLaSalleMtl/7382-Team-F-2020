using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private int hp = 1;
    [SerializeField] private float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);//向下运动
        if(this.transform.position.y<-5.6f)//当敌人超过-5.6时摧毁
        {
            Destroy(this.gameObject);
        }
    }
}
