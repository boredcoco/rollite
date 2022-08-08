using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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

    [SerializeField] private AudioSource clicksound;

    private void Start()
    {
        allImages = new Image[]{movement, dashing, buffs, antagonist, unlockAttacks};
        currentImg = GetComponent<Image>();
    }

    public void next()
    {
      clicksound.Play();
      if (index < allImages.Length - 1)
      {
        index++;
      } else
      {
        index = 0;
      }
      currentImg.enabled = false;
      currentImg = allImages[index];
      currentImg.enabled = true;
    }

    public void back()
    {
      clicksound.Play();
      if (index != 0)
      {
        index--;
      } else
      {
        index = allImages.Length - 1;
      }
      currentImg.enabled = false;
      currentImg = allImages[index];
      currentImg.enabled = true;
    }
}
