using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health_player;
    // Start is called before the first frame update
    void Start()
    {
        health_player = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health_player > 0)
        {
            Debug.Log("Player Hidup");
        }
        else
        {
            Debug.Log("Player Mati");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            health_player -= 20f;
            Debug.Log("Health =" + health_player);
        }

        if (other.tag == "Enemy")
        {
            health_player -= 40f;
        }
    }
}
