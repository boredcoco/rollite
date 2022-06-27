using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSelector : MonoBehaviour
{
    [SerializeField] private GameObject _attack1;
    [SerializeField] private GameObject _attack2;
    [SerializeField] private GameObject _attack3;
    [SerializeField] private GameObject _attack4;
    [SerializeField] private GameObject _attack5;

    private string currSelectedCode = "";

    public bool attackSelected()
    {
      return currSelectedCode == "";
    }

    public void selectAttackType(string attackType)
    {
      turnOffPreviousAttack(currSelectedCode);
      if (currSelectedCode != attackType)
      {
        currSelectedCode = attackType;

        if (attackType == "attack1")
        {
          _attack1.GetComponent<Image>().color = Color.red;
          _attack1.GetComponent<AttackControl_individual>().setSelect(true);
        } else if (attackType == "attack2")
        {
          _attack2.GetComponent<Image>().color = Color.red;
          _attack2.GetComponent<AttackControl_individual>().setSelect(true);
        } else if (attackType == "attack3")
        {
          _attack3.GetComponent<Image>().color = Color.red;
        } else if (attackType == "attack4")
        {
          _attack4.GetComponent<Image>().color = Color.red;
        } else if (attackType == "attack5")
        {
          _attack5.GetComponent<Image>().color = Color.red;
        }
      } else
      {
        currSelectedCode = "";
      }

    }

    private void turnOffPreviousAttack(string attackType){
      if (attackType == "attack1")
      {
        _attack1.GetComponent<Image>().color = Color.white;
        _attack1.GetComponent<AttackControl_individual>().setSelect(false);
      } else if (attackType == "attack2")
      {
        _attack2.GetComponent<Image>().color = Color.white;
        _attack2.GetComponent<AttackControl_individual>().setSelect(false);
      } else if (attackType == "attack3")
      {
        _attack3.GetComponent<Image>().color = Color.white;
      } else if (attackType == "attack4")
      {
        _attack4.GetComponent<Image>().color = Color.white;
      } else if (attackType == "attack5")
      {
        _attack5.GetComponent<Image>().color = Color.white;
      }
    }

}
