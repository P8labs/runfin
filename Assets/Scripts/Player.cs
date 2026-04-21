using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{


    public float Speed;
    public float sideSpeed;
    public InputActionReference move;
    public float _sideMove;
    public GameObject floorPrefab;


    private Animator Anim;
    private CharacterController Ctrl;

    private Vector3 MoveDirection = Vector3.zero;
    private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
    private static readonly int MoveState = Animator.StringToHash("Base Layer.move");




    void Start()
    {
        Anim = GetComponent<Animator>();
        Ctrl = GetComponent<CharacterController>();
    }



    void Update()
    {
        // _sideMove = move.action.ReadValue<float>();
    }

    void FixedUpdate()
    {

        // MOVE_Velocity(new Vector3(0, 0, Speed), new Vector3(0, 0, 0));
        MOVE();


    }

    private void MOVE()
    {
        KEY_DOWN();
        if (_sideMove != 0)
        {
            MOVE_Velocity(new Vector3(sideSpeed * _sideMove, 0, 0), new Vector3(0, 15 * _sideMove, 0));
        }
        KEY_UP();
    }

    private void KEY_DOWN()
    {

        if (_sideMove != 0)
        {
            Anim.CrossFade(MoveState, 0.1f, 0, 0);
        }
    }
    private void KEY_UP()
    {


        if (_sideMove == 0)
        {
            Anim.CrossFade(IdleState, 0.1f, 0, 0);
        }
    }




    private void MOVE_Velocity(Vector3 velocity, Vector3 rot)
    {
        MoveDirection = new Vector3(velocity.x, MoveDirection.y, velocity.z);
        if (Ctrl.enabled)
        {
            Ctrl.Move(MoveDirection * Time.deltaTime);
        }
        MoveDirection.x = 0;
        MoveDirection.z = 0;
        this.transform.rotation = Quaternion.Euler(rot);
    }



}
