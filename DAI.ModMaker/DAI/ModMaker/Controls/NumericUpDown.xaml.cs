using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using DAI.AssetLibrary.Assets.Bases;

namespace DAI.ModMaker.Controls
{
	public class NumericUpDown : Control
	{
		private EbxField _backingField;

		public static readonly DependencyProperty ValueProperty;

		public static readonly DependencyProperty MinimumProperty;

		public static readonly DependencyProperty MaximumProperty;

		public static readonly DependencyProperty ChangeProperty;

		public static readonly DependencyProperty DecimalPlacesProperty;

		private static readonly DependencyPropertyKey ValueStringPropertyKey;

		public static readonly DependencyProperty ValueStringProperty;

		private NumberFormatInfo _numberFormatInfo = new NumberFormatInfo();

		public static readonly RoutedEvent ValueChangedEvent;

		private static RoutedCommand _increaseCommand;

		private static RoutedCommand _decreaseCommand;

		private const decimal DefaultMinValue = 0m;

		private const decimal DefaultValue = 0m;

		private const decimal DefaultMaxValue = 100m;

		private const decimal DefaultChange = 1m;

		private const int DefaultDecimalPlaces = 0;

		public decimal Value
		{
			get
			{
				return (decimal)GetValue(ValueProperty);
			}
			set
			{
				SetValue(ValueProperty, value);
			}
		}

		public decimal Minimum
		{
			get
			{
				return (decimal)GetValue(MinimumProperty);
			}
			set
			{
				SetValue(MinimumProperty, value);
			}
		}

		public decimal Maximum
		{
			get
			{
				return (decimal)GetValue(MaximumProperty);
			}
			set
			{
				SetValue(MaximumProperty, value);
			}
		}

		public decimal Change
		{
			get
			{
				return (decimal)GetValue(ChangeProperty);
			}
			set
			{
				SetValue(ChangeProperty, value);
			}
		}

		public int DecimalPlaces
		{
			get
			{
				return (int)GetValue(DecimalPlacesProperty);
			}
			set
			{
				SetValue(DecimalPlacesProperty, value);
			}
		}

		public string ValueString => (string)GetValue(ValueStringProperty);

		public static RoutedCommand IncreaseCommand => _increaseCommand;

		public static RoutedCommand DecreaseCommand => _decreaseCommand;

		public event RoutedPropertyChangedEventHandler<decimal> ValueChanged
		{
			add
			{
				AddHandler(ValueChangedEvent, value);
			}
			remove
			{
				RemoveHandler(ValueChangedEvent, value);
			}
		}

		static NumericUpDown()
		{
			ValueProperty = DependencyProperty.Register("Value", typeof(decimal), typeof(NumericUpDown), new FrameworkPropertyMetadata(0m, OnValueChanged, CoerceValue));
			MinimumProperty = DependencyProperty.Register("Minimum", typeof(decimal), typeof(NumericUpDown), new FrameworkPropertyMetadata(0m, OnMinimumChanged, CoerceMinimum));
			MaximumProperty = DependencyProperty.Register("Maximum", typeof(decimal), typeof(NumericUpDown), new FrameworkPropertyMetadata(100m, OnMaximumChanged, CoerceMaximum));
			ChangeProperty = DependencyProperty.Register("Change", typeof(decimal), typeof(NumericUpDown), new FrameworkPropertyMetadata(1m, OnChangeChanged, CoerceChange), ValidateChange);
			DecimalPlacesProperty = DependencyProperty.Register("DecimalPlaces", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(0, OnDecimalPlacesChanged), ValidateDecimalPlaces);
			ValueStringPropertyKey = DependencyProperty.RegisterAttachedReadOnly("ValueString", typeof(string), typeof(NumericUpDown), new PropertyMetadata());
			ValueStringProperty = ValueStringPropertyKey.DependencyProperty;
			ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<decimal>), typeof(NumericUpDown));
			InitializeCommands();
			EventManager.RegisterClassHandler(typeof(NumericUpDown), Mouse.MouseDownEvent, new MouseButtonEventHandler(OnMouseLeftButtonDown), true);
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
		}

		public static bool IsTypeSupported(FieldType type)
		{
			switch (type)
			{
				case FieldType.DAI_Long:
				case FieldType.DAI_Byte:
				case FieldType.DAI_UByte:
				case FieldType.DAI_UShort:
				case FieldType.DAI_Short:
				case FieldType.DAI_Int:
				case FieldType.DAI_UInt:
				case FieldType.DAI_ULong:
				case FieldType.DAI_Single:
				case FieldType.DAI_Double:
					return true;
				default:
					return false;
			}
		}

		public NumericUpDown()
			: this(null)
		{
		}

		public NumericUpDown(EbxField field)
		{
			base.DataContext = this;
			if (field != null)
			{
				InitForType(field.Descriptor.FieldType);
				Value = field.NumericValue();
				_backingField = field;
			}
			updateValueString();
		}

		private void InitForType(FieldType type)
		{
			DecimalPlaces = 0;
			Minimum = 0m;
			switch (type)
			{
				case FieldType.DAI_Int:
					Minimum = -2147483648m;
					Maximum = 2147483647m;
					break;
				case FieldType.DAI_UInt:
					Maximum = -1m;
					break;
				case FieldType.DAI_Short:
					Minimum = -32768m;
					Maximum = 32767m;
					break;
				case FieldType.DAI_UShort:
					Maximum = 65535m;
					break;
				case FieldType.DAI_UByte:
					Minimum = -128m;
					Maximum = 127m;
					break;
				case FieldType.DAI_Byte:
					Minimum = 0m;
					Maximum = 255m;
					break;
				case FieldType.DAI_Long:
				case FieldType.DAI_ULong:
					Minimum = new decimal(long.MinValue);
					Maximum = new decimal(long.MaxValue);
					break;
				case FieldType.DAI_Single:
				case FieldType.DAI_Double:
					Minimum = decimal.MinValue;
					Maximum = decimal.MaxValue;
					DecimalPlaces = 3;
					Change = 0.001m;
					break;
			}
		}

		private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			NumericUpDown control = (NumericUpDown)obj;
			decimal oldValue = (decimal)args.OldValue;
			decimal newValue = (decimal)args.NewValue;
			RoutedPropertyChangedEventArgs<decimal> e = new RoutedPropertyChangedEventArgs<decimal>(oldValue, newValue, ValueChangedEvent);
			if (control._backingField != null)
			{
				control._backingField.SetNumericValue(control.Value);
			}
			control.OnValueChanged(e);
			control.updateValueString();
		}

		protected virtual void OnValueChanged(RoutedPropertyChangedEventArgs<decimal> args)
		{
			RaiseEvent(args);
		}

		private static object CoerceValue(DependencyObject element, object value)
		{
			decimal newValue = (decimal)value;
			NumericUpDown control = (NumericUpDown)element;
			newValue = Math.Max(control.Minimum, Math.Min(control.Maximum, newValue));
			newValue = decimal.Round(newValue, control.DecimalPlaces);
			return newValue;
		}

		private static void OnMinimumChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
		{
			element.CoerceValue(MaximumProperty);
			element.CoerceValue(ValueProperty);
		}

		private static object CoerceMinimum(DependencyObject element, object value)
		{
			decimal d = (decimal)value;
			NumericUpDown control = (NumericUpDown)element;
			return decimal.Round(d, control.DecimalPlaces);
		}

		private static void OnMaximumChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
		{
			element.CoerceValue(ValueProperty);
		}

		private static object CoerceMaximum(DependencyObject element, object value)
		{
			NumericUpDown control = (NumericUpDown)element;
			return decimal.Round(Math.Max((decimal)value, control.Minimum), control.DecimalPlaces);
		}

		private static bool ValidateChange(object value)
		{
			return (decimal)value > 0m;
		}

		private static void OnChangeChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
		{
		}

		private static object CoerceChange(DependencyObject element, object value)
		{
			decimal newChange = (decimal)value;
			NumericUpDown control = (NumericUpDown)element;
			decimal coercedNewChange = decimal.Round(newChange, control.DecimalPlaces);
			if (coercedNewChange < newChange)
			{
				coercedNewChange = smallestForDecimalPlaces(control.DecimalPlaces);
			}
			return coercedNewChange;
		}

		private static decimal smallestForDecimalPlaces(int decimalPlaces)
		{
			decimal d = 1m;
			for (int i = 0; i < decimalPlaces; i++)
			{
				d /= 10m;
			}
			return d;
		}

		private static void OnDecimalPlacesChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
		{
			NumericUpDown obj = (NumericUpDown)element;
			obj.CoerceValue(ChangeProperty);
			obj.CoerceValue(MinimumProperty);
			obj.CoerceValue(MaximumProperty);
			obj.CoerceValue(ValueProperty);
			obj.updateValueString();
		}

		private static bool ValidateDecimalPlaces(object value)
		{
			return (int)value >= 0;
		}

		private void updateValueString()
		{
			_numberFormatInfo.NumberDecimalDigits = DecimalPlaces;
			string newValueString = Value.ToString("f", _numberFormatInfo);
			SetValue(ValueStringPropertyKey, newValueString);
		}

		private static void InitializeCommands()
		{
			_increaseCommand = new RoutedCommand("IncreaseCommand", typeof(NumericUpDown));
			CommandManager.RegisterClassCommandBinding(typeof(NumericUpDown), new CommandBinding(_increaseCommand, OnIncreaseCommand));
			CommandManager.RegisterClassInputBinding(typeof(NumericUpDown), new InputBinding(_increaseCommand, new KeyGesture(Key.Up)));
			_decreaseCommand = new RoutedCommand("DecreaseCommand", typeof(NumericUpDown));
			CommandManager.RegisterClassCommandBinding(typeof(NumericUpDown), new CommandBinding(_decreaseCommand, OnDecreaseCommand));
			CommandManager.RegisterClassInputBinding(typeof(NumericUpDown), new InputBinding(_decreaseCommand, new KeyGesture(Key.Down)));
		}

		private static void OnIncreaseCommand(object sender, ExecutedRoutedEventArgs e)
		{
			(sender as NumericUpDown)?.OnIncrease();
		}

		private static void OnDecreaseCommand(object sender, ExecutedRoutedEventArgs e)
		{
			(sender as NumericUpDown)?.OnDecrease();
		}

		protected virtual void OnIncrease()
		{
			Value += Change;
		}

		protected virtual void OnDecrease()
		{
			Value -= Change;
		}

		private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			NumericUpDown control = (NumericUpDown)sender;
			if (!control.IsKeyboardFocusWithin)
			{
				e.Handled = control.Focus() || e.Handled;
			}
		}
	}
}
