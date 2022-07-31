using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class TextFormat : MonoBehaviour
{
    public string type;
    public string qualifier;
    public string action;
    public bool loop;
    public int variation;
    public string result;
    public bool underScoreRequired;
    private string loopResult = "";
    public ArrayList resultArray;

    private string a;
    private string b;
    private string c;
    private string d;

   
    private void Update()
    {
        CheckForErrors(type);
        CheckForErrors(qualifier);
        CheckForErrors(action);
        string typeWithNoBadCaps = CapitaliseFirst(type);

        if (loop)
        {
            loopResult = "Loop";
        }
        else
        {
            loopResult = "";
        }
        //var resultArray = new List<string>();
        var resultArray = new ArrayList();

        if (type.Length > 0)
        {
            resultArray.Add(type);
        }
        if (qualifier.Length > 0)
        {
            resultArray.Add(qualifier);
        }
        if (action.Length > 0)
        {
            resultArray.Add(action);
        }
        if (loop)
        {
            resultArray.Add(loopResult);
        }
        
        


        if (!underScoreRequired)
        {

            resultArray[0] = a;
            resultArray[1] = b;
            resultArray[2] = c;
            resultArray[3] = d;

            result = a.ToLower() + CapitaliseFirst(b) + CapitaliseFirst(c) + CapitaliseFirst(d) + variation;

        }
            

        /*if (!underScoreRequired)
        {
            //All fields have values
            if(type.Length > 0)
            {
                result = type.ToLower() + CapitaliseFirst(qualifier) + CapitaliseFirst(action) + loopResult + variation;
            }
            //type is null
            else if (type.Length < 0)
            {
                result = qualifier.ToLower() + CapitaliseFirst(action) + loopResult + variation;
            }
            //type and qualifier is null
            else if (qualifier.Length < 0 )
            {
                result = type.ToLower() + CapitaliseFirst(action) + loopResult + variation;
            }
            //type, qualifier and action is null
            else if (action.Length < 0)
            {
                result = type.ToLower() + qualifier.ToLower() + action.ToLower() + loopResult + variation;
            }
            //type, qualifier, action and loop is null
            else if (loopResult.Length < 0)
            {
                result = type.ToLower() + qualifier.ToLower() + action.ToLower() + + variation;
            }
        }*/


        if (underScoreRequired)
        {
            result = CheckForDoubleUnderscore((typeWithNoBadCaps + "_" + qualifier + "_" + action + "_" + loopResult + "_" + variation));
        }
        //Debug.Log(type.ToUpper());

    }

    void CheckForErrors(string input)
    {
        input = CheckForWhiteSpace(input);
    }
    //check for whitespaces and if they are there, remove them.
    string CheckForWhiteSpace(string input)
    {
        input = input.Replace(" ", "");
        return input;
    }
    string CheckForDoubleUnderscore(string input)
    {
        input = input.Replace("__", "_");
        return input;
    }
    //check for whitespaces and if they are there, remove them.
    string CapitaliseFirst(string input)
    {
        string fixedInputCaps = "";

        if(input.Length > 0)
        {
            string lowerCaseWord = input.ToLower();
            string firstLetter = lowerCaseWord[0].ToString().ToUpper();
            string remainingLetters = lowerCaseWord.Substring(1);
            fixedInputCaps = firstLetter + remainingLetters;

            // Debug.Log(firstLetter + remainingLetters);
        }
        return fixedInputCaps;
    }
}
