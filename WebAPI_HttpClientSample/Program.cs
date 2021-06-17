﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPI_SharedLibrary.Entities;

namespace WebAPI_HttpClientSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //WebClient client = new WebClient();
            //client.DownloadString() //Get Methode möglich -> WebClient wird nicht für WebAPI verwendet.

            string webAPIAddress = "https://localhost:44373/Movie/";



            Movie newMovie = new Movie() { Id = 4, Title = "Simpsons", Description = "Bart ist schlauer als Lisa", Genre = Genre.Animations, Published = DateTime.Now, Price = 29.99m };

            string jsonString = JsonConvert.SerializeObject(newMovie);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(webAPIAddress, content);
                string resultCode = await response.Content.ReadAsStringAsync(); //HTTP-Code
            }







            #region GET Movies + Ausgabe
            HttpClient httpClient = new HttpClient();
            // Beispiel-SendAsync -> Allgemein Methode (kann Get/Post/Put/Remove)
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, webAPIAddress);
            HttpResponseMessage responseResult = await httpClient.SendAsync(request);
            string resultAsJSON = await responseResult.Content.ReadAsStringAsync();


            IList<Movie> resultList = JsonConvert.DeserializeObject<List<Movie>>(resultAsJSON);

            foreach (Movie movie in resultList)
            {
                Console.WriteLine(movie.Title);
                Console.WriteLine(movie.Description);
                Console.WriteLine(movie.Price);
                Console.WriteLine("----------------------");
            }


            Console.Write(resultAsJSON);
            Console.ReadKey();

            #endregion



            Console.WriteLine("Hello World!");
        }
    }
}
