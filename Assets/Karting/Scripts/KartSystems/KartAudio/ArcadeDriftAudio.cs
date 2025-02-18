using FMODUnity;
using UnityEngine;

namespace KartGame.KartSystems
{
    /// <summary>
    /// This class produces audio for various states of the vehicle's movement.
    /// </summary>
    public class ArcadeDriftAudio : MonoBehaviour
    {
        ArcadeKart arcadeKart;

        void Awake()
        {
            arcadeKart = GetComponentInParent<ArcadeKart>();
        }

        void Update()
        {
            bool kartDrift = arcadeKart != null ? arcadeKart.IsDrifting : true;
            var emitter = GetComponent<FMODUnity.StudioEventEmitter>();

            if (kartDrift && !emitter.IsPlaying())
            {                 
                emitter.Play();
            }

            else if (!kartDrift)
            {
                emitter.Stop();
            }
        }
    }
}