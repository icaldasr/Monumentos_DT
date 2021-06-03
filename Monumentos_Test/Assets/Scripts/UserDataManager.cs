using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;


public class UserDataManager : MonoBehaviour
{
    public TextAsset xmlRawFile;
    public Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        string data = xmlRawFile.text;
        parseXmlFile(data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void parseXmlFile(string xmlData)
    {
        string totVal = "";
        //Inicializa el xml
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));

        string xmlPathPattern = "//users/profile";
        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
        foreach(XmlNode node in myNodeList)
        {
            XmlNode email = node.FirstChild;
            XmlNode name = email.NextSibling;
            XmlNode user = email.NextSibling;
            XmlNode password = email.NextSibling;

            totVal += "Email: " + email.InnerXml + "\n Name: " + name.InnerXml + "\n User: " + user.InnerXml + "\n\n";
            uiText.text = totVal;
        }
    }
}
