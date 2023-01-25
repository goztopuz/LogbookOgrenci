using Ogrenci4.src.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ogrenci4.src.Services
{
    public class ApiService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;




        string _servisAdres = "https://aooapi.azurewebsites.net/api/";


        public ApiService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<Ogrenciler> OgrenciBilgisiAl(int ogrenciNo)
        {
            Uri uriOgrenciBilgi = new Uri(_servisAdres + "/ogrencibilgisi/" + ogrenciNo);

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uriOgrenciBilgi);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var oo = JsonSerializer.Deserialize<Ogrenciler>(content, _serializerOptions);
                    return oo;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<SeciliKonu>> DersKonulariniAl(string _dersAdi)
        {
            Uri uriDersKonulari = new Uri(_servisAdres + "/konularilistele/" + _dersAdi);

            List<SeciliKonu> ll = new();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uriDersKonulari);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ll = JsonSerializer.Deserialize<List<SeciliKonu>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return ll;

        }

        public async void CalismaKaydet(List<CalisilanKonular> _lKonular,
         List<EkDosyaBilgi> _lDosyalar, Calisma _calisma)
        {

            Uri uriKonular = new Uri(_servisAdres + "/calismakonulari");
            Uri uriDosyalar = new Uri(_servisAdres + "/dosyaekle");
            Uri uriCalisma = new Uri(_servisAdres + "/calismaekle");


            try
            {

                if (_lKonular.Count > 0)
                {
                    string jsonKonular = JsonSerializer.Serialize<List<CalisilanKonular>>(_lKonular, _serializerOptions);
                    StringContent contentKonular = new StringContent(jsonKonular, Encoding.UTF8, "application/json");


                    var ss1 = await _client.PostAsync(uriKonular, contentKonular);
                }

                if (_lDosyalar.Count > 0)
                {
                    string jsonDosyalar = JsonSerializer.Serialize<List<EkDosyaBilgi>>(_lDosyalar, _serializerOptions);
                    StringContent contentDosyalar = new StringContent(jsonDosyalar, Encoding.UTF8, "application/json");

                    var durum = await _client.PostAsync(uriDosyalar, contentDosyalar);

                    string content = await durum.Content.ReadAsStringAsync();
                }


                string jsonCalisma = JsonSerializer.Serialize<Calisma>(_calisma, _serializerOptions);
                StringContent contentCalisma = new StringContent(jsonCalisma, Encoding.UTF8, "application/json");

                var durum2 = await _client.PostAsync(uriCalisma, contentCalisma);

                string content2 = await durum2.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }


        public async Task<List<CalismaTumBilgi>> KisiCalismalari(int ogrenciNo)
        {

            Uri uriCalismalar = new Uri(_servisAdres + "/calismalarilistele/" + ogrenciNo);


            List<CalismaTumBilgi> ll = new();
            try
            {
                var response = await _client.GetAsync(uriCalismalar);

                string content = await response.Content.ReadAsStringAsync();
                ll = JsonSerializer.Deserialize<List<CalismaTumBilgi>>(content, _serializerOptions);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return ll;

        }


        public async Task<List<CalismaTumBilgi2>> KisiCalismalari2(int ogrenciNo)
        {

            Uri uriCalismalar = new Uri(_servisAdres + "calismalarilistele2/" + ogrenciNo);


            List<CalismaTumBilgi2> ll = new();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uriCalismalar);

                var content = await response.Content.ReadAsStringAsync();
                ll = JsonSerializer.Deserialize<List<CalismaTumBilgi2>>(content, _serializerOptions);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return ll;

        }

        public async Task<List<OgretmenMesaj>> OgretmenMesajlari(int ogrenciNo)
        {
            Uri uriMesajlar = new Uri(_servisAdres + "ogretmenmesajlari/" + ogrenciNo);

            List<OgretmenMesaj> ll = new();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uriMesajlar);

                var content = await response.Content.ReadAsStringAsync();
                ll = JsonSerializer.Deserialize<List<OgretmenMesaj>>(content, _serializerOptions);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return ll;

        }

        public async Task MesajOkundu(OgretmenMesaj mesajj)
        {
            Uri uriMesajOkundu = new Uri(_servisAdres + "/ogretmenmesajokundu/");

            string jsonC1 = JsonSerializer.Serialize<OgretmenMesaj>(mesajj, _serializerOptions);
            StringContent contentCalisma = new StringContent(jsonC1, Encoding.UTF8, "application/json");

            var durum2 = await _client.PostAsync(uriMesajOkundu, contentCalisma);

            var content = await durum2.Content.ReadAsStringAsync();
        }

        public async void CalismaSil(string idd)
        {
            Uri uriCalismaSil = new Uri(_servisAdres + "/calismasil/" + idd);
            HttpResponseMessage response = await _client.DeleteAsync(uriCalismaSil);



        }
        public async void DosyaSil(string idd)
        {
            Uri uriDosyaSil = new Uri(_servisAdres + "/dosyasil/" + idd);
            HttpResponseMessage response = await _client.GetAsync(uriDosyaSil);

            var aa = response.Content.ReadAsStringAsync();
        }
    }
}
