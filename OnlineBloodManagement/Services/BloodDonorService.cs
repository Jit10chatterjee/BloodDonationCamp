using Newtonsoft.Json;
using OnlineBloodManagement.Models;

namespace OnlineBloodManagement.Services
{
    public class BloodDonorService
    {      

        public List<BloodDonorInfo> GetAllDonor()
        {
            string url = "http://localhost:61801/BloodDonorService";
            List<BloodDonorInfo> donorList = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(url))
                {
                    var apiResponse = response.Result;
                    var data = apiResponse.Content.ReadAsStringAsync().Result;
                    donorList = JsonConvert.DeserializeObject<List<BloodDonorInfo>>(data);
                }
            }
            return donorList;
        }


        public BloodDonorInfo GetDoonorById(int id)
        {
            string url = "http://localhost:61801/BloodDonorService/" + id;
            BloodDonorInfo donor = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(url))
                {
                    var apiResponse = response.Result;
                    var data = apiResponse.Content.ReadAsStringAsync().Result;
                    donor = JsonConvert.DeserializeObject<BloodDonorInfo>(data);
                }
            }
            return donor;
        }


        public List<BloodDonorInfo> GetDonorByGroup(string group)
        {
            string url = "http://localhost:61801/BloodDonorService/bgroup/" + group;
            List<BloodDonorInfo> donorList = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(url))
                {
                    var apiResponse = response.Result;
                    var data = apiResponse.Content.ReadAsStringAsync().Result;
                    donorList = JsonConvert.DeserializeObject<List<BloodDonorInfo>>(data);
                }
            }
            return donorList;
        }

        public int CreateBloodDonor(BloodDonorInfo donor)
        {
            string url = "http://localhost:61801/BloodDonorService";
            int id = 0;
            using (var httpCilent = new HttpClient())
            {
                string data = JsonConvert.SerializeObject(donor);
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


        public bool EditBloodDonor(int id, BloodDonorInfo donor)
        {
            string url = "http://localhost:61801/BloodDonorService/Modified/"+id;
            bool isSuccess = false;

            using (var httpCilent = new HttpClient())
            {
                string data = JsonConvert.SerializeObject(donor);
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

        public bool DeleteBloodDonor(int id)
        {
            string url = "http://localhost:61801/BloodDonorService/" + id;
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
