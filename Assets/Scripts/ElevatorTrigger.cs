using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public ElevatorLerp elevator;

    private void OnTriggerEnter(Collider other)
    {
        elevator.ActivateElevator();
        other.gameObject.transform.parent = this.gameObject.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
        //elevator.ActivateElevator();
    }
}
