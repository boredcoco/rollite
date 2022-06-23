using UnityEngine;

public class PlaneColour : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite bluePlane;
    public Sprite pinkPlane;
    public Sprite purplePlane;

    // Start is called before the first frame update
    void Start()
    {

        //Set Colour
        if (BGColour.background == SettingsManager.firstColour)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("All Prefabs/Planes/Paper_Plane_Blue");

        }
        else if (BGColour.background == SettingsManager.secondColour)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("All Prefabs/Planes/Paper_Plane_Pink");
            Debug.Log(Resources.Load<Sprite>("All Prefabs/Planes/Paper_Plane_Pink"));
        }
        else
        {
            spriteRenderer.sprite = purplePlane;
        }
    }

    void Update()
    {
        
        //Set Colour
        if (BGColour.background == SettingsManager.firstColour)
        {
            spriteRenderer.sprite = pinkPlane;
        }
        else if (BGColour.background == SettingsManager.secondColour)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("All Prefabs/Planes/Paper_Plane_Pink");
            Debug.Log("pink2");
        }
        else
        {
            spriteRenderer.sprite = purplePlane;
        }
       
    }
}
