using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform destansion;

    public Transform GetDestination()
    {
        return destansion;
    }

}
