using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using TMPro;
using UnityEngine;

public class RegistrationValidate : MonoBehaviour
{
    public GameObject inputField;
    public GameObject errorMessageTextBox;
    void SaveUserData(string dataToSave)
    {
        UserNameData userData = new UserNameData(dataToSave);

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + $"/UserName.dat");

        bf.Serialize(file, userData);

        file.Close();

        Debug.Log($"Game data saved");

        Destroy(gameObject);
    }

    public void RegistraitButtonClick()
    {
        string inputFieldText = inputField.GetComponent<TMP_InputField>().text;
        StringBuilder errorMessage = new StringBuilder();
        if(inputFieldText.Length < 3)
        {
            errorMessage.AppendLine("Имя игрока должно быть больше 3 символов");
        }
        if(inputFieldText.Length > 10)
        {
            errorMessage.AppendLine("Имя игрока должно быть меньше 10 символов");
        }
        if (errorMessage.Length > 0)
        {
            errorMessageTextBox.GetComponent<TMP_Text>().text = errorMessage.ToString();
            return;
        }
        StaticDataContainer.UserName = inputFieldText;

        SaveUserData(inputFieldText);
    }
}
