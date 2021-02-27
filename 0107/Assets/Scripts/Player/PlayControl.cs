using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour
{
    private Rigidbody2D rb;//宣告剛體rb
    private Animator anim;//宣告動畫anim
    private float horizontalmove;//宣告一個float為horizontalmove
    private float facedirection;//宣告一個float為facedirection

    public Collider2D coll;//宣告碰撞體coll
    public float speed;//宣告一個float為speed
    public float jumpForce;//宣告一個float為jumpforce
    public LayerMask Ground;//宣告一個圖層變數Ground

    public static bool isMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        Movement();
        SwitchAnim();
    }

    void Update()
    {
        if (coll.IsTouchingLayers(Ground) && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Attack();
        }
        
    }

    void Movement()
    {
        horizontalmove = Input.GetAxis("Horizontal");//獲取橫軸變更
        facedirection = Input.GetAxisRaw("Horizontal");//直接獲取-1,0,1獲取整數

        //角色移動
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime, rb.velocity.y);
            //設置剛體速度(速度乘以一個時間參數)
            anim.SetFloat("Running", Mathf.Abs(facedirection));
        }

        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);//設置面向的方向
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        anim.SetBool("Jumping", true);//設置動畫jumping的bool值為true
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }

    void SwitchAnim()
    {
        anim.SetBool("Idle", false);//設置動畫idle的bool值為flase

        if (anim.GetBool("Jumping"))//如果得到動畫的bool值為jumping
        {
            if (rb.velocity.y < 0)//如果rb的y軸速度<0
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Falling", true);
            }
        }
        else if (coll.IsTouchingLayers(Ground))//如果碰撞體在地面
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Idle", true);
        }

    }

}
