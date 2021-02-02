using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    float X;
    float gravity = -50f;
    float radius = 0.4f;

    Vector3 velocity;

    CharacterController cC;

    bool isGrounded;

    public Transform groundCheck;

    public LayerMask platform;

    public float moveSpeed;
    public float jumpSpeed = 3;

    public bool canAttack = false;

    public BossBehaviour _bossBehaviour;

    public int health = 3;

    public GameObject enemy;
    void Start()
    {
        cC = GetComponent<CharacterController>();
    }
    void Update()
    {
        Movement();
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void Movement()
    {
        X = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * X;

        cC.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        cC.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, radius, platform);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -10f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2 * gravity);
        }
        if(transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider cd)
    {
        if(cd.gameObject.tag=="EnemyHit")
        {
            Destroy(cd.transform.parent.gameObject);
        }
        if(cd.gameObject.tag=="Bullet")
        {
            health -= 1;
            Destroy(cd.gameObject);
        }
        if (cd.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnCollisionEnter(Collision cd)
    {
        if(cd.gameObject.tag =="Boss" && canAttack)
        {
            _bossBehaviour.health -= 10;
            canAttack = false;
            Debug.Log("Attack");
        }

    }
    private void OnCollisionStay(Collision cd)
    {
        if (cd.gameObject.tag == "Boss")
        {
            canAttack = false;
        }
    }
    private void OnCollisionExit(Collision cd)
    {
        if (cd.gameObject.tag == "Boss")
        {
            canAttack = true;
        }
    }
}
