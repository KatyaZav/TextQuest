public class ReactivaUiFormatFabric
{
    private const string GreyColor = "#949494";
    private const string GreenColor = "#00FF1C";
    private const string RedColor = "#FF0000";

    public string GetColoredFormat(int oldValue, int newValue)
    {
        string newColor = oldValue.CompareTo(newValue) > 0 ? RedColor : GreenColor;

        return string.Format("<s><color={0}>{1}</color></s> <color={2}>{3}</color>",
            GreyColor, oldValue, newColor, newValue);
    }

    public string GetNormalFormat(int oldValue, int newValue)
    {
        return newValue.ToString();
    }
}
