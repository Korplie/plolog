using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlCont : CHMANAGER
{
    private float curtime = 0.5f;
    private float coolTime = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Body = GetComponent<CapsuleCollider2D>();
        Foot = GetComponent<BoxCollider2D>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Rigid.velocity.y >= 0 && IsGround) 
        {
            jump();

        }
       
    }
    void FixedUpdate()
    {
        
        Move();
    }
       
    
}
