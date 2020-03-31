using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Vector2 move = new Vector2();
    [Range(1f, 6f)] [Tooltip("速度移动区间")] [SerializeField] public float speed = 4;
    [Range(0f, 0.5f)][SerializeField] private float smooting = 0.1f;
    private Rigidbody2D rigid;
    private Vector3 zeroVelocity = Vector3.zero;
    [SerializeField] private int hp = 10;
    [SerializeField] public bool IsDeath = false;
    
    public GameObject deadpanel;   
    private GameManager manager;

    public GameObject skill;

    public void OnMove(InputAction.CallbackContext context)//移动控制
    {
        move = context.ReadValue<Vector2>();        
    }
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        rigid = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3();
        position.x = move.x * speed;
        position.y = move.y * speed;
        rigid.velocity = Vector3.SmoothDamp(rigid.velocity, position, ref zeroVelocity, smooting);
    }  

    public void ISDeath()
    {
        IsDeath = true;
    }

    public void BeHit()
    {
        hp -= 1;
        if (hp <= 0)
        {
            ISDeath();
            Destroy(this.gameObject);
            Time.timeScale = 0f;
            deadpanel.SetActive(true);
            skill.SetActive(false);
        }
    }   
}
