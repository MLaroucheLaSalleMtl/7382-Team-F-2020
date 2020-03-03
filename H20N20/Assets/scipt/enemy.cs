using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    enemyBasic,
    Boss
}


public class enemy : MonoBehaviour
{
    [SerializeField] private int hp = 1;
    [SerializeField] private float speed = 2;
    [SerializeField] private int goldscore=100;
    [SerializeField] private EnemyType type = EnemyType.enemyBasic;
    [SerializeField] public bool IsDeath = false;

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

    public void Hit()
    {
      
            hp -= 1;
            if(hp<=0)
            {
            toDead();
            Destroy(this.gameObject);
                
            }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!collision.GetComponent<PlayerMove>().IsDeath)
            {
                collision.gameObject.SendMessage("BeHit");
                GameObject.Destroy(this.gameObject);//撞到玩家后飞机消失 
            }

        }
    }

    private void toDead()
    {
        if (!IsDeath)
        {
          IsDeath = true;
          GameManager.instance.score += goldscore;
        }
        
    }
}
