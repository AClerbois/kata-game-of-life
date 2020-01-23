using Aclerbois.GameOfLife.Business.Models;
using Aclerbois.GameOfLife.Business.Services;
using Aclerbois.GameOfLife.Shared.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aclerbois.GameOfLife.Wpf
{
    public partial class MainWindow : Window
    {
        private readonly NextGenerationService nextGenerationService;
        private Generation generation;

        public MainWindow()
        {
            InitializeComponent();
            nextGenerationService = new NextGenerationService();
            IPattern pattern = new CanonPattern();
            generation = pattern.GetGeneration();

            InitializeGameOfLifeGrid(generation);

            DrawGeneration(generation);
        }

        private void InitializeGameOfLifeGrid(Generation generation)
        {
            this.GameOfLife.ColumnDefinitions.Clear();
            this.GameOfLife.RowDefinitions.Clear();
            double caseSize = 10;
            for (int row = 0; row < generation.GenerationSize.Height; row++)
                this.GameOfLife.RowDefinitions.Add(new RowDefinition { Height = new GridLength(caseSize) });
            for (int column = 0; column < generation.GenerationSize.Width; column++)
                this.GameOfLife.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(caseSize) });

            for (int row = 0; row < generation.GenerationSize.Height; row++)
                for (int column = 0; column < generation.GenerationSize.Width; column++)
                    GenerateRectancle(generation, row, column, caseSize);

        }

        private void GenerateRectancle(Generation generation, int rowIndex, int columnIndex, double caseSize)
        {
            double borderThickness = 0.5;
            var border = new Border
            {
                Name = $"bordercase_{rowIndex}_{columnIndex}",
                Width = caseSize,
                Height = caseSize,
                BorderThickness = new Thickness(borderThickness),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0))
            };
            border.Child = new Rectangle()
            {
                Name = $"case_{rowIndex}_{columnIndex}",
                Width = caseSize - (borderThickness * 2),
                Height = caseSize - (borderThickness * 2),
                Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255))
            };

            this.GameOfLife.Children.Add(border);

            Grid.SetRow(border, rowIndex);
            Grid.SetColumn(border, columnIndex);
        }

        private void DrawGeneration(Generation generation)
        {
            for (int row = 0; row < generation.GenerationSize.Height; row++)
                for (int column = 0; column < generation.GenerationSize.Width; column++)
                    FindChild<Rectangle>(this.GameOfLife, $"case_{row}_{column}").Fill = GetFill(generation, row, column);
        }

        private SolidColorBrush GetFill(Generation generation, int rowIndex, int columnIndex)
        {
            return generation.CurrentGeneration[rowIndex, columnIndex]
                 ? new SolidColorBrush(Color.FromRgb(0, 0, 0))
                 : new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }



        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                generation = nextGenerationService.Build(generation);
                DrawGeneration(generation);
                await Task.Delay(50);
            } while (true);
        }
    }
}