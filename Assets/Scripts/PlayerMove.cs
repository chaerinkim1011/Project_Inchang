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
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); //키입력
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse); //키 입력에 따른 이동
        if (rb.linearVelocity.x > MaxSpeed) //오른쪽 최대속도 조절
        {
            rb.linearVelocity = new Vector2(MaxSpeed, rb.linearVelocity.y);
        }
        else if (rb.linearVelocity.x < MaxSpeed * (-1))
        {
            rb.linearVelocity = new Vector2(MaxSpeed * (-1), rb.linearVelocity.y);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
