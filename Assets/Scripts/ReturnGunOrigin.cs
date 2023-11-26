using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnGunOrigin : MonoBehaviour
{
    [SerializeField] private Pose originPose;

    private XRGrabInteractable grabInteractable;

    private void Awake() 
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        originPose.position = transform.position;
        originPose.rotation = transform.rotation;
    }

    private void OnEnable() => grabInteractable.selectExited.AddListener(HandleLaserGunReleased);

    private void OnDisable() => grabInteractable.selectExited.RemoveListener(HandleLaserGunReleased);

    private void HandleLaserGunReleased(SelectExitEventArgs arg0)
    {
        Invoke(nameof(LasserGunRelease), 1f);
    }

    private void LasserGunRelease()
    {
        transform.position = originPose.position;
        transform.rotation = originPose.rotation;
    }
}
