using UnityEngine;
using UnityEngine.UI;

public class UnlockAttack : MonoBehaviour
{
    private Button currButton;

    [SerializeField] private int _unlockScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        currButton = GetComponent<Button>(); 
        currButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (HighScore.timer >= _unlockScore)
        {
            currButton.interactable = true;
        }
    }
}
