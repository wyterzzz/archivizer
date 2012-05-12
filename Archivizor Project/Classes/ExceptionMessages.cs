using System;
using System.Collections.Generic;
using System.Text;

class ExceptionMessages
{
    private List<String> exceptionMessages = new List<String>();

    public ExceptionMessages()
    {
        String messageDenied = "Access to "
            + "{0}"
            + " is denied.\n"
            + "Do you want to run the program as Administrator?\n\n"
            + "Note: If you don't run it as Administrator it may show such kind of messages again!";

        exceptionMessages.Add(messageDenied);
    }

    /// <summary>
    /// Returns edited message
    /// </summary>
    /// <param name="exceptionMessage">Exception message</param>
    /// <param name="argument">Other optional argument</param>
    /// <returns></returns>
    public String GetMessage(String exceptionMessage, String argument = "")
    {
        if (exceptionMessage.Contains("denied"))
        {
            return exceptionMessages[0].Replace("{0}", argument);
        }
        else
        {
            return exceptionMessage;
        }
    }
}

