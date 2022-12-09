using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject weaponLogic;
    [SerializeField] private GameObject LeftHandLogic;
    [SerializeField] private GameObject RightHandLogic;
    [SerializeField] private GameObject LeftLegLogic;
    [SerializeField] private GameObject RightLegLogic;
    [SerializeField] private GameObject HeadLogic;
    
    //Weapon enable
    public void EnableWeapon()
    {
        weaponLogic.SetActive(true);
    }

    public void DisableWeapon()
    {
        weaponLogic.SetActive(false);
    }

    // Enable Hands
    public void EnableRightHand()
    {
        RightHandLogic.SetActive(true);
    }

    public void DisableRighttHand()
    {
        RightHandLogic.SetActive(false);
    }

   
    public void EnableLeftHand()
    {
       LeftHandLogic.SetActive(true);
    }

    public void DisableLeftHand()
    {
       LeftHandLogic.SetActive(false);
    }

    // Enable legs
    public void EnableRightLeg()
    {
        RightLegLogic.SetActive(true);
    }

    public void DisableRightLeg()
    {
        RightLegLogic.SetActive(false);
    }

    public void EnableLeftLeg()
    {
        LeftLegLogic.SetActive(true);
    }

    public void DisableLeftLeg()
    {
        LeftLegLogic.SetActive(false);
    }

    public void EnableLeHead()
    {
        HeadLogic.SetActive(true);
    }

    public void DisableHead()
    {
        HeadLogic.SetActive(false);
    }

}
