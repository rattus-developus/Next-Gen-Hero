using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager Instance;
    public List<Transform> waypoints = new List<Transform>();
    bool waypointsHidden;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)) ToggleWaypointVisibility(waypointsHidden);
    }

    void ToggleWaypointVisibility(bool on)
    {
        UIManager.Instance.SetWaypointMode(on);
        waypointsHidden = !on;

        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = on;
            transform.GetChild(i).GetChild(0).GetComponent<Canvas>().enabled = on;
        }
    }
}
