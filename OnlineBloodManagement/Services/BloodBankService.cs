using Newtonsoft.Json;
using OnlineBloodManagement.Models;
using System;
using System.Runtime.ConstrainedExecution;

namespace OnlineBloodManagement.Services
{
    public class BloodBankService
    {
        public List<BloodBankInfo> GetAllBloodBank()
        {
            string url = "http://localhost:61801/BloodBankService";
            List<BloodBankInfo> bloodbankList = null;
            using(var httpClient = new HttpClient())
            {
                using(var response = httpClient.GetAsync(url))
                {
                    var apiResponse = response.Result;
                    var data = apiResponse.Content.ReadAsStringAsync().Result;
                    bloodbankList = JsonConvert.DeserializeObject<List<BloodBankInfo>>(data);
                }
            }
            return bloodbankList;
        }

        public BloodBankInfo GetBloodBankById(int id)
        {
            string url = "http://localhost:61801/BloodBankService/"+id;
            BloodBankInfo b = null;
            using(var httpClient = new HttpClient())
            {
                using(var response = httpClient.GetAsync(url))
                {
                    var apiResponse = response.Result;
                    var data = apiResponse.Content.ReadAsStringAsync().Result;
                    b = JsonConvert.DeserializeObject<BloodBankInfo>(data);
                }
            }
            return b;
        }

        public List<BloodBankInfo> GetBloodBankByCity(string city)
        {
            string url = "http://localhost:61801/BloodBankService/find/" + city;
            List<BloodBankInfo> bloodbankList = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(url))
                {
                    var apiResponse = response.Result;
                    var data = apiResponse.Content.ReadAsStringAsync().Result;
                    bloodbankList = JsonConvert.DeserializeObject<List<BloodBankInfo>>(data);
                }
            }
            return bloodbankList;
        }


        public int CreateBloodBank(BloodBankInfo b)
        {
            string url = "http://localhost:61801/BloodBankService";
            int id = 0;
            using (var httpCilent = new HttpClient())
            {
                string data = JsonConvert.SerializeObject(b);
                StringContent content = new StringContent(data,
                    System.Text.Encoding.UTF8, "application/json");

                using (var response = httpCilent.PostAsync(url, content))
                {
                    var apiResponse = response.Result;
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        var r = apiResponse.Content.ReadAsStringAsync()
                            .Result;
                        id = Convert.ToInt32(r);
                    }
                }
            }
            return id;
        }

        public bool EditBloodBank(int id,BloodBankInfo b)
        {
            string url = "http://localhost:61801/BloodBankService/Modified/" + id;
            bool isSuccess = false;

            using (var httpCilent = new HttpClient())
            {
                string data = JsonConvert.SerializeObject(b);
                StringContent content = new StringContent(data,
                    System.Text.Encoding.UTF8, "application/json");

                using (var response = httpCilent.PutAsync(url, content))
                {
                    var apiResponse = response.Result;
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        isSuccess = true;
                    }
                }
            }
            return isSuccess;
        }


        public bool DeleteBloodBank(int id)
        {
            string url = "http://localhost:61801/BloodBankService/" + id;
            bool isSuccess = false;

            using (var httpCilent = new HttpClient())
            {
                using (var response = httpCilent.DeleteAsync(url))
                {
                    var apiResponse = response.Result;
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        isSuccess = true;
                    }
                }
            }
            return isSuccess;
        }
    }
}
