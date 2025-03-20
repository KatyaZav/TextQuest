using UnityEngine;
using UnityEngine.UI;

public class IconWithText : MonoBehaviour
{
    [field : SerializeField] public Text Text {  get; private set; }
    [field : SerializeField] public Image Icon {  get; private set; }
}
