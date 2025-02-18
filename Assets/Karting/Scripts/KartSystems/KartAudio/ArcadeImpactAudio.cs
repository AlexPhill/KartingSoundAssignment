using FMODUnity;
using UnityEngine;

namespace KartGame.KartSystems
{
    public class ArcadeImpactAudio : MonoBehaviour
    {
        ArcadeKart arcadeKart;

        float _timer = 0;
        float kartOldSpeed = 0;

        void Awake()
        {
            arcadeKart = GetComponentInParent<ArcadeKart>();
        }

        private void FixedUpdate()
        {
            _timer += Time.deltaTime;
        }

        void Update()
        {
            float kartSpeed = arcadeKart != null ? arcadeKart.LocalSpeed() : 0;
            var emitter = GetComponent<FMODUnity.StudioEventEmitter>();

            float speedDiff = kartSpeed - kartOldSpeed;

            if (_timer >= 0.2)
            {
                kartOldSpeed = kartSpeed;

                _timer = 0;
            }

            if ((speedDiff >= 0.5 || speedDiff <= -0.5) && !emitter.IsPlaying())
            {
                emitter.Play();
            }
        }
    }
}