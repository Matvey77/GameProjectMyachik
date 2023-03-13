using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BallController2 : Entity
{
    [SerializeField] private float speedMove = 6f;
    [SerializeField] private float speedRotation = 3;
    [SerializeField] private int lives = 3;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int maxJumpCount = 1;
    [SerializeField] private float JumpUpdateTime = 0.3f;
    [SerializeField] private float divingForce = 10f;

    private int jumpCount;
    private bool isGrounded = false;

    private bool isLoaded = false;

    private float moveInput;
    private float moveInput2;
    private float moveInput3;

    private bool flagJumpUpdate = true;

    public Transform groundCheck;
    public float checkDistanseToGround;
    public LayerMask whatIsGround;
    public LayerMask whatIsGround2;

    public Joystick joystick;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public static BallController2 Instance { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        jumpCount = maxJumpCount;

        Instance = this;
    }

    private void FixedUpdate()
    {
        CheckGround();

        moveInput = joystick.Horizontal;
        moveInput2 = Input.GetAxis("Horizontal");
        moveInput3 = joystick.Vertical;

    }

    private void Update()
    {
        if (moveInput != 0 || moveInput2 != 0) 
        {
            Run();
        }

        if (((Input.GetAxis("Vertical") < -0.1) || (moveInput3 < 0)) && (isLoaded == true))
        {
            Diving();
        }


        if (Input.GetButtonDown("Jump") && (jumpCount > 0))
        {
            jumpCount--;
            Jump();
        }

        if (isGrounded == true && (jumpCount <= 0) && flagJumpUpdate == true)
        {
            flagJumpUpdate = false;
            StartCoroutine(UpdateJumpCount());
            UpdateJumpCount();
        }

        if ((lives < 1 || transform.position.y < -20))
        {
            Die();
        }
            
    }

    private IEnumerator UpdateJumpCount()
    {
        yield return new WaitForSeconds(JumpUpdateTime);
        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }
        flagJumpUpdate = true;
    }

    private void Run()
    {
        rb.AddForce(new Vector2(moveInput * speedMove * Time.deltaTime * 300, 0f), ForceMode2D.Impulse);
        rb.AddForce(new Vector2(moveInput2 * speedMove * Time.deltaTime * 300, 0f), ForceMode2D.Impulse);

        //transform.position += new Vector3(moveInput, 0, 0) * speedMove * Time.deltaTime;

        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.z -= moveInput * speedRotation * Time.deltaTime * 100;
        rotation.z -= moveInput2 * speedRotation * Time.deltaTime * 100;
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void Diving()
    {
        rb.AddForce(Vector2.down * divingForce * Time.deltaTime * 250);
    }

    private void Jump()
    {
         rb.AddForce(Vector2.up * jumpForce * Time.deltaTime * 225, ForceMode2D.Impulse);
        //rb.velocity = Vector2.up * jumpForce;
        //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    public void JumpOnButton()
    {
        if ((jumpCount > 0))
        {
            jumpCount--;
            Jump();
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position,
                                             checkDistanseToGround, whatIsGround);
        isLoaded = Physics2D.OverlapCircle(groundCheck.transform.position,
                                             checkDistanseToGround, whatIsGround2);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck.transform.position,
                              checkDistanseToGround);
    }

    public override void GetDamage()
    {
        lives -= 1;
        Debug.Log("∆изнь м€чика = " + lives);
    }

}
