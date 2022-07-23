using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Images : MonoBehaviour
{
    [SerializeField] private Image movement;
    [SerializeField] private Image dashing;
    [SerializeField] private Image buffs;
    [SerializeField] private Image antagonist;
    [SerializeField] private Image unlockAttacks;

    private Image[] allImages;
    private int index = 0;

    private Image currentImg;

    private void Start()
    {
        allImages = new Image[]{movement, dashing, buffs, antagonist, unlockAttacks};
        currentImg = GetComponent<Image>();
    }

    public void next()
    {
      if (index < allImages.Length - 1)
      {
        index++;
        currentImg.enabled = false;
        currentImg = allImages[index];
        currentImg.enabled = true;
      }
    }

    public void back()
    {
      if (index != 0)
      {
        index--;
        currentImg.enabled = false;
        currentImg = allImages[index];
        currentImg.enabled = true;
      }
    }
}
