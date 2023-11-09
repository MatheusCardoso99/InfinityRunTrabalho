using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update


    public float speed = 0f;
    public bool isGrouded = true;
    public float jumpForce = 650f;

    private Animator anim;
    private Rigidbody2D rig;

    public LayerMask LayerGroud;
    public Transform checkGround;
    public string isGroudBool = "eChao";
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        MovimentaPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))//Seta pra cima precionada
        {
            Jump();
        }
    }

    private void MovimentaPlayer()
    {
        transform.Translate(new Vector3(speed, 0, 0));
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0));

        if (Physics2D.OverlapCircle(checkGround.transform.position, 0.2f, LayerGroud))
        {
            anim.SetBool(isGroudBool, true);
            isGrouded = true;
        }
        else
        {
            anim.SetBool(isGroudBool, false);
            isGrouded = false;
        }
    }

    public void Jump()
    {
        if (isGrouded)
        {
            rig.velocity = Vector2.zero;
            rig.AddForce(new Vector2(0, jumpForce));
        }
    }
}
