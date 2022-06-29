using UnityEngine;

public class PlaneColour : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public static Sprite defaultColour;

    public Sprite bluePlane;
    public Sprite pinkPlane;
    public Sprite purplePlane;

    // Start is called before the first frame update
    void Start()
    {
        //Set Colour
        if (BGColour.background == SettingsManager.firstColour)
        {
            defaultColour = bluePlane;
            spriteRenderer.sprite = bluePlane;

        }
        else if (BGColour.background == SettingsManager.secondColour)
        {
            defaultColour = pinkPlane;
            spriteRenderer.sprite = pinkPlane;
        }
        else
        {
            defaultColour = purplePlane;
            spriteRenderer.sprite = purplePlane;
        }
    }
}
