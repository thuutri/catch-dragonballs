using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuController : MonoBehaviour
{
    public float speed = 50f, maxSpeed = 30f, jump = 200f;
    public bool grounded = true, faceright = true;
    public Rigidbody2D r2;
    public Animator anim;

    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            r2.AddForce(Vector2.up * jump);
        }
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
    }

    //Điều khiển goku dựa trên nguyên lý lực
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
        if (r2.velocity.x > maxSpeed)
            r2.velocity = new Vector2(maxSpeed, r2.position.y);
        if (r2.velocity.x < -maxSpeed)
            r2.velocity = new Vector2(-maxSpeed, r2.position.y);
        if (h > 0 && !faceright)
            Flip();
        if (h < 0 && faceright)
            Flip();
    }

    //Để quay ảnh Goku khi qua trái qua phải
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
