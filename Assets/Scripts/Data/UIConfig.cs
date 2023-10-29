using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(fileName = "UIConfig", menuName = "Configs/UI Config")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private AssetReferenceGameObject loadingScreen;
        [SerializeField] private AssetReferenceGameObject startScreen;
        [SerializeField] private AssetReferenceGameObject gamePlayScreen;
        [SerializeField] private AssetReferenceGameObject win;
        [SerializeField] private AssetReferenceGameObject lose;

        public AssetReferenceGameObject LoadingScreen => loadingScreen;
        public AssetReferenceGameObject StartScreen => startScreen;
        public AssetReferenceGameObject GamePlayScreen => gamePlayScreen;
        public AssetReferenceGameObject Win => win;
        public AssetReferenceGameObject Lose => lose;
    }
}