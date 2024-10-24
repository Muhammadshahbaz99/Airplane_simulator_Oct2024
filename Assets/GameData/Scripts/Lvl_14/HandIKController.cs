using UnityEngine;

public class HandIKController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public Transform rightHandTarget; // Target for the right hand
    public Transform leftHandTarget;  // Target for the left hand
    [Range(0, 1)] public float rightHandIKWeight = 1.0f; // IK weight for right hand
    [Range(0, 1)] public float leftHandIKWeight = 1.0f;  // IK weight for left hand

    void OnAnimatorIK(int layerIndex)
    {
        // Right hand IK
        if (rightHandTarget != null)
        {
            // Set the position and rotation of the right hand based on the target
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandIKWeight);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandIKWeight);
            animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
        }

        // Left hand IK
        if (leftHandTarget != null)
        {
            // Set the position and rotation of the left hand based on the target
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandIKWeight);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandIKWeight);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
        }
    }
}
