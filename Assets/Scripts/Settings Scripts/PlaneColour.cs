using UnityEngine;

public class PlaneColour : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Used by Player_life script
    public static Sprite defaultColour;

    public Sprite bluePlane;
    public Sprite pinkPlane;
    public Sprite purplePlane;

    // Start is called before the first frame update
    private void Awake()
    {
        /*
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
        */

        if (defaultColour != null)
        {
            spriteRenderer.sprite = defaultColour;
        } else
        {
            defaultColour = bluePlane;
            spriteRenderer.sprite = bluePlane;
        }
    }
}
