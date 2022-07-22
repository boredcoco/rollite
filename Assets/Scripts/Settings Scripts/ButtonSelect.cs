using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    [SerializeField] private Sprite selected;
    [SerializeField] private Sprite unselected;

    [SerializeField] private Button buttonOne;
    [SerializeField] private Button buttonTwo;
    [SerializeField] private Button buttonThree;

    [SerializeField] private int defaultButton;
    [SerializeField] private string setting;

    private void Start()
    {
        int currButton = PlayerPrefs.GetInt(setting, defaultButton);

        buttonSelected(currButton);

        if (currButton == 1)
        {
            buttonOne.onClick.Invoke();
        }
        else if (currButton == 2)
        {
            buttonTwo.onClick.Invoke();
        }
        else
        {
            buttonThree.onClick.Invoke();
        }
    }



    public void buttonSelected(int thisButton)
    {
        buttonOne.image.sprite = unselected;
        buttonTwo.image.sprite = unselected;
        buttonThree.image.sprite = unselected;

        if (thisButton == 1)
        {
            PlayerPrefs.SetInt(setting, 1);
            buttonOne.image.sprite = selected;
        } else if (thisButton == 2)
        {
            PlayerPrefs.SetInt(setting, 2);
            buttonTwo.image.sprite = selected;
        } else
        {
            PlayerPrefs.SetInt(setting, 3);
            buttonThree.image.sprite = selected;
        }
        
    }
}
