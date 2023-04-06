using UnityEngine;

public class TriggerForPulling : MonoBehaviour
{
    [SerializeField] private PullingPreset pulling;
    private void OnTriggerEnter(Collider other) => pulling.Generate();
}