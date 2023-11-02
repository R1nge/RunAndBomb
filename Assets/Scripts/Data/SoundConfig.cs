using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/Sound Config")]
    public class SoundConfig : ScriptableObject
    {
        [SerializeField] private AssetReferenceT<AudioClip> clickSound;
        [SerializeField] private List<AssetReferenceT<AudioClip>> deathSounds;
        [SerializeField] private List<AssetReferenceT<AudioClip>> explosionSounds;

        public AssetReferenceT<AudioClip> ClickSound => clickSound;
        public List<AssetReferenceT<AudioClip>> DeathSounds => deathSounds;
        public List<AssetReferenceT<AudioClip>> ExplosionSounds => explosionSounds;
    }
}