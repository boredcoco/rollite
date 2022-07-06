using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_life : MonoBehaviour
{

    [SerializeField] private float _health = 10f;
    private float currentHealth;

    private GameObject paperPlane;
    private BasicMovement basicMovement;
    private bool isDashing = false;

    public SpriteRenderer spriteRenderer;
    private Sprite normal;
    public Sprite hit;
    public float flashTimer;

    private void Start()
    {

      currentHealth = _health;

      paperPlane = GameObject.Find("Paper Plane");
      basicMovement = paperPlane.GetComponent<BasicMovement>();
      isDashing = basicMovement.isDashing;

      normal = PlaneColour.defaultColour;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Attack" && !isDashing
      && collision.gameObject.GetComponent<Bullet>().isActiveBullet())
      {
            spriteRenderer.sprite = hit;
            Invoke("resetSprite", flashTimer);
        }
    }

    private void resetSprite()
    {
        spriteRenderer.sprite = normal;
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
