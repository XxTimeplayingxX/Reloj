﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Reloj
{
    

    public class ClockViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _dateTime;
        private Timer _timer;
        public DateTime FechaHora
        {
            get => _dateTime;
            set
            {
                if (_dateTime != value)
                {
                    _dateTime = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        public ClockViewModel()
        {
            this.FechaHora = DateTime.Now;

            // Update the DateTime property every second.
            _timer = new Timer(new TimerCallback((s) => this.FechaHora = DateTime.Now),
                               null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        ~ClockViewModel() =>
      _timer.Dispose();

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }



}
