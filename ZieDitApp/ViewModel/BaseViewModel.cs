﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZieDitApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy = false;
        string title;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();

                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public bool IsNotBusy => !IsBusy;

        //public event PropertyChangedEventHandler? PropertyChanged;

        //public void OnPropertyChanged([CallerMemberName] string name = null) =>
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public BaseViewModel()
        {

        }

        public async Task<String> LoadPhotoAsync(FileResult photo)
        {
            var stream = photo.OpenReadAsync().Result;

            byte[] imagedata;

            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                imagedata = ms.ToArray();
            }

            var folderpath = Path.Combine(FileSystem.AppDataDirectory, "EmployeePhoto");
            if (!File.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }

            var empfilename = Guid.NewGuid() + "_employeephoto.jpg";

            var newfile = Path.Combine(folderpath, empfilename);// Complete Path of the photo

            using (var stream2 = new MemoryStream(imagedata))
            using (var newstream = File.OpenWrite(newfile))
            {
                await stream2.CopyToAsync(newstream);
            }

            return newfile;
        }
        public virtual void OnAppearing()
        {

        }
        public virtual void OnDisappearing()
        {

        }

        protected bool SetProperty<T>(ref T backingstore, T value,
            [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingstore, value))
                return false;

            backingstore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changes = PropertyChanged;
            if (changes == null)
            {
                return;
            }

            changes.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }


}
