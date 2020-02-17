using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public bool isPlayer = true;    //该值是用来判断是否是玩家射出的子弹

    [Range(6f,10f)] [SerializeField] private float speed = 7f;    //子弹速度

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);    //创建子弹后,二秒后消除
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)//如果是玩家发射的子弹 
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);//up
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime); //down
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            if (!collision.GetComponent<enemy>().IsDeath)
            {
              collision.gameObject.SendMessage("Hit");
              GameObject.Destroy(this.gameObject);//撞到飞机后子弹消失 
            }
            
        }
    }
}
