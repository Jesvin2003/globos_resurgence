using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtmosHealthbar : MonoBehaviour
{ 
    [SerializeField] private Health2 playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    // Start is called before the first frame update
    void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth2 / 10;
    }

    // Update is called once per frame
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth2 / 10;
    }
}
