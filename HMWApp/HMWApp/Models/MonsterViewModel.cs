using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Xamarin.Forms;
using DAL3.Models;

namespace HMWApp.Models
{
    public class MonsterViewModel: INotifyPropertyChanged
    {


        public ICommand LoadMonstersCommand => new Command(async value => { await LoadData(); });

        private ObservableCollection<Monster> _monsters;

        public ObservableCollection<Monster> Monsters
        {
            get => _monsters;
            set
            {
                _monsters = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadData()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://10.0.2.2:5000/get/getAllMonsterInfo").ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync();
            var monsters = JsonConvert.DeserializeObject<ObservableCollection<Monster>>(json);
            Monsters = monsters;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

    }
}
