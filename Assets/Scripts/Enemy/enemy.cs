using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class enemy : MonoBehaviour
{
    [SerializeField] private int hp = 1;
    [SerializeField] private float speed = 3;
    [SerializeField] private int goldscore=100;
    [SerializeField] public bool IsDeath = false;
    [SerializeField] private GameObject EnemyGun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Enemy")
        {
         this.transform.Translate(Vector3.down * speed * Time.deltaTime);//向下运动
        }
        else if(gameObject.tag=="EnemyLeft")
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        else if(gameObject.tag=="EnemyRight")
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        else if(gameObject.tag=="Boss")
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(2, 7, -5), step);
        }
        else if (gameObject.tag == "Boss2")
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(0, 5, -14), step);
        }
        else if (gameObject.tag == "Boss3")
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(2, 7, -5), step);
        }

        if (this.transform.position.y<-5.6f)//当敌人超过-5.6时摧毁
        {
            Destroy(this.gameObject);
        }
    }

    public void Hit()
    {

        hp -= 1;
            if(hp<=0)
            {
            if(this.gameObject.tag=="Enemy"||this.gameObject.tag=="EnemyLeft"||this.gameObject.tag=="EnemyRight")
            {
                IsDeath = true;
                Destroy(this.gameObject);
                GameManager.instance.score += goldscore;

            }
            if(this.gameObject.tag=="Boss")
            {
                IsDeath = true;
                Destroy(this.gameObject);
                GameManager.instance.score += goldscore;
            }
            if (this.gameObject.tag == "Boss2")
            {
                IsDeath = true;
                Destroy(this.gameObject);
                GameManager.instance.score += goldscore;
            }
            if (this.gameObject.tag == "Boss3")
            {
                IsDeath = true;
                Destroy(this.gameObject);
                GameManager.instance.score += goldscore;
            }

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

        if (collision.tag == "Shield")
        {
            //collision.gameObject.SendMessage("ShieldBeHit");
            GameObject.Destroy(this.gameObject);
        }
    }
}
