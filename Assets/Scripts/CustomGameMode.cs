using UnityEngine;
using UnityEngine.UI;

public class CustomGameMode : MonoBehaviour
{
    
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Toggle toggle4;
    public Toggle toggle5;
    public Toggle toggle6;
    public Toggle toggle7;

    public void SaveFigures()
    {
        DataStorage.ClearValue();
        if (toggle1.isOn)
            DataStorage.AddValue(1);
        if (toggle2.isOn)
            DataStorage.AddValue(2);
        if (toggle3.isOn)
            DataStorage.AddValue(3);
        if (toggle4.isOn)
            DataStorage.AddValue(4);
        if (toggle5.isOn)
            DataStorage.AddValue(5);
        if (toggle6.isOn)
            DataStorage.AddValue(6);
        if (toggle7.isOn)
            DataStorage.AddValue(7);

        if(DataStorage.IsNull())
        {
            Debug.LogWarning("values=null");
            DataStorage.AddValue(1);
            DataStorage.AddValue(2);
            DataStorage.AddValue(3);
            DataStorage.AddValue(4);
            DataStorage.AddValue(5);
            DataStorage.AddValue(6);
            DataStorage.AddValue(7);

        }    

    }
    
}
