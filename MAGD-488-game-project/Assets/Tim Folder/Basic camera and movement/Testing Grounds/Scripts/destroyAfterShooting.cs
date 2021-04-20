using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterShooting : MonoBehaviour
{
    CharacterManager characterCastingSpell;

    private void Awake()
    {
        characterCastingSpell = GetComponentInParent<CharacterManager>();
    }

    void Update()
    {
        if (characterCastingSpell.isFiring)
        {
            Destroy(gameObject);
        }
    }
}
