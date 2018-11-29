using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BestAppClient.Behaviors
{
    public class NumberValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(CompareValidationBehavior), false);

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }
        public string CurrentText { get; set; }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = double.TryParse(e.NewTextValue, out double result);
            if (CurrentText == e.NewTextValue)
                IsValid = true;
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
