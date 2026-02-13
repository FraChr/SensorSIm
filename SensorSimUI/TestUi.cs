using System.Windows;
using System.Windows.Controls;

namespace SensorSimUI;

public class TestUi
{
    public Window CreateWindow()
    {
        Window window = new Window()
        {
            Title = "Sensor Sim",
            Width = 400,
            Height = 300,
        };

        StackPanel stackPanel = new StackPanel();
        window.Content = stackPanel;

        Button button = new Button()
        {
            Content = "Say something",
            Width = 100,
            Height = 30,
            Margin = new Thickness(10)
        };
        button.Click += (s, e) => MessageBox.Show("Say something");
        
        stackPanel.Children.Add(button);
        return window;
    }
}