using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace PB_test_app
{
    public class QueryBonds
    {
        private static readonly QueryBonds _instance = new QueryBonds();
        public static QueryBonds Instance { get { return _instance; } }

        public ObservableCollection<QueryBonds> QueryValue = new ObservableCollection<QueryBonds>();

        public string ResponseValue { get; set; }

        public async void PostRequest(string value)
        {
            var values = new Dictionary<string, string>
            {
                { "gsearch", "value" }
            };
            var content = new FormUrlEncodedContent(values);

            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.PostAsync("https://www.bb.org.bd/en/index.php/investfacility/prizebond", content))
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseString);
                    QueryValue.Add(new QueryBonds { ResponseValue = responseString });
                }
            }
        }
    }
}