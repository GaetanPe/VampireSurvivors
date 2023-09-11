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

    private Vector3 lastInput;

    void Awake()
    {
        HP = HPmax;
        UpdateLifeBar();
    }

    private void Update()
    {
        if (!isAlive()) return;

        //Correction de l'ordre d'affichage du sprite
        sprite.sortingOrder = (int)(-transform.position.z*100);

        GetInput();
    }

    private void FixedUpdate()
    {
        if (!isAlive()) return;

        Move();
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

    public void Hurt(int damages)
    {
        HP -= damages;

        UpdateLifeBar();

        if (HP <= 0) Die();
        else Debug.Log("Hit!");
    }

    public void Heal(int heal)
    {
        HP += heal;
        if (HP > HPmax) HP= HPmax;
        UpdateLifeBar();
    }

    private void Die()
    {
        lastInput = Vector3.zero;
        Destroy(sprite.gameObject);
        StartCoroutine(WaitAndReload());
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
}
