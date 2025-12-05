using UnityEngine;

[CreateAssetMenu(fileName = "CinematicCameraMovementData", menuName = "Scriptable Objects/CinematicCameraMovementData")]
public class CinematicCameraMovementData : ScriptableObject
{
    [SerializeField] public AnimationCurve xMovement;
    [SerializeField] public AnimationCurve yMovement;
    [SerializeField] public AnimationCurve zMovement;
    [SerializeField] public AnimationCurve xRotation;
    [SerializeField] public AnimationCurve yRotation;
    [SerializeField] public AnimationCurve zRotation;

}
