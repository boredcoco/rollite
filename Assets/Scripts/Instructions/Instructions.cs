using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Instructions : MonoBehaviour
{
    [SerializeField] private string movement = "Use WASD keys to Move Plane around. If you go out of the screen boundaries, you will be transported to the other boundary of the playing field. Try going to the edges of the screen.";
    [SerializeField] private string dashing = "Dodge attacks launched at you, or press the 'space' key to dash through attacks. Remember that dahsing depletes Player Stamina, which will regenerate over time.";
    [SerializeField] private string buffs = "Buffs are power-ups that spawn randomly on the map. They activate when you come into contact with them. Each buff has a different effect on you and your opponent. Try activating them to see the effects.";
    [SerializeField] private string antagonist = "In SinglePlayer mode, the Antagonist will spawn attacks and try to get as close to you as it can. In Multiplayer mode, your friend does the attacking, click on the left side panel to select an attack. Once selected, click on where you would like to place the attack on the map.";
    [SerializeField] private string unlockAttacks = "All attacks except the Spike attack are locked at first, attacks unlock as the Antagonist levels up and when the Player's score increases.";

    private string[] allWords;
    private int index = 0;

    private TMP_Text txt;

    [SerializeField] private AudioSource clicksound;

    private void Start()
    {
      txt = GetComponent<TMP_Text>();
      allWords = new string[]{movement, dashing, buffs, antagonist, unlockAttacks};
      txt.text = allWords[index];
    }

    public void next()
    {
      clicksound.Play();
      if (index < allWords.Length - 1)
      {
        index++;
      } else
      {
        index = 0;
      }
      txt.text = allWords[index];
    }

    public void back()
    {
      clicksound.Play();
      if (index != 0)
      {
        index--;
      } else
      {
        index = allWords.Length - 1;
      }
      txt.text = allWords[index];
    }
}
