using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackStamina : MonoBehaviour
{
    [SerializeField] private GameObject _attackSelector;
    [SerializeField] private Slider _StaminaBar;

    [SerializeField] private float _regenStaminaSpeed = 0.1f;
    [SerializeField] private float _maxStamina = 10f;

    private float currentStamina;

    private void Start()
    {
      _StaminaBar.value = 1;
      currentStamina = _maxStamina;
    }

    public void Update()
    {
      regenStamina();
      _StaminaBar.value = currentStamina /_maxStamina;
    }

    public bool canAttack(float bp)
    {
      return currentStamina >= bp;
    }

    public void depleteStamina(float bp)
    {
      currentStamina -= bp;
    }

    public void debuffStamina()
    {
      currentStamina = 0.0f;
    }

    private void regenStamina()
    {
      if (!Quit.quitting && currentStamina < _maxStamina)
      {
        currentStamina = currentStamina + (_regenStaminaSpeed) * Time.deltaTime;
      }
      if (currentStamina > _maxStamina) {
        currentStamina = _maxStamina;
      }
    }
}
