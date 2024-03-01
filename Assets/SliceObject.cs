using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public LayerMask sliceableLayer;
    public VelocityEstimator velocityEstimator;
    public Material crossMaterial;
    public float cutForce = 2000f;
    GameObject upperHull;
    GameObject lowerHull;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if (hull != null)
        {
            upperHull = hull.CreateUpperHull(target, crossMaterial);
            SetupSlicedComponent(upperHull);

            lowerHull = hull.CreateUpperHull(target, crossMaterial);
            SetupSlicedComponent(lowerHull);
            // Destroy(target);

            Invoke("DestroySlicedParts", 1f);

        }
    }

    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        slicedObject.tag = "hull";
        collider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);
    }

    private void DestroySlicedParts()
    {
        GameObject[] slicedObjects = GameObject.FindGameObjectsWithTag("hull");
        foreach (var item in slicedObjects)
        {
            Destroy(item);
        }
    }
}
