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

    private bool hasShield = false;

    [SerializeField] private AudioSource healSound;
    [SerializeField] private AudioSource getHitSound;

    private void Start()
    {

      currentHealth = _health;

      paperPlane = GameObject.Find("Paper Plane");
      basicMovement = paperPlane.GetComponent<BasicMovement>();

      normal = PlaneColour.defaultColour;
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

    private void takeDamageAnimation()
    {
      getHitSound.Play();
      spriteRenderer.sprite = hit;
      Invoke("resetSprite", flashTimer);
    }

    public void loseHealth(float amount)
    {
        if (!basicMovement.isDashing)
        {
          takeDamageAnimation();
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

    public void activateShield()
    {
      hasShield = true;
    }

    public void deactivateShield()
    {
      hasShield = false;
    }

    public bool hasActiveShield()
    {
      return hasShield;
    }

}
