using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;


public class UserDataManager : MonoBehaviour
{
    public TextAsset xmlRawFile;
    public Text uiEmail;
    public Text uiName;
    public Text uiGenre;
    public Text uiAge;
    public Text uiUser;
    public Text uiText;

    public Text uiMessageBox;
    public Text uiMessageBox2;
    public Text uiMessageBox3;
    public Text uiMessageBox4;
    public Text uiMessageBox5;
    public InputField uiUserTextBox;
    public InputField uiPasswordTextBox;
    
    //public string cadena;

    // Start is called before the first frame update
    void Start()
    {
        //TextAsset xmlTextAsset = Resources.Load<NombreArchivo>("Carpeta/Nombrearchivo");
        string data = xmlRawFile.text;
        //string userInput = uiUserTextBox.text.ToString();
        //string psswdInput = uiPasswordTextBox.text.ToString();
        //cargarInfo(data, uiUserTextBox.text, uiPasswordTextBox.text);
        logIn(data);
        parseXmlFile(data);
        //cargarInfo(data, uiUserTextBox.text, uiPasswordTextBox.text);
        //getUser(data);

    }

    /*public void getUser()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));
        XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("//users/profile");

        foreach (XmlNode node in nodeList)
        {
            uiMessageBox2.text += " INPUT2: " + uiUserTextBox.text + " " + uiPasswordTextBox.text;
            //string userInput = uiUserTextBox.text.ToString();
            //string psswdInput = uiPasswordTextBox.text.ToString();

            string user = node.SelectSingleNode("user").InnerText;
            string password = node.SelectSingleNode("password").InnerText;

            uiMessageBox3.text = "XML: " + user + " " + password;
            //uiMessageBox2.text = "INPUT: " + userInput + " " + psswdInput;

        }
    }*/
        public void logIn(string xmlData)
        {
        
            string userInput = uiUserTextBox.text;
            string psswdInput = uiPasswordTextBox.text;
            uiMessageBox5.text = "INPUT1: " + userInput + " " + psswdInput;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(xmlData));
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("//users/profile");

            foreach (XmlNode node in nodeList)
            {
                uiMessageBox2.text = " INPUT2: " + uiUserTextBox.text + " " + uiPasswordTextBox.text;
                //string userInput = uiUserTextBox.text.ToString();
                //string psswdInput = uiPasswordTextBox.text.ToString();

                string user = node.SelectSingleNode("user").InnerText;
                string password = node.SelectSingleNode("password").InnerText;

                uiMessageBox3.text = "XML: " + user + " " + password;
                //uiMessageBox2.text = "INPUT: " + userInput + " " + psswdInput;

                if (uiUserTextBox.text == user && uiPasswordTextBox.text == password)
                {
                    uiMessageBox4.text = "Inicia Sesión";
                    uiMessageBox.text = "Inicia Sesión";
                }
                else
                {
                    //uiMessageBox4.text ="ERROR";
                    if (user != uiUserTextBox.text && password == uiPasswordTextBox.text)
                    {
                        uiMessageBox4.text = "Usr DIf " + user + " Input" + uiUserTextBox.text;
                    }

                    else if (user == uiUserTextBox.text && password != uiPasswordTextBox.text)
                    {
                        uiMessageBox4.text = "PSS DIf " + password + " Input" + uiPasswordTextBox.text;
                    }

                    else
                    {
                        uiMessageBox4.text = "ERROR " + password + " Input" + uiPasswordTextBox.text + " " + user + " Input" + uiUserTextBox.text;
                        uiMessageBox.text = "ERROR " + password + " Input" + uiPasswordTextBox.text + " " + user + " Input" + uiUserTextBox.text;
                    }
                }
            }
        }
    
    public void parseXmlFile(string xmlData)
    {
        //string valEmail = "";
        string valName = "";
        string valGenre = "";
        string valAge = "";
        //string totVal = "";

        //Inicializa el xml
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));

        string xmlPathPattern = "//users/profile";
        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
        foreach(XmlNode node in myNodeList)
        {
            XmlNode email = node.FirstChild;
            XmlNode name = email.NextSibling;
            XmlNode genre = name.NextSibling;
            XmlNode age = genre.NextSibling;

            valName += name.InnerXml;
            uiName.text = valName;
            valGenre += genre.InnerXml;
            uiGenre.text = valGenre;
            valAge += age.InnerXml;
            uiAge.text = valAge;
            //totVal += "Email: " + email.InnerXml + "\n Name: " + name.InnerXml + "\n User: " + age.InnerXml + "\n\n";
            //uiText.text = totVal;
        }
    }
}
