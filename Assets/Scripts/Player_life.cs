using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_life : MonoBehaviour
{

    [SerializeField] private float _health = 10f;
    private float currentHealth;

    private GameObject paperPlane;
    private BasicMovement basicMovement;

    public SpriteRenderer spriteRenderer;
    private Sprite normal;
    public Sprite hit;
    public float flashTimer;

    [SerializeField] private AudioSource healSound;
    [SerializeField] private AudioSource getHitSound;

    private void Start()
    {

      currentHealth = _health;

      paperPlane = GameObject.Find("Paper Plane");
      basicMovement = paperPlane.GetComponent<BasicMovement>();

      normal = PlaneColour.defaultColour;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Attack" && !basicMovement.isDashing
      && collision.gameObject.GetComponent<Bullet>().isActiveBullet())
      {
            getHitSound.Play();
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
      healSound.Play();
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
        if (!basicMovement.isDashing)
        {
            if (currentHealth - amount <= 0)
            {
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Base"))
                {
                    SceneManager.LoadScene("MP Retry");
                }
                else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SinglePlayer Base"))
                {
                    SceneManager.LoadScene("SP Retry");
                }
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
