using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoalCollider"))
        {
            UIController.Instance.GoalScreen.SetActive(true);
            Debug.Log("GOAL!!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
