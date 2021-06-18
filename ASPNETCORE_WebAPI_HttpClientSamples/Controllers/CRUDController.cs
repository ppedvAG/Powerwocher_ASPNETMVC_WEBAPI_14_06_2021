using ASPNETCORE_WebAPI_SharedLib.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI_HttpClientSamples.Controllers
{

    /// <summary>
    /// Hier wird gezeigt, wie man mit dem HTTPCliet auf eine WebAPI-Ressource zugreift 
    /// </summary>
    public class CRUDController : Controller
    {
        string _baseURL = "https://localhost:44305/Stammdaten/Movie/";

        #region GET-MEthoden für komplette Liste und Movie-Detailansicht


        public async Task<IActionResult> Index()
        {
            //Wir wollen eine Liste von Movies aus der WebAPI auslesen. 
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _baseURL);

            //Calle die WebAPI und erhalte ein Ergebnis (responseResult) 
            HttpResponseMessage responseResult = await client.SendAsync(request);
            string jsonText = await responseResult.Content.ReadAsStringAsync();

            IList<Movie> resultList = JsonConvert.DeserializeObject<List<Movie>>(jsonText);

            return View(resultList);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie movie = null;

            string url = _baseURL + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonText = await response.Content.ReadAsStringAsync();

                movie = JsonConvert.DeserializeObject<Movie>(jsonText);
            }



            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        #endregion

        #region CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Genre,Price")] Movie movie) //Formulardaten konventieren in Movie-Objekt = ModelBinding
        {

            if (movie.Genre == 0)
            {
                ModelState.AddModelError("Genre", "Bitte wählen sie ein Genre aus");
            }

            if (ModelState.IsValid) //Serverseitige Validierung
            {
                string jsonString = JsonConvert.SerializeObject(movie);

                StringContent data = new StringContent(jsonString, Encoding.UTF8, "application/json");

                using (HttpClient client = new())
                {
                    HttpResponseMessage response = await client.PostAsync(_baseURL, data);
                    string resultCode = await response.Content.ReadAsStringAsync(); //HTTP-Code
                }

                return RedirectToAction(nameof(Index));
            }
            return View(movie); //
        }
        #endregion

        #region EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            string url = _baseURL + id.ToString(); //https://localhost:44305/Stammdaten/Movie/123
            Movie movie = null;
            
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonText = await response.Content.ReadAsStringAsync();


                movie = JsonConvert.DeserializeObject<Movie>(jsonText);
            }

            if (movie == null)
            {
                return NotFound();
            }
            return View(movie); //Formulat das an Browser übergeben wird hat sogar Daten
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Genre,Price")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string url = _baseURL + id.ToString();

                string json = JsonConvert.SerializeObject(movie);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    var response = client.PutAsync(url, data); //Update
                    string result = await response.Result.Content.ReadAsStringAsync();
                }


                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        #endregion

        #region Delete
        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie movie = null;

            string url = _baseURL + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonText = await response.Content.ReadAsStringAsync();

                movie = JsonConvert.DeserializeObject<Movie>(jsonText);
            }

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            string url = _baseURL + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(url);
                string result = await response.Content.ReadAsStringAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
