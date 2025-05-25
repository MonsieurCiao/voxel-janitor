using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float acceleration = 20f;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    public Transform groundChecker;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundChecker.position, 0.1f);
        Gizmos.color = Color.blue;
    }
    void Update()
    {
        grounded = Physics.CheckSphere(groundChecker.position, 0.1f, whatIsGround);


        MyInput();
        // SpeedControl();

        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && grounded && readyToJump)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void MovePlayer()
    {
        //direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        Vector3 targetVelocity;

        targetVelocity = moveDirection * moveSpeed;

        Vector3 currentVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        float appliedAcc = grounded ? acceleration : acceleration * airMultiplier;
        Vector3 newVelocity = Vector3.Lerp(currentVelocity, targetVelocity, appliedAcc * Time.fixedDeltaTime);

        rb.linearVelocity = new Vector3(newVelocity.x, rb.linearVelocity.y, newVelocity.z);
    }
    // private void SpeedControl()
    // {
    //     Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

    //     if (flatVel.magnitude > moveSpeed)
    //     {
    //         Vector3 limitedVelocity = flatVel.normalized * moveSpeed;
    //         rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
    //     }
    // }
    private void Jump()
    {
        //reset y vel
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce * 10, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
