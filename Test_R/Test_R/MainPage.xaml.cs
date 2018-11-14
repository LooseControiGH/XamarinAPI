using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Test_R
{
    public partial class MainPage : ContentPage
    {
        //initilaze objects
        public ObservableCollection<Folder> folderInfo { get; set; }
        private JsonDeserialize jsonDeserialize;
        private Root folder;
        public MainPage()
        {
            InitializeComponent();
            folderInfo = new ObservableCollection<Folder>();
            jsonDeserialize = new JsonDeserialize();
            ListView lstView = new ListView();
            //setup settings listView
            lstView.RowHeight = 60;
            lstView.ItemTemplate = new DataTemplate(typeof(Folder));
        }

        private void OnButtonClicked(object sender, EventArgs evevnt)
        {
            string pathFolder;
            string[] split;
            try {
                //Reading a response in a row
                string answer = jsonDeserialize.Deserialize().ToString();
                JObject jobject = JObject.Parse(answer);
                var arrFolder = jobject.SelectToken("content");
                // parse answer
                var listFolder = arrFolder.ToList();
                // geting parametrs from content folder
                folder = JsonConvert.DeserializeObject<Root>(answer);
                //get folder options
                for (int i = 0; i < listFolder.Count; i++) {
                    pathFolder = listFolder[i].Path;
                    split = pathFolder.Split('.');
                    folder.name = split[1];
                    //setup parametrs folder for display
                    folderInfo.Add(new Folder { name = folder.name, birthtime = folder.birthtime, });
                }
            }
            catch (Exception) {

                LabelMain.Text = "Oops! Something went wrong";
            }
            lstView.ItemsSource = folderInfo;

        }

        private void lstView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void TextCell_Tapped(object sender, EventArgs e)
        {
            //transition to the following view
            //in the properties we pass the name and path
            TextCell textCell = (TextCell)sender;
            Navigation.PushAsync(new FolderInfo(textCell.Text));
        }
    }
}
