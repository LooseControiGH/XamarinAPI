using System.IO;
using System.Net;

namespace Test_R
{
    class JsonDeserialize
    {
        //Method for 
        public string Deserialize()
        {
            try {
                //Create request
                WebRequest request = WebRequest.Create("https://fileserver-tsh.herokuapp.com/");
                //Setting query parameters
                request.Method = "POST";
                request.ContentType = "application/x-www-urlencoded";
                //Geting response from server
                WebResponse response = request.GetResponse();

                string answer = string.Empty;
                //Reading a response in a row
                using (Stream stream = response.GetResponseStream()) {
                    using (StreamReader stReader = new StreamReader(stream)) {
                        answer = stReader.ReadToEnd();
                    }
                }
                response.Close();
                return answer;
            }
            catch (System.Exception) {

                return "Oops! Something went wrong.";
            }
         
        }
        //overloaded method to get a list of files in a folder
        public string Deserialize(string _path) //folder path
        {
            try {
                string answer = string.Empty;
            string url = "https://fileserver-tsh.herokuapp.com/" + _path;
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-urlencoded";
            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream()) {
                using (StreamReader stReader = new StreamReader(stream)) {
                    answer = stReader.ReadToEnd();
                }
            }
            response.Close();
            return answer;
            }
            catch (System.Exception) {

                return "Oops! Something went wrong.";
            }
        }

      

    }
}
