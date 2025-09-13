using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace Ruap_MartinaOstovic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnClickThis_Click(object sender, EventArgs e)
        { 
            string endpoint = "http://8205753d-6ec1-4942-8112-3e737e006b8b.northeurope.azurecontainer.io/score";
            string apiKey = "bb6r57mkRxGkUdwKvfmmMzxzyWFUkqHQ";

            try
            {
                
                var features = new Dictionary<string, object>
        {
            { "duration_ms", int.Parse(textBox1.Text) },
            { "explicit", bool.Parse(textBox2.Text) },   // true / false
            { "year", int.Parse(textBox6.Text) },
            { "danceability", double.Parse(textBox5.Text) },
            { "energy", double.Parse(textBox4.Text) },
            { "key", int.Parse(textBox3.Text) },
            { "loudness", double.Parse(textBox7.Text) },
            { "mode", int.Parse(textBox8.Text) },
            { "speechiness", double.Parse(textBox9.Text) },
            { "acousticness", double.Parse(textBox10.Text) },
            { "instrumentalness", double.Parse(textBox11.Text) },
            { "liveness", double.Parse(textBox12.Text) },
            { "valence", double.Parse(textBox13.Text) },
            { "tempo", double.Parse(textBox14.Text) },

            { "Dance/Electronic", int.Parse(textBox15.Text) },
            { "Folk/Acoustic", int.Parse(textBox16.Text) },
            { "R&B", int.Parse(textBox17.Text) },
            { "World/Traditional", int.Parse(textBox18.Text) },
            { "blues", int.Parse(textBox19.Text) },
            { "classical", int.Parse(textBox20.Text) },
            { "country", int.Parse(textBox21.Text) },
            { "easylistening", int.Parse(textBox22.Text) },
            { "hiphop", int.Parse(textBox23.Text) },
            { "jazz", int.Parse(textBox24.Text) },
            { "latin", int.Parse(textBox25.Text) },
            { "metal", int.Parse(textBox26.Text) },
            { "pop", int.Parse(textBox27.Text) },
            { "rock", int.Parse(textBox28.Text) },
            { "unknown genre", int.Parse(textBox29.Text) }
        };


                var input = new
                {
                    Inputs = new Dictionary<string, object>
            {
                { "input1", new[] { features } }
            },
                    GlobalParameters = new { }
                };

                string json = JsonConvert.SerializeObject(input);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(endpoint, content);

                    string result = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var jsonObj = JObject.Parse(result);
                        var output = jsonObj["Results"]["WebServiceOutput0"][0];
                        bool isPopular = output["Scored Labels"].ToObject<bool>();
                        double probability = output["Scored Probabilities"].ToObject<double>();

                        string popularityText = isPopular ? "This song is popular!" : "This song is not popular!";
                        string probabilityText = $"Probability: {probability * 100:F2}%";

                        richTextBox30.Text = $"{popularityText}\n{probabilityText}";
                    }
                    catch (Exception ex)
                    {
                        richTextBox30.Text = "Error parsing result: " + ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox30.Text = "Error: " + ex.Message;
            }
        }

    }
}

