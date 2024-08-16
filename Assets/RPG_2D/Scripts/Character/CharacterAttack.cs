using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private CharacterAnimation characterAnimation;

    public void Attack()
    {
        characterAnimation.SetTrigger("attack");
    }    
}
