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
        private IMazeGenerator generator;

        public MainWindowViewModel()
        {
            this.generator = new DefaultMazeGenerator();
            this.MazeCells = new ObservableCollection<MazeCellViewModel>();
        }

        public ObservableCollection<MazeCellViewModel> MazeCells
        {
            get;
            set;
        } 

        public ICommand GenerateMazeCommand
        {
            get
            {
                return new RelayCommand(p =>
                {
                    var maze = this.generator.Generate(100, 100);

                    for (int i = 0; i < maze.Cells.Length; i++)
                    {
                        var row = i / maze.Height;
                        var column = i % maze.Width;
                        this.MazeCells.Add(new MazeCellViewModel(maze.Cells[i], column + 10 * column, row + 10 * row));

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
