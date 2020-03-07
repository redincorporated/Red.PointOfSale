using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Red.PointOfSale.Models;
using Red.PointOfSale.Repositories.SQLite;
using System.Web;
using Red.PointOfSale.Helpers;
using System.ComponentModel;

namespace Red.PointOfSale.Services
{
    public class ApiService
    {
        string url;
        HttpClient client;
        string token;

        public ApiService(string url, string token)
        {
            this.url = url;
            this.token = token;
            this.client = new HttpClient();
        }

        public async void PushSales(SalesReceipt sales)
        {
            var uri = new Uri(url + "/api/save_sales_receipt");
            List<object> salesItemsObj = new List<object>();
            foreach (var i in sales.Items) {
                salesItemsObj.Add(new { item_id = i.Item.Id, quantity = i.Quantity, price = i.Price });
            }
            var salesObj = new { id = sales.Id, customer_id = sales.Customer.Id, items = salesItemsObj };
            var data = ToParameters(new { token = token, data = JsonConvert.SerializeObject(salesObj) });
            var content = new FormUrlEncodedContent(data);
            var response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode) {
                var responseContent = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(responseContent);
                if (o["message"].ToString().Equals("OK")) {
                    var s = new SalesReceipt {
                        RefNo = o["ref_no"].ToString()
                    };
                    OnResponseReceived(new Response(s));
                } else {
                    OnResponseReceived(new Response { Data = o["message"].ToString() });
                }
            }
        }

        public async void PullUsers()
        {
            var uri = new UriBuilder(url + "/api/get_users");
            var query = HttpUtility.ParseQueryString(uri.Query);
            query["token"] = token;
            uri.Query = query.ToString();
            var response = await client.GetAsync(uri.ToString());
            if (response.IsSuccessStatusCode) {
                var responseContent = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(responseContent);
                if (o["message"].ToString() == "OK") {
                    JArray data = JArray.Parse(o["data"].ToString());
                    var users = new List<User>();
                    foreach (var m in data) {
                        var user = new User {
                            Id = ConvertHelper.ToInt32(m["id"]),
                            Name = m["name"].ToString(),
                            Username = m["username"].ToString(),
                            Email = m["email"].ToString(),
                            Phone = m["phone"].ToString(),
                            Password = m["password"].ToString()
                        };
                        users.Add(user);
                    }
                    OnResponseReceived(new Response { Data = users });
                }
            }
        }

        public async void PullItems()
        {
            var uri = new UriBuilder(url + "/api/get_items");
            var query = HttpUtility.ParseQueryString(uri.Query);
            query["token"] = token;
            uri.Query = query.ToString();
            var response = await client.GetAsync(uri.ToString());
            if (response.IsSuccessStatusCode) {
                var responseContent = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(responseContent);
                if (o["message"].ToString() == "OK") {
                    JArray itemsArray = JArray.Parse(o["data"].ToString());
                    var items = new List<Item>();
                    foreach (var itemArray in itemsArray) {
                        var item = new Item {
                            Id = ConvertHelper.ToInt32(itemArray["id"]),
                            Code = GetString(itemArray["code"]),
                            Name = GetString(itemArray["name"]),
                            Description = GetString(itemArray["description"]),
                            Price = ConvertHelper.ToDouble(itemArray["price"]),
                        };
                        JArray detailsArray = JArray.Parse(itemArray["details"].ToString());
                        foreach (var detailArray in detailsArray) {
                            var detail = new ItemDetail {
                                Id = ConvertHelper.ToInt32(detailArray["id"]),
                                StockNumber = GetString(detailArray["stock_no"]),
                                Code = GetString(detailArray["code"]),
                            };
                            item.AddDetail(detail);
                        }
                        items.Add(item);
                    }
                    OnResponseReceived(new Response { Data = items });
                }
            }
        }
        
        string GetString(object o)
        {
            return o != null ? o.ToString() : "";
        }

        List<KeyValuePair<string, string>> ToParameters(object obj)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj)) {
                object value = property.GetValue(obj);
                parameters.Add(new KeyValuePair<string, string>(property.Name, value.ToString()));
            }
            return parameters;
        }

        public async void Hello()
        {
            var uri = new Uri(url + "/api/hello");
            var data = ToParameters(new { });
            var content = new FormUrlEncodedContent(data);
            var response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode) {
                var responseContent = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(responseContent);
                OnResponseReceived(new Response { Data = o["message"].ToString() });
            }
        }

        public event EventHandler<ResponseEventArgs> ResponseReceived;

        protected virtual void OnResponseReceived(Response r)
        {
            OnResponseReceived(new ResponseEventArgs(r));
        }

        protected virtual void OnResponseReceived(ResponseEventArgs e)
        {
            if (ResponseReceived != null) {
                ResponseReceived(this, e);
            }
        }
    }

    public class ResponseEventArgs : EventArgs
    {
        public ResponseEventArgs(Response response)
        {
            this.Response = response;
        }

        public Response Response { get; set; }
    }

    public class Response
    {
        public object Data { get; set; }
        public string Message { get; set; }

        public Response() { }

        public Response(object data)
        {
            this.Data = data;
        }
    }
}
