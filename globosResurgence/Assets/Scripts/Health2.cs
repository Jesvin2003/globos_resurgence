using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health2 : MonoBehaviour
{
    [SerializeField] private float startingHealth2;
    public float currentHealth2 { get; private set; }

    private void Awake()
    {
        currentHealth2 = startingHealth2;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth2 = Mathf.Clamp(currentHealth2 - _damage, 0, startingHealth2);

        if (currentHealth2 > 0)
        {
            //player hurt
        }
        else
        {
            //player dead
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            TakeDamage(1);
    }
}