using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 1)] static public int Maz_ID_Now = 1;//紀錄當前型態

    private Rigidbody2D rb;//宣告剛體rb
    private Animator[] anim = { null, null };
    private float horizontalmove;//宣告一個float為horizontalmove
    private float facedirection;//宣告一個float為facedirection

    public Collider2D coll;//宣告碰撞體coll
    public float speed;//宣告一個float為speed
    public float jumpforce;//宣告一個float為jumpforce
    public LayerMask Ground;//宣告一個圖層變數Ground    
    
     void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        for (int x = 0; x < 2; x++)
        {
            anim[x] =this.transform.GetChild(x).GetComponent<Animator>();
        }
    }
     void FixedUpdate()
    {
        Movement();
        SwitchAnim();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && coll.IsTouchingLayers(Ground))
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
        rb.velocity =new Vector2(horizontalmove* speed * Time.deltaTime, rb.velocity.y);
            //設置剛體速度(速度乘以一個時間參數)
        anim[Maz_ID_Now].SetFloat("Running", Mathf.Abs(facedirection));
        }

        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);//設置面向的方向
        }
        
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpforce;
        anim[Maz_ID_Now].SetBool("Jumping", true);//設置動畫jumping的bool值為true
    }

    void Attack()
    {
        anim[Maz_ID_Now].SetTrigger("Attack");
    }
    void SwitchAnim() 
    {
        anim[Maz_ID_Now].SetBool("Idle", false);//設置動畫idle的bool值為flase

        if (anim[Maz_ID_Now].GetBool("Jumping"))//如果得到動畫的bool值為jumping
        {
            if (rb.velocity.y < 0)//如果rb的y軸速度<0
            {
                anim[Maz_ID_Now].SetBool("Jumping", false);
                anim[Maz_ID_Now].SetBool("Falling", true);
            }
        }
        else if (coll.IsTouchingLayers(Ground))//如果碰撞體在地面
        {
            anim[Maz_ID_Now].SetBool("Falling", false);
            anim[Maz_ID_Now].SetBool("Idle",true);
        }
      
    }
}