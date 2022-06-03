using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_life : MonoBehaviour
{
    [SerializeField] public float _health = 10f;
    private float currentHealth;

    //animate hit motion
    private Animator anim;

    private void Start()
    {
      anim = GetComponent<Animator>();
      anim.ResetTrigger("isHit");
      currentHealth = _health;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Attack")
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
      if (currentHealth - amount <= 0)
      {
            SceneManager.LoadScene(2);
      } else
      {
        currentHealth = currentHealth - amount;
      }
      Debug.Log("player health:" + currentHealth);
    }

}
