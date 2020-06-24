using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace NGU.App.Client.Behaviuors
{
    internal class TextChangedBehaviour
    {
        public static DependencyProperty TextChangedCommandProperty = DependencyProperty.RegisterAttached(
         "TextChanged",
         typeof(ICommand),
         typeof(TextChangedBehaviour),
         new FrameworkPropertyMetadata(
           null,
           new PropertyChangedCallback(
             TextChangedBehaviour.TextChangedChanged)));

        public static void SetTextChanged(TextBox target, ICommand value)
        {
            target.SetValue(TextChangedBehaviour.TextChangedCommandProperty,
              value);
        }

        public static ICommand GetTextChanged(TextBox target)
        {
            return (ICommand)target.GetValue(TextChangedCommandProperty);
        }

        private static void TextChangedChanged(
          DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            TextBox element = target as TextBox;

            if (element != null)
            {
                if (e.NewValue != null)
                {
                    element.TextChanged += Element_TextChanged;
                }
                else
                {
                    element.TextChanged -= Element_TextChanged;
                }
            }
        }

        static void Element_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            BindingExpression bindingExpression = textBox.GetBindingExpression(
              TextBox.TextProperty);

            if (bindingExpression != null)
            {
                bindingExpression.UpdateSource();
            }

            ICommand command = GetTextChanged(textBox);
            if (command.CanExecute(null))
            {
                command.Execute(textBox.Name);
            }
        }
    }
}
