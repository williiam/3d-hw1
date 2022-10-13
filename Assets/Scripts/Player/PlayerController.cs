using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    private Animator myAnimator;
    public Sprite[] sprites;
    public float jumpAmount = 35f;
    public float dashAmount = 0.6f;
    public float jumpDashAmount = 0.1f;
    public float gravityScale = 30f;
    public float fallingGravityScale = 80f;

    public float buttonTime = 0.5f;
    public float jumpHeight = 5;
    public float cancelRate = 100;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;

    public ScoreTextController scoreTextController;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if(jumping){
                rb.velocity += new Vector2(jumpDashAmount, 0f);
            }
            rb.velocity += new Vector2(dashAmount, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            if(jumping){
                rb.velocity += new Vector2(-jumpDashAmount, 0f);
            }
            rb.velocity += new Vector2(-dashAmount, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }

        if(rb.velocity.y > 0)
        {
            // 往上跳
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            // 落下 或 在地上
            rb.gravityScale = fallingGravityScale;
        }
    }

    private void FixedUpdate()
    {
        if(jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("玩家觸發！");

        if (other.tag == "FLOOR") {
            return;
        }

        if (other.tag == "MACE") {
            Debug.Log("MACE trigger!");
            other.gameObject.SetActive(false);
            scoreTextController.MinusScoreAndDisplay();
            return;
        }

        if (other.tag == "RIVER") {
            Debug.Log("RIVER trigger!");
            other.gameObject.SetActive(false);
            scoreTextController.handleDropRiver();
            return;
        }

        if (other.tag == "COIN") {
            Debug.Log("COIN trigger!");
            other.gameObject.SetActive(false);
            scoreTextController.AddScoreAndDisplay();
        }
    }
}
