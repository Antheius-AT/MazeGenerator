using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using MazeGenerator;

namespace MazeVisualization
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int mazeWidth;
        private int mazeHeight;
        private IMazeGenerator generator;

        public MainWindowViewModel()
        {
            this.generator = new DefaultMazeGenerator();
            this.MazeCells = new ObservableCollection<MazeCellViewModel>();
            this.MazeViewModel = new MazeCellViewModel();
            this.GeneratedMazeHeight = 5;
            this.GeneratedMazeWidth = 5;
        }

        public ObservableCollection<MazeCellViewModel> MazeCells
        {
            get;
            set;
        }
        
        public MazeCellViewModel MazeViewModel
        {
            get;
            set;
        }

        public int GeneratedMazeWidth
        {
            get
            {
                return this.mazeWidth;
            }

            set
            {
                if (mazeWidth > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "Maze width must not exceed 100");

                this.mazeWidth = value;
            }
        }

        public int GeneratedMazeHeight
        {
            get
            {
                return this.mazeHeight;
            }

            set
            {
                if (mazeHeight > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "Maze height must not exceed 100");

                this.mazeHeight = value;
            }
        }

        public ICommand GenerateMazeCommand
        {
            get
            {
                return new RelayCommand(p =>
                {
                    var maze = this.generator.Generate(this.GeneratedMazeWidth, this.GeneratedMazeHeight);

                    for (int i = 0; i < maze.Cells.Length; i++)
                    {
                        var row = i / maze.Height;
                        var column = i % maze.Width;
                        this.MazeCells.Add(new MazeCellViewModel(maze.Cells[i], column, row));

                    }

                    this.RaisePropertyChanged(nameof(this.MazeCells));
                },
                p => true);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyPath = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyPath));
        }
    }
}
