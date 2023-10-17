using TMPro;
using UnityEngine;

namespace UIs
{
    public class NicknameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nicknameText;

        public void SetNickname(string nickName) => nicknameText.text = nickName;

        public void Show() => nicknameText.gameObject.SetActive(true);

        public void Hide() => nicknameText.gameObject.SetActive(false);
    }
}