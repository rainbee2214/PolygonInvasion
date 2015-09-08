using UnityEngine;
using SSS.Convert;

public class Test_SSS_Convert : MonoBehaviour
{

    void Start()
    {
        // Deg ~ Rad
        Debug.Log("***** Deg ~ Rad *****");
        Debug.Log(Convert.DegToRad(1));
        Debug.Log(Convert.DegToRad(5));
        Debug.Log(Convert.DegToRad(180));
        Debug.Log(Convert.DegToRad(360));

        Debug.Log(Convert.RadToDeg(0.0174532925f));
        Debug.Log(Convert.RadToDeg(0.0872664626f));
        Debug.Log(Convert.RadToDeg(3.14159265f));
        Debug.Log(Convert.RadToDeg(6.28318531f));

        // KM ~ Miles
        Debug.Log("***** KM ~ Miles *****");
        Debug.Log(Convert.KMToMiles(1));
        Debug.Log(Convert.KMToMiles(33));
        Debug.Log(Convert.KMToMiles(1000));
        Debug.Log(Convert.KMToMiles(34567));

        Debug.Log(Convert.MilesToKM(0.621371f));
        Debug.Log(Convert.MilesToKM(20.5052f));
        Debug.Log(Convert.MilesToKM(621.371f));
        Debug.Log(Convert.MilesToKM(21478.938f));

        // M ~ Feet
        Debug.Log("***** M ~ Feet *****");
        Debug.Log(Convert.MToFeet(1));
        Debug.Log(Convert.MToFeet(33));
        Debug.Log(Convert.MToFeet(1000));
        Debug.Log(Convert.MToFeet(34567));

        Debug.Log(Convert.FeetToM(0.621371f));
        Debug.Log(Convert.FeetToM(20.5052f));
        Debug.Log(Convert.FeetToM(621.371f));
        Debug.Log(Convert.FeetToM(21478.938f));

        // C ~ F
        Debug.Log("***** C ~ F *****");
        Debug.Log(Convert.CToF(0));
        Debug.Log(Convert.CToF(33));
        Debug.Log(Convert.CToF(-40));
        Debug.Log(Convert.CToF(34567));

        Debug.Log(Convert.FToC(32));
        Debug.Log(Convert.FToC(91.4f));
        Debug.Log(Convert.FToC(-40));
        Debug.Log(Convert.FToC(62252.6f));

        // KG ~ Pound
        Debug.Log("***** KG ~ Pound *****");
        Debug.Log(Convert.KGToPound(10));
        Debug.Log(Convert.KGToPound(33));
        Debug.Log(Convert.KGToPound(403));
        Debug.Log(Convert.KGToPound(12.3456f));

        Debug.Log(Convert.PoundToKG(22.0462f));
        Debug.Log(Convert.PoundToKG(72.7525f));
        Debug.Log(Convert.PoundToKG(888.463f));
        Debug.Log(Convert.PoundToKG(27.21738904f));

        // CamelCase to full string
        Debug.Log(Convert.CamelToFull("CamelCaseIsFun"));
        Debug.Log(Convert.CamelToFull("Camel CaseIsFun"));
        Debug.Log(Convert.CamelToFull("CamelCaseIsFun WeeDontEvenCare'bouNothin"));
        Debug.Log(Convert.CamelToFull("Camel Case Is Fun"));

    }
}
