using UnityEngine;

/// <summary>
/// This class inherits from TargetObject and represents a LapObject.
/// </summary>
public class LapObject : TargetObject
{
    [Header("LapObject")]
    [Tooltip("Is this the first/last lap object?")]
    public bool finishLap;

    [HideInInspector]
    public bool lapOverNextPass;

    void Start() {
        Register();
    }
    
    void OnEnable()
    {
        lapOverNextPass = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Component[] components = other.GetComponents(typeof(Component));
        // foreach(Component component in components) {
        //     Debug.Log(component.ToString());
        // }
        if(other.CompareTag("P1")) {
            Destroy(gameObject.GetComponent("MeshFilter"));
        }

        // Debug.Log(other.gameObject.tag);
        // Debug.Log(other.gameObject.GetComponent("KartBouncingCapsule"));
        // var collider = other.gameObject.GetComponent<CapsuleCollider>() as Collider;
        // Debug.Log(collider.gameObject.layer);
        // Debug.Log(gameObject);
        // Debug.Log(k);
        if (!((layerMask.value & 1 << other.gameObject.layer) > 0 && other.CompareTag("Player")))
            return;

        Objective.OnUnregisterPickup?.Invoke(this);
    }
}
