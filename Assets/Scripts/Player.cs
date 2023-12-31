using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float defaultSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected int HPmax;
    protected int HP;
    [SerializeField] protected GameObject[] Hearts;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioHeal;
    [SerializeField] private AudioClip audioHurt;

    private Vector3 lastInput;

    //modif
    public GameOverDetection GameOverScreen;
    public ShakeCamera mainCamera;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 5f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;
    //

    void Awake()
    {
        HP = HPmax;
        UpdateLifeBar();
    }

    private void Update()
    {
        if (!isAlive()) return;
        //Modif
        if (isDashing) return;
        //

        //Correction de l'ordre d'affichage du sprite
        sprite.sortingOrder = (int)(-transform.position.z*100);

        //Modif
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
        //

        GetInput();
    }

    private void FixedUpdate()
    {
        if (!isAlive()) return;
        //Modif
        if (isDashing) return;
        //

        Move();
        Flip(rb.velocity.x);
        float PlayerVelocityX = Mathf.Abs(rb.velocity.x);
        float PlayerVelocityZ = Mathf.Abs(rb.velocity.z);
        animator.SetFloat("Speed", PlayerVelocityX + PlayerVelocityZ);
    }

    private void GetInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        lastInput = new Vector3(moveX, 0, moveZ).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector3(lastInput.x * defaultSpeed, 0, lastInput.z * defaultSpeed);
    }

    //Modif dash
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector3(lastInput.x * dashingPower, 0f, lastInput.z * dashingPower);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    //

    public void Hurt(int damages)
    {
        HP -= damages;
        audioSource.PlayOneShot(audioHurt);

        UpdateLifeBar();

        if (HP <= 0) Die();
        else
        {
            Debug.Log("Hit!");
            mainCamera.shake();
        }
        
    }

    public void Heal(int heal)
    {
        audioSource.PlayOneShot(audioHeal);
        HP += heal;
        if (HP > HPmax) HP= HPmax;
        UpdateLifeBar();
    }

    private void Die()
    {
        lastInput = Vector3.zero;
        Destroy(sprite.gameObject);
        StartCoroutine(WaitAndReload());
        //Modif
        GameOverScreen.Setup();
        //
    }

    private void UpdateLifeBar()
    {
        for(int i = 0; i < Hearts.Length; i++)
        {
            if (i < HP) Hearts[i].SetActive(true);
            else Hearts[i].SetActive(false);
        }
    }

    public bool isAlive()
    {
        return HP > 0;
    }

    IEnumerator WaitAndReload()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Flip(float velocityX)
    {
        if(velocityX>0.1f)
        {
            spriteRenderer.flipX= false;
        }
        else if(velocityX < -0.1f)
        {
            spriteRenderer.flipX= true;
        }
        
    }
}
