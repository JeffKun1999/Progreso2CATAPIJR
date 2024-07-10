using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progreso2CATAPIJR.Services;
using Progreso2CATAPIJR.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace Progreso2CATAPIJR.ViewModels
{
    public class SavedCatImagesViewModelJR : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SavedCatImagesViewModelJR()
        {
            LoadSavedCatImagesCommand = new Command(async () => await LoadSavedCatImages());
            sqliteService = new SQLiteServiceJR();
        }

        private SQLiteServiceJR sqliteService;
        public SQLiteServiceJR SQLiteService
        {
            get { return sqliteService; }
        }

        private ObservableCollection<CatImageJR> savedCatImages;
        public ObservableCollection<CatImageJR> SavedCatImages
        {
            get { return savedCatImages; }
            set
            {
                if (savedCatImages != value)
                {
                    savedCatImages = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand LoadSavedCatImagesCommand { get; }

        private async Task LoadSavedCatImages()
        {
            var images = await SQLiteService.GetCatImagesAsync();
            SavedCatImages = new ObservableCollection<CatImageJR>(images);
        }
    }
}