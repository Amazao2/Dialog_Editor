using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**  Contains between 1 and 3 response strings selectable by the character
 * 
 *      - watch out for nasty null exceptions
 * 
 */
[System.Serializable]
public class DialogResponses
{
    public DialogResponse responseOne = null;
    public DialogResponse responseTwo = null;
    public DialogResponse responseThree = null;

    public int numberOfResponses {
        get{
            if (responseThree == null && responseTwo == null)
                return 1;
            else if (responseTwo == null)
                return 2;
            else
                return 3;
        }
    }

    public DialogResponses(DialogResponse one, DialogResponse two, DialogResponse three)
    {
        responseOne = one;
        responseTwo = two;
        responseThree = three;
    }

    public DialogResponses(DialogResponse one, DialogResponse two) { responseOne = one; responseTwo = two; }

    public DialogResponses(DialogResponse one) { responseOne = one; }

    public static DialogResponse CreateResponse(string response, DialogNode next) { return new DialogResponse(response, next); }
    public static DialogResponse CreateLeafResponse(string response) { return new DialogResponse(response); }

}
