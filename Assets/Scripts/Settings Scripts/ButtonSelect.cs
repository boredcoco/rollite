using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    public Sprite selected;
    public Sprite unselected;

    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonThree;

    public void buttonSelected(Button thisButton)
    {
        buttonOne.image.sprite = unselected;
        buttonTwo.image.sprite = unselected;
        buttonThree.image.sprite = unselected;

        thisButton.image.sprite = selected;
    }
}
