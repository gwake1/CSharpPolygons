using SharpShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace GrapeShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateClassList();
            PopulateTestShapes();
        }

        public static int ArgumentCountFor(string className)
        {
            Type classType = GetShapeTypeOf(className);
            ConstructorInfo classConstructor = classType.GetConstructors().First();
            return classConstructor.GetParameters().Length;
        }

        private static Type GetShapeTypeOf(string className)
        {
            return Assembly.GetAssembly(typeof(Shape)).GetTypes().Where(shapeType => shapeType.Name == className).First();
        }

        public static Shape InstantiateWithArguments(string className, object[] args)
        {
            Type classType = GetShapeTypeOf(className);
            ConstructorInfo classConstructor = classType.GetConstructors().First();
            return (Shape)classConstructor.Invoke(args);
        }

        private void PopulateClassList()
        {
            var classList = new List<string>();
            var shapeType = typeof(Shape);
            foreach (Type type in Assembly.GetAssembly(shapeType).GetTypes())
            {
                if (type.IsSubclassOf(shapeType) && !type.IsAbstract)
                {
                    classList.Add(type.Name);
                }
            }
            ShapeType.ItemsSource = classList;
        }

        private void PopulateTestShapes()
        {
            var square = new Square(30);
            SolidColorBrush mediaFillColor = new SolidColorBrush();
            mediaFillColor.Color = System.Windows.Media.Color.FromArgb(square.FillColor.A, square.FillColor.R, square.FillColor.G, square.FillColor.B);

            var square2 = new Square(200);
            SolidColorBrush mediaBorderColor = new SolidColorBrush();
            mediaBorderColor.Color = System.Windows.Media.Color.FromArgb(square.BorderColor.A, square.BorderColor.R, square.BorderColor.B, square.BorderColor.G);
            square.DrawOnto(ShapeCanvas, 1, 50);
            square.DrawOnto(ShapeCanvas, 50, 5);
        }

        private void ShapeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string className = (String)ShapeType.SelectedValue;
            int argCount = ArgumentCountFor(className);
            Argument1.IsEnabled = true;
            Argument2.IsEnabled = (argCount > 1);
            Argument3.IsEnabled = (argCount > 2);
            Argument1.Text = "0";
            Argument2.Text = "0";
            Argument3.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string className = (String)ShapeType.SelectedValue;
            int argCount = ArgumentCountFor(className);
            object[] potentialArgs = new object[] { Int32.Parse(Argument1.Text), Int32.Parse(Argument2.Text), Int32.Parse(Argument3.Text) };
            Shape shape = InstantiateWithArguments(className, potentialArgs.Take(argCount).ToArray());
            shape.DrawOnto(ShapeCanvas, 50, 50);
        }
    }
}