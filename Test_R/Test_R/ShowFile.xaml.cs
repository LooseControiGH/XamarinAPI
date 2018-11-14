using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Web;
using System.IO;

namespace Test_R
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowFile : ContentPage
    {
   
        public ShowFile(string _name, string _path, DateTime _dateCreate)
        {
            InitializeComponent();
            ShowFileContent(_name, _path, _dateCreate);
        }

        private  void ShowFileContent(string _name, string _path,  DateTime _dateCreate)
        {
            labelDateCreator.Text = _dateCreate.ToShortDateString();
            try {
                string[] splitTxt = _name.Split('.', '\'');
                //determine the type of file
                if (String.Equals(splitTxt[splitTxt.Length - 1], "jpg")) {
                    imageContent.Source = ImageSource.FromUri(new Uri("https://fileserver-tsh.herokuapp.com/" + _path + "/" + _name));
                }
                else { LoadData(_name, _path); }
            }
            catch (Exception ex) {

                labelSecond.Text = ex.Message;
            }


        }
        private  void LoadData(string _name, string _path)
        {
            //creating url string
            string nameFile = HttpUtility.UrlPathEncode(_name);
            string url = "https://fileserver-tsh.herokuapp.com/"+ _path;
            string localPath = Path.Combine(url, nameFile);

            WebRequest request = WebRequest.Create(localPath);
            request.Method = "GET";
            request.ContentType = "text/html";
           WebResponse response =  request.GetResponse();
            using (Stream stream = response.GetResponseStream()) {
                using (StreamReader stReader = new StreamReader(stream)) {
                   editorText.Text = stReader.ReadToEnd();
                }
            }
            response.Close();

        }

    }
}