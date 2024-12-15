using UnityEngine;

public class sFacePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    Transform player= GameObject.Find("Player").transform;

        transform.LookAt(player);
    }
}
