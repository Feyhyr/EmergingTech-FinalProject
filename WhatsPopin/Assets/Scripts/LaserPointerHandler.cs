using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR.Extras;
using System.Linq;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class LaserPointerHandler : MonoBehaviour
{
    private List<SteamVR_LaserPointer> laserPtrRefs;

    private void Awake()
    {
        laserPtrRefs = FindObjectsOfType<SteamVR_LaserPointer>().ToList(); //convert array to list

        foreach (SteamVR_LaserPointer x in laserPtrRefs)
        {
            x.PointerClick += PointerClickCallback;
        }
    }

    public void PointerClickCallback(object sender, PointerEventArgs e)
    {
        if (e.target.GetComponent<Button>() != null)
        {
            e.target.GetComponent<Button>().onClick.Invoke(); //invoke the button we just clicked
        }
    }
}