using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingInElements_byJohn
{
    class Initialiser : IInitialiser
    {
        static void Initialise()
        {
            //dear framework, whenever an exception escapes my code
            //and gets back to you, please do not treat this as a grand
            //mistake. Instead, call me back on ErrorHandling.FinalErrorHandler

            /////////Ana's adding info
            // BLABLABLA where you create the general try-catch in class ErrorHandling and in function FinalErrorHandler:
            
            try
            {

            }
            catch (Exception ex)
            {
                if (ex is ApplicationException)
                {
                        
                }
                else if (ex is OverflowException)
                {
                    
                }
                else
                {
                    //general method to deal with exceptions...
                }
                
            }
            /////////// End of Ana's adding info

        }
    }

    class ErrorHandling
    {
        public void FinalErrorHandler(Exception doh)
        {

        }
    }

    class WebPage : IHttpHandler
    {
        public void ProcessReqest(IHttpRequest request)
        {

        }
    }

    class WebPage2 : IHttpHandler
    {
        public void ProcessReqest(IHttpRequest request)
        {

        }
    }

    class WebPage3 : IHttpHandler
    {
        public void ProcessReqest(IHttpRequest request)
        {

        }
    }

    ///////////////////////////////////////////////

    static class WebApplication
    {
        public static void Main()
        {
            //allow the application code that we will use later to register a callback
            //for when exceptions escape their code.
            //has the application code got any classes in it that implement our interface IInitialiser?
            //if so, create an instance of that class and run the Initialise function.
            //With the return value, which represents a function callback, 

            //keep listening for incoming web requests
            //when we get one, read the URL that is being requested.
            //look for an applicaiton configuration file, and find the matching entry for the requested URL.
            //the details found will tell us which class to use to handle the web request.
            //create a new instance of that class.
            //call the ProcessRequest function on that class.

            WebPage3 page = new WebPage3();
            try
            {
                page.ProcessReqest(request);
            }
            catch (Exception doh)
            {
                //if we have a callback registered, call it.

            }
        }
    }
}