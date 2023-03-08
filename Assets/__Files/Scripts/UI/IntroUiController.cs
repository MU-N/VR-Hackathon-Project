
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VRHackathon
{
    public class IntroUiController : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] images;
        [SerializeField]
        private string[] text;

        [Header(" Fildes ")]
        [SerializeField]
        TMP_Text textFiled;
        [SerializeField]
        Image imageFiled;


        int index = 0;
        public void CallNext()
        {
            if (index < images.Length)
            {
                imageFiled.sprite = images[++index];
                textFiled.text = text[index];
            }
        }
    }
}
