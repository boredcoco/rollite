using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_life : MonoBehaviour
{
    [SerializeField] private float _animSpeed = 5f;

    [SerializeField] private float _health = 10f;
    private float currentHealth;

    private GameObject paperPlane;
    private BasicMovement basicMovement;
    private bool isDashing = false;


    //animate hit motion
    private Animator anim;

    private void Start()
    {
      anim = GetComponent<Animator>();
      anim.ResetTrigger("isHit");
      anim.SetFloat("speed", _animSpeed);

      currentHealth = _health;

      paperPlane = GameObject.Find("Paper Plane");
      basicMovement = paperPlane.GetComponent<BasicMovement>();
      isDashing = basicMovement.isDashing;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Attack" && !isDashing)
      {
        anim.SetTrigger("isHit");
      }
    }

    public void heal(float amount)
    {
      if (currentHealth + amount > _health)
      {
        currentHealth = _health;
      } else
      {
        currentHealth = currentHealth + amount;
      }
      Debug.Log(currentHealth);
    }

    public void loseHealth(float amount)
    {
        if (!isDashing)
        {
            if (currentHealth - amount <= 0)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                currentHealth = currentHealth - amount;
            }
        }

      Debug.Log("player health:" + currentHealth);
    }

    public float getHealth()
    {
      return currentHealth / _health;
    }

}
