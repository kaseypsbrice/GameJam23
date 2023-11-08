using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject player;
    UnityEngine.AI.NavMeshAgent agent;
    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;
    public Light intensityCheck;

    public float lightLevel;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = currentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        speedUpdate();
        agent.SetDestination(player.transform.position);
    }

    void speedUpdate()
    {
        lightLevel = intensityCheck.intensity;
        maxSpeed = maxSpeed + (0.01f * Time.deltaTime);
        currentSpeed = Mathf.Lerp(maxSpeed, minSpeed, lightLevel);

        agent.speed = currentSpeed;
    }

    // note, on collision, change scene to jumpscare (maybe put this in the scene manager script)
}
