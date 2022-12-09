using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup cineTargetGroup; // uses cinemacihine (quick actions refactor)

    private Camera mainCamera;
 private List<Target> targets = new List<Target>();

    private void Start()
    {
        mainCamera = Camera.main;
    }
    public Target currentTarget { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
       if( !other.TryGetComponent<Target>(out Target target)) { return; } // Adding targets that entered the targeting field
        
            targets.Add(target);
        target.OnDestroyed += RemoveTarget;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Target>(out Target target)) { return; } // removing targets that have exited the targeter field

        RemoveTarget(target);
    }

    public bool SelectTarget() // boolean for knowing if there are targets or not.
    {
        if(targets.Count == 0) { return false; } // if there is no target don't bother 

        Target closestTarget = null; // if in the loop we dont find any targets it will still be  null
        float closestTargetDistance = Mathf.Infinity; // distance from screen center to closest target, using infinity to ensure we are always finding closest target


        foreach (Target target in targets)
        {
            Vector2 viewPos = mainCamera.WorldToViewportPoint(target.transform.position); // get targets position
            if (viewPos.x < 0f || viewPos.x > 1f || viewPos.y < 0f || viewPos.y > 1f) { continue; }

            Vector2 toCenter = viewPos - new Vector2(0.5f, 0.5f);
            if(toCenter.sqrMagnitude < closestTargetDistance)
            {
                closestTarget = target;
                closestTargetDistance = toCenter.magnitude;
            }
        }

        if(closestTarget == null) { return false; }

        currentTarget = closestTarget;
        cineTargetGroup.AddMember(currentTarget.transform, 1f, 2f);

        return true;
    }

    public void Cancel()
    {
        if (currentTarget == null) { return; } // remove target from target group if already null

        cineTargetGroup.RemoveMember(currentTarget.transform);
        currentTarget = null;
    }

    private void RemoveTarget(Target target)
    {
        if (currentTarget == target) // if current target is the same as the one that got out of range then remove it from the target list
        {
            cineTargetGroup.RemoveMember(currentTarget.transform);
            currentTarget = null;
        }
        // regardless of target that was destoryed we want to unsubscribe from this event
        target.OnDestroyed -= RemoveTarget;
        targets.Remove(target);
    }
}
