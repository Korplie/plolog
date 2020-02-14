using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHMANAGER : MonoBehaviour
{
    public float Speed;
    public float JumpP;

    protected bool IsGround = true;

    protected Rigidbody2D Rigid;
    protected CapsuleCollider2D Body;
    protected BoxCollider2D Foot;
    protected Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    protected void jump()
    {
        IsGround = false;
        
            Vector2 jumpVelocity = new Vector2(0, JumpP);
            Rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
      


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && Rigid.velocity.y < 0) 
        {

                IsGround = true;
              
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 8)
    //    {
    //        if (Rigid.velocity.y < 0)
    //        {
    //            IsGround = true;
    //        }
    //    }
    //}
    protected float GatAngle(Vector2 start, Vector2 end)
    {
        Vector2 v2 = end - start;
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
      
    }
    protected void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (Rigid.velocity.y >= 5.5f)
        {
            Rigid.velocity = new Vector2(0f, 0f);
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        transform.position += moveVelocity * Speed * Time.deltaTime;
    }
   

}
