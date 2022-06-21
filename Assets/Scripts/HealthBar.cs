using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private GameObject _player;

    private void Start()
    {
      _healthBar.value = 1;
    }

    private void Update()
    {
        _healthBar.value = _player.GetComponent<Player_life>().getHealth();
    }
}
