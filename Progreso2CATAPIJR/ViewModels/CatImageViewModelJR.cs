using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Progreso2CATAPIJR.Models;
using Progreso2CATAPIJR.Services;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Windows.Input;


namespace Progreso2CATAPIJR.ViewModels
{
    public class CatImageViewModelJR :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CatImageViewModelJR()
        {
            LoadRandomCatImageCommand = new Command(async () => await LoadRandomCatImage());
            SaveCatImageCommand = new Command(async () => await SaveCatImage());
            service = new CatImageServiceJR();
            sqliteService = new SQLiteServiceJR();
        }

        private Uri imageUri;
        public Uri ImageUri
        {
            get { return imageUri; }
            set
            {
                if (imageUri != value)
                {
                    imageUri = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string breed;
        public string Breed
        {
            get { return breed; }
            set
            {
                if (breed != value)
                {
                    breed = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private CatImageServiceJR service;
        public CatImageServiceJR Service
        {
            get { return service; }
        }

        private SQLiteServiceJR sqliteService;
        public SQLiteServiceJR SQLiteService
        {
            get { return sqliteService; }
        }

        public ICommand LoadRandomCatImageCommand { get; }
        public ICommand SaveCatImageCommand { get; }

        private async Task LoadRandomCatImage()
        {
            CatImageJR catImage = await Service.GetRandomCatImage();
            if (catImage != null)
            {
                ImageUri = new Uri(catImage.Url);
                Breed = catImage.Breed;
            }
            else
            {
                ImageUri = new Uri("https://image.freepik.com/vector-gratis/error-404-no-encontrado-efecto-falla_8024-5.jpg");
                Breed = "Unknown";
            }
        }

        private async Task SaveCatImage()
        {
            if (ImageUri != null)
            {
                var catImage = new CatImageJR { Url = ImageUri.ToString(), Breed = Breed };
                await SQLiteService.SaveCatImageAsync(catImage);
            }
        }
    }
}