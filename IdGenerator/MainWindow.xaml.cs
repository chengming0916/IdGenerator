using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace IdGenerator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            GenerateCommand = new DelegateCommand(Generate);
        }

        private void Generate(object obj)
        {
            string id = IdGeneratorFactory.CreateGenerator(GeneratorType).Generate(DbType).ToUpper();

            ContentText += (id + "\r");
        }

        private DbType _dbType;
        private GeneratorType _generatorType;

        public DbType DbType
        {
            get { return _dbType; }
            set
            {
                _dbType = value;
                RaisePropertyChanged(nameof(DbType));
            }
        }

        public GeneratorType GeneratorType
        {
            get { return _generatorType; }
            set
            {
                _generatorType = value;
                RaisePropertyChanged(nameof(GeneratorType));
            }
        }

        private string _contentText;

        public string ContentText
        {
            get { return _contentText; }
            set
            {
                _contentText = value;
                RaisePropertyChanged(nameof(ContentText));
            }
        }

        public ICommand GenerateCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DelegateCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}