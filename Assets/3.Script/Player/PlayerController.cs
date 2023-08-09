using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float jumpPower = 100f;
    private Rigidbody2D playerR;
    [SerializeField] public Camera cameraPos;
    private Animator ani;//Animator�� Animation �� �����ؼ� ����
    private Movement movement;// Movement ����

    public GameObject MainPlay;
    [SerializeField] private GameObject babyMario;//������ ������Ʈ ��/Ȱ��ȭ �ϱ� ����
    [SerializeField] private GameObject egg_Atk;//���� ���� ������Ʈ ��/Ȱ��ȭ �ϱ� ����
    public GameObject[] Egg_follow;//�� ������� �ϱ�

    //���� ����
    [SerializeField] public bool isRun = false;//�޸���
    public bool isJump = false;//����
    public bool isFall = false;//������
    public bool isEat = false;//���� ���� ���
    public bool isEating = false;//���� �� �ȿ� ����
    public bool isDown = false;//
    public bool isMakeEgg = false;//���� �˷� ����
    public bool isCatch = false;//���͸� ����
    public bool isYoshi = false;//�������� ������ �޾Ƽ� �������� �и�
    public bool isMario = false;//�������� �и�����
    public bool isRun_C = false;//�������� �и� �� �޸���
    public bool isAttack = false;//�� ������
    public bool isReady = false;//�� ������ �غ��ڼ�
    private int count = 1; //���Ϳ� �浹�� ������ �������� ��⵵ ���� ��ġ �ٲ�� �� �����ϱ� ����
    public int egg = 0; //�� ����
    

    private void Awake()
    {
        //�ʱ�ȭ
        playerR = transform.GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        movement = transform.GetComponent<Movement>();
    }

    void Start()//����Ƽ���� ���ڰ� �����Ǵ� ��찡 �ֱ� ������ ���⼭ �ϸ� ���߿� �ӵ� �����ϱ� ����
    {
        if (movement.moveSpeed <= 10f)
        {
            movement.moveSpeed = 2f;
        }

    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float y = Input.GetAxisRaw("Vertical");

        if (egg >= 7)
        {
            egg = 7;
        }
        isCatch = false;
        Run();//�¿�޸���       
        Jump();//���� 
        Eat();
        Down();
        Egg();
        Attack();

        movement.MoveTo(new Vector3(x, 0, 0f));

    }
   
    //�ൿ
    private void Run()
    {
        //�� ������ �ִ� falseó��
        //����
        bool condition =
        (isJump == false) &&
        (isFall == false) &&
        (isDown == false);



        if (Input.GetKey(KeyCode.A) && condition)
        {
            isRun = false;
            isRun = true;
            transform.localEulerAngles = new Vector3(0, 180, 0);//���� �����ʿ� ���� ĳ���� ���� ����
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isRun = false;
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D) && condition)
        {
            isRun = false;
            isRun = true;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isRun = false;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        ani.SetBool("Run", isRun);    
    }    

    private void Jump()
    {
        if (Input.GetKey(KeyCode.W) && (isJump == false) && (isEat == false))
        {
            isJump = true;
            isRun = false;
            if (Input.GetKey(KeyCode.A))
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            
            playerR.velocity = Vector2.zero;//���� ������ �ӵ��� ���������� ���η� ����
            playerR.AddForce(new Vector2(0, jumpPower));//�÷��̾� ������ٵ� �������� ���ֱ�

        }
        if (playerR.velocity.y <= -0.5 && isJump == true)//�������� ���� Fall �ִ� ���
        {           
            isFall = true;            
        }
        ani.SetBool("Jump", isJump);
        ani.SetBool("Fall", isFall);

    }

    private void Eat()
    {
        if (Input.GetMouseButton(0))
        {
            isJump = false;
            isFall = false;
            isEat = true;
            GetComponent<EdgeCollider2D>().isTrigger = false;

        }

        ani.SetBool("Eat", isEat);
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Ȯ��");
            isEating = true;
            ani.SetBool("Eating", isEating);
        }

        if (Input.GetMouseButtonUp(0))//�ٽ� �� edge false ó��
        {
            GetComponent<EdgeCollider2D>().isTrigger = true;

        }

        isEating = false;
        isEat = false;


    }
    private void Down()
    {
        if (Input.GetKey(KeyCode.S))
        {
            isDown = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            isDown = false;
            isMakeEgg = true;
         
            Debug.Log(egg);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isDown = false;
            isMakeEgg = false;
        }
        ani.SetBool("Down", isDown);
        ani.SetBool("MakeEgg", isMakeEgg);
    }

    void Egg()
    {
        
        if (egg == 1)
        {
            Egg_follow[0].SetActive(true);
        }
        else if (egg == 2)
        {
            Egg_follow[1].SetActive(true);
        }
        else if (egg == 3)
        {
            Egg_follow[2].SetActive(true);
        }
        else if (egg == 4)
        {
            Egg_follow[3].SetActive(true);
        }
        else if (egg == 5)
        {
            Egg_follow[4].SetActive(true);
        }
        else if (egg == 6)
        {
            Egg_follow[5].SetActive(true);
        }
        else if (egg == 7)
        {
            Egg_follow[6].SetActive(true);
        }

    }

    void Attack()//�� ������ ����
    {
        
        if (Input.GetMouseButton(1))
        {
            isReady = true;
            egg_Atk.SetActive(true);//�� ���� ����Ű�� �� ��� Ȱ��ȭ
           
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            isReady = false;
            //isAttack = true;
            
            egg_Atk.SetActive(false);
            
        }
     
        ani.SetBool("Ready", isReady);
    }

    //�浹 ó��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Map" ||
            collision.gameObject.tag == "Enemy" ||
            collision.gameObject.tag == "Step" ||
            collision.gameObject.tag == "Jumping"
            )
        {
            playerR.velocity = Vector2.zero;
            isJump = false;
            isFall = false;
            
        }

        
        if (collision.gameObject.CompareTag("Enemy") && isCatch == false)//���Ϳ� �浹
        {
            isYoshi = true;
            
            babyMario.SetActive(true);
            ani.SetBool("Yoshi", isYoshi);
            if (count == 1)
            {
                babyMario.transform.position = new Vector3(MainPlay.transform.position.x - 0.5f, MainPlay.transform.position.y + 0.5f, 0);
                count--;
            }

        }
        if (collision.gameObject.CompareTag("Mario"))//����������
        {
            babyMario.SetActive(false);
            isYoshi = false;
            ani.SetBool("Yoshi", isYoshi);
            Debug.Log("���ߴ�");

            count = 1;
        }

        //������

        if (collision.gameObject.CompareTag("Jumping"))
        {
            jumpPower = 200f;
            playerR.AddForce(new Vector2(0, jumpPower));
        }

        if (collision.gameObject.CompareTag("Jumping") && Input.GetKey(KeyCode.W))
        {
            jumpPower = 400f;
            playerR.AddForce(new Vector2(0, jumpPower));
        }


    }
    //--------------------------------------------------------------------------------
    //�浹 On / Off
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Step"))
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
        
        }

    }
    void OnTriggerExit2D(Collider2D collision )
    {
    
        if (collision.gameObject.CompareTag("Step"))
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
        }

        if (isEat == false)//�ٽ� �� edge false ó��
        {
            GetComponent<EdgeCollider2D>().isTrigger = true;

        }
       
    }

}
