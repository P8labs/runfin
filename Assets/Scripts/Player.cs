using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{


    private Rigidbody2D rb;
    private Animator anim;
    public MainInputSystem _controls;
    public float minimumSwipeMag = 10f;
    private Vector2 _swipeDirection;

    public float FwdSpeed;
    private int lane = 1;
    public float laneDistance = 4f;


    private Vector2 direction;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _controls = new MainInputSystem();
        _controls.Player.Enable();

        _controls.Player.Touch.canceled += ProcessTouchComplete;
        _controls.Player.Swipe.performed += ProcessSwipeDelta;
        _controls.Player.Move.performed += ProcessMove;

        anim.SetBool("Walking", true);
    }

    void Update()
    {
        direction.y = FwdSpeed;
        Vector2 targetPos = transform.position.x * transform.forward + transform.position.y * transform.up;

        if (lane == 0) { targetPos += Vector2.left * laneDistance; }
        else if (lane == 2) { targetPos += Vector2.right * laneDistance; }
        transform.position = targetPos;



    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, FwdSpeed * 1);

    }

    void ProcessSwipeDelta(InputAction.CallbackContext ctx)
    {

        _swipeDirection = ctx.ReadValue<Vector2>();

    }
    void ProcessMove(InputAction.CallbackContext ctx)
    {

        var val = ctx.ReadValue<float>();

        if (val > 0) { MoveRight(); }
        if (val < 0) { MoveLeft(); }

    }
    void ProcessTouchComplete(InputAction.CallbackContext ctx)
    {

        if (Mathf.Abs(_swipeDirection.magnitude) < minimumSwipeMag) return;

        if (_swipeDirection.x > 0) { MoveRight(); }
        if (_swipeDirection.x < 0) { MoveLeft(); }




    }


    void MoveRight()
    {
        lane++;
        if (lane == 3) { lane = 2; }
    }
    void MoveLeft()
    {
        lane--;
        if (lane == -1) { lane = 0; }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("obstacle"))
        {
            GameManager.GAME_OVER = true;
        }
    }





}
