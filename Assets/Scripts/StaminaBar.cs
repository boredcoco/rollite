using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
  [SerializeField] private Slider _StaminaBar;
  [SerializeField] private GameObject _player;

  private void Start()
  {
    _StaminaBar.value = 1;
  }


    private void Update()
    {
        _StaminaBar.value = _player.GetComponent<BasicMovement>().getCurrStamina();
    }
}
