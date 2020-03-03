using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Vector2 move = new Vector2();
    [Range(1f, 6f)] [Tooltip("速度移动区间")] [SerializeField] private float speed = 4;
    [Range(0f, 0.5f)][SerializeField] private float smooting = 0.1f;
    private Rigidbody2D rigid;
    private Vector3 zeroVelocity = Vector3.zero;
    [SerializeField] private int hp = 10;
    [SerializeField] public bool IsDeath = false;
    public float ExtraGun = 10;
    private float ResetExtraGun;
    private int gunCount = 1;
    public Gun gun1;
    public Gun gun2;
    public Gun gun3;




    public void OnMove(InputAction.CallbackContext context)//移动控制
    {
        move = context.ReadValue<Vector2>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ResetExtraGun = ExtraGun;
        ExtraGun = 0;
        gun1.OnFire();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3();
        position.x = move.x * speed;
        position.y = move.y * speed;
        rigid.velocity = Vector3.SmoothDamp(rigid.velocity, position, ref zeroVelocity, smooting);

        ExtraGun -= Time.deltaTime;
        if (ExtraGun > 0)
        {
            if (gunCount == 1)
            {
                transfromToExtraGun();
            }
        }else
        {
            if(gunCount==2)
            {
                TransfromToNormalGun();
            }
        }
        
    }

    private void transfromToExtraGun()
    {
        gunCount = 2;
        gun1.stopFire();
        gun2.OnFire();
        gun3.OnFire();
        
    }
    private void TransfromToNormalGun()
    {
        gunCount = 1;
        gun2.stopFire();
        gun3.stopFire();
        gun1.OnFire();
    }

    public void BeHit()
    {
       
            hp -= 1;
            if (hp <= 0)
            {
                IsDeath = true;
                Destroy(this.gameObject);
                Time.timeScale = 0;
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="SinBullet")
        {
            Award award = collision.GetComponent<Award>();
            if(award.type==0)
            {
                ExtraGun = ResetExtraGun;
                Destroy(collision.gameObject);
            }
            
        }
    }

}
