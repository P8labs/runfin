using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector2 offset;


    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {


        Vector3 pos = new(transform.position.x, offset.y + player.position.y, -1);
        transform.position = pos;

    }
}
