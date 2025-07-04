using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Pages
{
    /// <summary>
    /// The account
    /// </summary>
    public class Account : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int correctPlays;
        private int incorrectPlays;
        private int correctPrompts;
        private int incorrectPrompts;
        private int correctSwipes;
        private int incorrectSwipes;
        private int diamonds;
        private int profilePic;
        private int bestTime;
        private string username = "Guest";
        private bool h17 = true;
        private bool doubleAfterSplit = true;
        private bool surrender = false;
        private bool doubleDeck = false;

        public bool H17
        {
            get => h17;
            set
            {
                h17 = value;
                OnPropertyChanged(nameof(H17));
            }
        }

        public bool DoubleAfterSplit
        {
            get => doubleAfterSplit;
            set
            {
                doubleAfterSplit = value;
                OnPropertyChanged(nameof(DoubleAfterSplit));
            }
        }

        public bool Surrender
        {
            get => surrender;
            set
            {
                surrender = value;
                OnPropertyChanged(nameof(Surrender));
            }
        }

        public bool DoubleDeck
        {
            get => doubleDeck;
            set
            {
                doubleDeck = value;
                OnPropertyChanged(nameof(DoubleDeck));
            }
        }


        public int CorrectPlays
        {
            get => correctPlays;
            set
            {
                correctPlays = value;
                OnPropertyChanged(nameof(CorrectPlays));
            }
        }

        public int IncorrectPlays
        {
            get => incorrectPlays;
            set
            {
                incorrectPlays = value;
                OnPropertyChanged(nameof(IncorrectPlays));
            }
        }

        public int CorrectPrompts
        {
            get => correctPrompts;
            set
            {
                correctPrompts = value;
                OnPropertyChanged(nameof(CorrectPrompts));
            }
        }

        public int IncorrectPrompts
        {
            get => incorrectPrompts;
            set
            {
                incorrectPrompts = value;
                OnPropertyChanged(nameof(IncorrectPrompts));
            }
        }

        public int CorrectSwipes
        {
            get => correctSwipes;
            set
            {
                correctSwipes = value;
                OnPropertyChanged(nameof(CorrectSwipes));
            }
        }

        public int IncorrectSwipes
        {
            get => incorrectSwipes;
            set
            {
                incorrectSwipes = value;
                OnPropertyChanged(nameof(IncorrectSwipes));
            }
        }

        public int Diamonds
        {
            get => diamonds;
            set
            {
                diamonds = value;
                OnPropertyChanged(nameof(Diamonds));
            }
        }

        public int ProfilePic
        {
            get => profilePic;
            set
            {
                profilePic = value;
                OnPropertyChanged(nameof(ProfilePic));
            }
        }

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public int BestTime
        {
            get => bestTime;
            set
            {
                bestTime = value;
                OnPropertyChanged(nameof(BestTime));
            }
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
