using UnityEngine;
using UnityEngine.Rendering;
public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    public float PleyerSpeed = 1f;
    public float PleyeJump = 1f;
    private float MaxSpeed = 10f;
    private float MaxJump = 15f;
    Vector3 PleyerVector;
    private void Move()
    {
        Vector3 MoveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            
        }
    }
    private void Jump()
    {

    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
        Jump();
    }
    void Update()
    {
    }
}
