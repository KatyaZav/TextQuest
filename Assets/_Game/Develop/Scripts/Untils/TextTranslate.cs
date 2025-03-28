using UnityEngine;

namespace Assets.Untils
{
    [System.Serializable]
    public class TextTranslate
    {
        [field: SerializeField] public string Russian { get; private set; }
        [field: SerializeField] public string English { get; private set; }

        public string GetText(string language)
        {
            switch (language)
            {
                case "en":
                    return English;
                case "ru":
                    return Russian;
                default:
                    throw new System.Exception("Language not found");
            }
        }
    }
}
