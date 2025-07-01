using UnityEngine;

public class RavenRotator : MonoBehaviour
{
    public void RotateBack(Raven raven)
    {
           transform.rotation = Quaternion.Lerp(transform.rotation, 
                                                   raven.MinRotation, raven.RotationSpeed * Time.deltaTime);
    }
}