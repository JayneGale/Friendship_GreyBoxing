using UnityEngine;

public class DrawGizmo : MonoBehaviour {
    [SerializeField]
    protected float gizmoRadius = 1.0f;

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
    }
}
