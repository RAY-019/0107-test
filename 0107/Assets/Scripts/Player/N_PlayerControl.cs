using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;//宣告剛體rb
    private Animator anim;//宣告動畫anim
    private float horizontalmove;//宣告一個float為horizontalmove
    private float facedirection;//宣告一個float為facedirection
    private float vertical;

    public Collider2D coll;//宣告碰撞體coll
    public float speed;//宣告一個float為speed
    public float jumpForce;//宣告一個float為jumpforce
    public float restoretime;
    //public LayerMask Ground;//宣告一個圖層變數Ground
    private bool isGround;
    private bool isOneWayPlatForm;

    public GameObject TalkButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        DialogueSystem.isMove = true;
        TalkButton.SetActive(false);
    }
    void FixedUpdate()
    {
        Movement();
        SwitchAnim();
    }

    void Update()
    {
        CheckGround();
        OnWayPlatFormCheck();

        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        

        if (DialogueSystem.isMove == false)
        {
            rb.velocity = new Vector2(0, 0);//速度設為0,使角色無法移動
        }
        if (DialogueTrigger.isTalkButton)
        {
            TalkButton.SetActive(true);
        }
        else
        {
            TalkButton.SetActive(false);
        }

    }

    void Movement()
    {
        horizontalmove = Input.GetAxis("Horizontal");//獲取橫軸變更
        facedirection = Input.GetAxisRaw("Horizontal");//直接獲取-1,0,1獲取整數

        //角色移動
        if (horizontalmove != 0 && DialogueSystem.isMove)
        {
            rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime, rb.velocity.y);
            //設置剛體速度(速度乘以一個時間參數)
            anim.SetFloat("Running", Mathf.Abs(facedirection));
        }

        if (facedirection != 0 && DialogueSystem.isMove)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);//設置面向的方向
        }
    }

    void Jump()
    {
        if (DialogueSystem.isMove)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("Jumping", true);//設置動畫jumping的bool值為true
        }
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
        else if (isGround)//如果碰撞體在地面
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Idle", true);
        }

    }
    void CheckGround()//檢查是否在地面||平台上
    {
        isGround = coll.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
                   coll.IsTouchingLayers(LayerMask.GetMask("PlatForm"));
        isOneWayPlatForm = coll.IsTouchingLayers(LayerMask.GetMask("PlatForm"));
    }

    void OnWayPlatFormCheck()//檢查是否在平台上(為了讓玩家可以跳下平台)
    {
        vertical = Input.GetAxis("Vertical");
        if (isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        if (isOneWayPlatForm && vertical < -0.1f)
        {
            gameObject.layer = LayerMask.NameToLayer("PlatForm");
            Invoke("RestorePlayerLayer", restoretime);
        }
    }

    void RestorePlayerLayer()
    {
        if (!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }
}
