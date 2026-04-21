using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeController : MonoBehaviour
{


    public MainInputSystem _controls;
    public float minimumSwipeMag = 10f;
    private Vector2 _swipeDirection;
    public GameObject player;
    public float _sideMove;
    void Start()
    {

        _controls = new MainInputSystem();
        _controls.Player.Enable();

        _controls.Player.Touch.canceled += ProcessTouchComplete;
        _controls.Player.Swipe.performed += ProcessSwipeDelta;
        _controls.Player.Move.performed += ProcessMove;


    }

    void ProcessSwipeDelta(InputAction.CallbackContext ctx)
    {

        _swipeDirection = ctx.ReadValue<Vector2>();

    }
    void ProcessMove(InputAction.CallbackContext ctx)
    {

        var val = ctx.ReadValue<float>();

        if (val > 0)
        {
            player.transform.position += new Vector3(4, 0, 0);
        }
        if (val < 0)
        {
            player.transform.position += new Vector3(-4, 0, 0);
        }

    }
    void ProcessTouchComplete(InputAction.CallbackContext ctx)
    {

        Debug.Log("Touch Complete");
        if (Mathf.Abs(_swipeDirection.magnitude) < minimumSwipeMag) return;
        Debug.Log("Swipe Detected");
        Debug.Log(_swipeDirection);



        if (_swipeDirection.x > 0)
        {
            // right
            player.transform.position += new Vector3(4, 0, 0);
        }
        if (_swipeDirection.x < 0)
        {
            player.transform.position += new Vector3(-4, 0, 0);
            // left
        }




    }



    void Update()
    {


        // print(_sideMove);

    }
}
