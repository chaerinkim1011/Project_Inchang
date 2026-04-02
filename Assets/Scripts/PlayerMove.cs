using UnityEngine;
using UnityEngine.Rendering;
public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    RaycastHit2D hit; //2d레이캐스트 선언
    private Rigidbody2D rb; 
    private Animator anim;

    //플래이어 능력치
    public float PlayerSpeed = 1f;
    public float PlayeJump = 15f;
    private float MaxSpeed = 10f;
    private float MaxYSpeed = 50f;
    

    //플래이어 감지 관련
    public float RaycastOffset = 0.5f; // 레이캐스트 간격
    public float RaycastDistance = 1.1f; //레이캐스트 길이
    bool IsGrounded;

    //키입력 관련
    bool Jumping;

    void Move() //x축 키입력과 x축 이동과 x,y 최대 속도 조절
    {
        float h = Input.GetAxisRaw("Horizontal"); //키입력
        Debug.Log(h);

        rb.AddForce(Vector2.right * h * PlayerSpeed, ForceMode2D.Impulse); //키 입력에 따른 이동
        //x축 최대속도
        if (rb.linearVelocity.x > MaxSpeed)
        {
            rb.linearVelocity = new Vector2(MaxSpeed, rb.linearVelocity.y);
        }
        else if (rb.linearVelocity.x < MaxSpeed * (-1))
        {
            rb.linearVelocity = new Vector2(MaxSpeed * (-1), rb.linearVelocity.y);
        }

        //y축 최대 속도
        if (rb.linearVelocity.y > MaxYSpeed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, MaxYSpeed); 
        }
    }
    
    void Start()
        //리지드 바디 선언
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Move();

        if (Jumping) //점프 실행
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * PlayeJump, ForceMode2D.Impulse);
            Jumping = false;
        }
    }
    //레이캐스트을 활용한 땅 감지
    void CheckGround()
    {
        //왼쪽끝 오른쪽 끝 변수
        Vector2 Raycastleft = new Vector2(transform.position.x - RaycastOffset, transform.position.y);
        Vector2 RaycastRight = new Vector2(transform.position.x + RaycastOffset, transform.position.y);

        //레이케스트 실행
        RaycastHit2D leftHit = Physics2D.Raycast(Raycastleft, Vector2.down, RaycastDistance, LayerMask.GetMask("Ground"));
        RaycastHit2D RightHit = Physics2D.Raycast(RaycastRight, Vector2.down, RaycastDistance, LayerMask.GetMask("Ground"));

        IsGrounded = (leftHit.collider != null || RightHit.collider != null);

        Debug.DrawRay(Raycastleft, Vector2.down * RaycastDistance, Color.red);
        Debug.DrawRay(RaycastRight, Vector2.down * RaycastDistance, Color.blue);
    }
    // Update is called once per frame
    void Update()
    {
        CheckGround();
        if (Input.GetButtonUp("Horizontal")) //관성 조절(현제 : 관성 없음)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.normalized.x * 0.5f, rb.linearVelocity.y);
        }
        if (Input.GetButtonDown("Jump") && IsGrounded) //점프 입력
        {
            Jumping = true;
        }
        Debug.Log(IsGrounded);
        
    }
}
