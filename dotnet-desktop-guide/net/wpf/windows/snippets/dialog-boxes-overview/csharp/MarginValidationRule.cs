﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dialogs
{
    public class MarginValidationRule : ValidationRule
    {
        public double MinMargin { get; set; }
        public double MaxMargin { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double margin;

            // Is a number?
            if (!double.TryParse((string)value, out margin))
            {
                return new ValidationResult(false, "Not a number.");
            }

            // Is in range?
            if ((margin < MinMargin) || (margin > MaxMargin))
            {
                var msg = $"Margin must be between {MinMargin} and {MaxMargin}.";
                return new ValidationResult(false, msg);
            }

            // Number is valid
            return new ValidationResult(true, null);
        }
    }
}
